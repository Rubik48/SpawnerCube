using UnityEngine;
using UnityEngine.Pool;

public class CubePool : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private int _cubeCount;
    [SerializeField] private int _maxCount;
    
    private ObjectPool<GameObject> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<GameObject>(
            createFunc: () => Instantiate(_cubePrefab),
            actionOnGet: (cube) => cube.SetActive(true),
            actionOnRelease: (cube) => cube.SetActive(false),
            actionOnDestroy: (cube) => Destroy(cube),
            collectionCheck: false,
            defaultCapacity: _cubeCount,
            maxSize: _maxCount);

        for (int i = 0; i < _cubeCount; i++)
        {
            GameObject cube = _pool.Get();
            _pool.Release(cube);
        }
    }

    public GameObject GetCube()
    {
        return _pool.Get();
    }

    public void ReturnCube(GameObject cube)
    {
        _pool.Release(cube);
    }
}