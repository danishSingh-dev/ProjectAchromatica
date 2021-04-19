using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Danish.Input
{



    public class ThirdPersonCamera : MonoBehaviour
    {
        //[SerializeField] private float distanceToPlayer = 5f;
        [SerializeField] private float rotationSpeed = 10f;
        [SerializeField] private Transform target = null;
        //[SerializeField] private Transform player = null;

        private Camera _camera = null;
        private Transform _camTransform = null;


        float mouseX, mouseY;
        float _horizontal, _vertical;

        private void Awake()
        {
            _camera = Camera.main;
            _camTransform = _camera.transform;
        }

        private void FixedUpdate()
        {
            CameraFunctionality();
        }



        private void SetCameraDistance(float distance)
        {
            Vector3 cameraPosition = Vector3.zero;
            Vector3 playerPosition = Vector3.zero;

            cameraPosition = _camTransform.position;
            //playerPosition = player.position;

            //float currentDistance = Vector3.Distance(playerPosition, cameraPosition);

        }

        private void CameraFunctionality()
        {
            mouseX += _horizontal * rotationSpeed * Time.deltaTime;
            mouseY += _vertical * rotationSpeed * Time.deltaTime;

            mouseY = Mathf.Clamp(mouseY, -35, 60);

            if (target != null)
                _camTransform.LookAt(target);
            else
            {
                Debug.Log("Need to assign camera target");
                return;
            }

            target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        }

        public void CameraControl(float horizontal, float vertical)
        {
            _horizontal = horizontal;
            _vertical = vertical;
        }
    }
}