using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Danish.Input
{



    public class ThirdPersonCamera : MonoBehaviour
    {
        [SerializeField] private float distanceToPlayer = 5f;
        [SerializeField] private Transform player = null;

        private void FixedUpdate()
        {
            if(player != null)
            {
                Camera.main.transform.position = player.position - (player.forward * distanceToPlayer);
            }
        }
    }
}