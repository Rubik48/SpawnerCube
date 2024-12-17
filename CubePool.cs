using UnityEngine;
using System.Collections.Generic;

public class CubePool : MonoBehaviour 
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private int _poolSize = 50;

    private Queue<Cube> pool = new Queue<Cube>();

    void Awake() {
        for (int i = 0; i < _poolSize; i++) 
        {
            Cube cube = Instantiate(_cubePrefab, transform);
            cube.gameObject.SetActive(false);

            cube.OnLifeEnded += HandleCubeLifeEnded;
            pool.Enqueue(cube);
        }
    }
    
    public Cube GetCube() {
        if (pool.Count > 0) 
        {
            Cube cube = pool.Dequeue();
            cube.ResetCube(); 
            cube.gameObject.SetActive(true);
            return cube;
        } 
        else 
        {
            Cube cube = Instantiate(_cubePrefab, transform);
            cube.OnLifeEnded += HandleCubeLifeEnded;
            cube.gameObject.SetActive(true);
            return cube;
        }
    }
    
    private void HandleCubeLifeEnded(Cube cube) 
    {
        cube.gameObject.SetActive(false);
        pool.Enqueue(cube);
    }
}