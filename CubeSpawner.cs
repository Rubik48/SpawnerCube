using UnityEngine;
using Random = UnityEngine.Random;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private CubePool _cubePool;
    [SerializeField] private float _spawnInterval = 1f;
    [SerializeField] private float _spawnHeight = 10f;
    [SerializeField]private Vector3 _spawnAreaSize = new Vector3(10f, 0, 10f);

    private void Start()
    {
        InvokeRepeating(nameof(SpawnCube), 0, _spawnInterval);
    }

    private void SpawnCube()
    {
        GameObject cube = _cubePool.GetCube();

        if (cube != null)
        {
            float randomX = Random.Range(-_spawnAreaSize.x / 2f, _spawnAreaSize.x / 2f);
            float randomZ = Random.Range(-_spawnAreaSize.z / 2f, _spawnAreaSize.z / 2f);
            
            cube.transform.position = new Vector3(randomX, _spawnHeight, randomZ);
        }
    }
}
