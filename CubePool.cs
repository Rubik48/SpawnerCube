using System;
using UnityEngine;
using System.Collections.Generic;

public class CubePool : MonoBehaviour 
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private int _poolSize = 10;

    private Queue<Cube> _pool = new Queue<Cube>();
    private Cube _cube;
    
    private void Awake() {
        for (int i = 0; i < _poolSize; i++) 
        {
            _cube = Instantiate(_cubePrefab, transform);
            _cube.gameObject.SetActive(false);
            
            _cube.OnLifeEnded += HandleCubeLifeEnded;
            _pool.Enqueue(_cube);
        }
    }

    private void OnDisable()
    {
        _cube.OnLifeEnded -= HandleCubeLifeEnded;
    }

    public Cube GetCube() 
    {
        if (_pool.Count > 0) 
        {
            Cube cube = _pool.Dequeue();
            
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
        
        _pool.Enqueue(cube);
    }
}