#if UNITY_EDITOR
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEditor.SceneManagement;
using System;
using System.IO;
using TerraUnity.UI;

namespace TerraUnity.Edittime
{
    public enum SceneDownloaderStatus
    {
        Initializing,
        Downloading,
        Importing,
        Idle,
        Error,
        Aborted
    }

    [ExecuteInEditMode]
    public class DownloadDemoScene : MonoBehaviour
    {
#pragma warning disable CS0414 // Add readonly modifier
        public static SceneDownloaderStatus status = SceneDownloaderStatus.Idle;
        private static string scenesURL;
        public static string demoScenePath = "Assets/TerraWorld/Scenes/Pro/Alps/Alps.unity";
        public static string demoSceneDownloadPath = "Assets/TerraWorld/Scenes/Pro/Demo Scene Download.unity";
        private static string cachePath;
        private static int progressId;
        private static string title = "DOWNLOADING SCENE";
        private static string info = "Downloading package, please wait...";
#pragma warning restore CS0414 // Add readonly modifier

#if TERRAWORLD_PRO
        private void OnEnable()
        {
            Initialize();
            EditorApplication.update += OnEditorUpdate;
        }

        void OnDisable()
        {
            TProgressBar.RemoveProgressBar(progressId);
            EditorApplication.update -= OnEditorUpdate;
        }

        protected virtual void OnEditorUpdate()
        {
            Update();
        }

        private void Update()
        {
            if (Application.isPlaying) return;

            if (status == SceneDownloaderStatus.Initializing)
            {
                if (!AssetDatabase.IsValidFolder(Path.GetDirectoryName(demoScenePath)) || AssetDatabase.LoadAssetAtPath(demoScenePath, typeof(UnityEngine.Object)) == null)
                {
                    if (EditorUtility.DisplayDialog("TERRAWORLD", "DOWNLOAD DEMO SCENE\n\nDemo scene should be downloaded from the internet (600 MB file size for the first time. After that it will be loaded from the cache)\n\nDo you want to proceed and import package into the project?", "Yes", "No"))
                        DownloadScenePackage();
                }
            }

            if (status == SceneDownloaderStatus.Downloading)
            {
                TProgressBar.DisplayCancelableProgressBar("TERRAWORLD", "Downloading scene package, please wait...", ServerSync.PackageDownloadProgress, progressId, CancelDownload);
                if (EditorUtility.DisplayCancelableProgressBar("TERRAWORLD", "Downloading scene package, please wait...", ServerSync.PackageDownloadProgress)) CancelDownload();
            }

            if (status != SceneDownloaderStatus.Downloading && !EditorApplication.isCompiling)
                LoadScene();
        }

        private void Initialize()
        {
            if (Application.isPlaying) return;
            status = SceneDownloaderStatus.Initializing;
        }

        public static void DownloadScenePackage()
        {
            progressId = TProgressBar.StartCancelableProgressBar(title, info, TProgressBar.ProgressOptionsList.Managed, true, CancelDownload);
            string pathLocal = ""; // This is the root of "Scenes/Pro" folder in project
            cachePath = TAddresses.scenesPath_Pro_Cache;
            status = SceneDownloaderStatus.Downloading;

#if TERRAWORLD_PRO
            scenesURL = "http://terraunity.com/TerraWorldScenes/DemoScenes01.php";
#else
            scenesURL = "http://terraunity.com/TerraWorldScenes/Lite/";
#endif

            ServerSync.DownloadPackage(scenesURL, pathLocal, cachePath, DownloadPackageCompleted);
        }

        private static void DownloadPackageCompleted(Exception e, string retrievePath)
        {
            TProgressBar.RemoveProgressBar(progressId);

            if (e == null && !string.IsNullOrEmpty(retrievePath) && retrievePath.EndsWith(".unitypackage"))
            {
                status = SceneDownloaderStatus.Importing;
                ImportPackage(retrievePath);
            }

            if (e != null)
            {
                // Checks if package is already downloaded and exists in system's cache folder even though there
                // was no connection made to servers or encountered errors during data capturing
                if (!string.IsNullOrEmpty(retrievePath))
                {
                    string folderPath = cachePath + retrievePath;

                    if (Directory.Exists(folderPath))
                    {
                        string[] packages = Directory.GetFiles(folderPath, "*.unitypackage", SearchOption.TopDirectoryOnly);

                        if (packages.Length > 0 && !string.IsNullOrEmpty(packages[0]))
                        {
                            status = SceneDownloaderStatus.Importing;
                            ImportPackage(packages[0]);
                        }
                        else
                        {
                            if (e.Message.Contains("ConnectFailure") || e.Message.Contains("NameResolutionFailure"))
                            {
                                e.Data.Add("TW", "Seems like you are offline!\n\nPackage cannot be downloaded from TERRA servers!");
                                TDebug.LogErrorToUnityUI(e);
                            }
                            else
                                TDebug.LogErrorToUnityUI(e);
                        }
                    }
                    else
                    {
                        if (e.Message.Contains("ConnectFailure") || e.Message.Contains("NameResolutionFailure"))
                        {
                            e.Data.Add("TW", "Seems like you are offline!\n\nPackage cannot be downloaded from TERRA servers!");
                            TDebug.LogErrorToUnityUI(e);
                        }
                        else
                            TDebug.LogErrorToUnityUI(e);
                    }
                }
                else
                {
                    TDebug.LogErrorToUnityUI(e);
                }
            }
        }

        private static void ImportPackage(string path)
        {
            try
            {
                if (string.IsNullOrEmpty(path)) return;
                TProgressBar.RemoveProgressBar(progressId);
                AssetDatabase.ImportPackage(path, false);
            }
            catch
            {
                status = SceneDownloaderStatus.Error;
                EditorUtility.DisplayDialog("TERRAWORLD", "IMPORT ERROR : There was a problem importing unitypackage from cache folder!\n\nPlease try again!", "OK");
            }
        }

        private static void LoadScene()
        {
            try
            {
                Scene activeScene = SceneManager.GetActiveScene();
                if (activeScene == SceneManager.GetSceneByPath(demoScenePath)) return;

                if (AssetDatabase.IsValidFolder(Path.GetDirectoryName(demoScenePath)))
                {
                    if (AssetDatabase.LoadAssetAtPath(demoScenePath, typeof(UnityEngine.Object)) != null)
                    {
                        EditorSceneManager.OpenScene(demoScenePath);
                        SceneView sceneView = SceneView.lastActiveSceneView;

                        if (sceneView != null)
                        {
                            Vector3 cameraPosition = new Vector3(-668.7631f, 2093.446f, -286.6309f);
                            Vector3 cameraRotation = new Vector3(0f, 0f, 0f);
                            sceneView.orthographic = false;
                            Quaternion rotation = Quaternion.Euler(cameraRotation);
                            //Vector3 forwardOffset = rotation * Vector3.forward * 150f;
                            //Vector3 upwardOffset = rotation * Vector3.up * 10f;
                            //sceneView.LookAt(cameraPosition + forwardOffset + upwardOffset, rotation, 150);
                            sceneView.LookAt(cameraPosition, rotation, 10);
                        }
                    }
                    else
                        Debug.Log("Demo Scene Not Found!");
                }

                status = SceneDownloaderStatus.Idle;
            }
            catch (Exception e)
            {
                status = SceneDownloaderStatus.Error;
                TDebug.LogErrorToUnityUI(e);
            }
        }

        public static bool CancelDownload()
        {
            TProgressBar.RemoveProgressBar(progressId);
            status = SceneDownloaderStatus.Aborted;
            ServerSync.CancelDownload();

            return true;
        }
#endif
    }
}
#endif

