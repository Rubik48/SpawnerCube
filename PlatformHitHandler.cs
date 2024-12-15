using System;
using UnityEngine;

public class PlatformHitHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        var cubeController = collision.collider.GetComponent<CubeController>();

        if (cubeController != null)
        {
            cubeController.OnPlatformHit();
        }
    }
}
