using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

namespace UIFunction
{
    public class MainMenuInterface : MonoBehaviour
    {

        public void PlayGame( )
        {
            SceneManager.LoadScene( SceneManager.GetActiveScene( ).buildIndex + 1 );
        }

        public void QuitGame( )
        {
            Application.Quit( );
        }
    }
}
