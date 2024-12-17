using UnityEngine;

public class PlatformHitHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Cube>(out Cube cube)) 
            cube.OnPlatformHit();
    }
}
