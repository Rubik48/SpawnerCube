using UnityEngine;

public class CubeSpawner : MonoBehaviour 
{
    [SerializeField] private CubePool _pool;
    [SerializeField] private float _spawnInterval = 1f;
    [SerializeField] private Vector3 _spawnAreaSize = new Vector3(10f, 0f, 10f);
    [SerializeField] private float _spawnHeight = 10f;

    void Start() 
    {
        InvokeRepeating(nameof(SpawnCube), 0f, _spawnInterval);
    }

    void SpawnCube() 
    {
        Cube cube = _pool.GetCube();
        
        if (cube != null)
        {
            float x = Random.Range(-_spawnAreaSize.x / 2f, _spawnAreaSize.x / 2f);
            float z = Random.Range(-_spawnAreaSize.z / 2f, _spawnAreaSize.z / 2f);
            cube.transform.position = new Vector3(x, _spawnHeight, z);
        }
    }
}