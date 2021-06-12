using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ManagementFunction
{
    public class GameManager : MonoBehaviour
    {
        private void OnEnable( )
        {
            Application.targetFrameRate = 200;
        }

    }
}
