using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class Cube : MonoBehaviour 
{
    private bool _hasColorChanged = false;
    private float _deathTime = -1f;
    private Renderer _rend;
    
    public event Action<Cube> OnLifeEnded;

    void Awake() 
    {
        _rend = GetComponent<Renderer>();
    }

    void Update() 
    {
        if (_deathTime > 0 && Time.time > _deathTime) 
        {
            if (OnLifeEnded != null) 
            {
                OnLifeEnded(this);
            }
            
            ResetCube();
        }
    }

    public void OnPlatformHit() 
    {
        if (_hasColorChanged == false) 
        {
            _hasColorChanged = true;
            _rend.material.color = Color.red;
            
            float lifeTime = Random.Range(2f, 5f);
            _deathTime = Time.time + lifeTime;
        }
    }

    public void ResetCube() 
    {
        _hasColorChanged = false;
        _deathTime = -1f;
        _rend.material.color = Color.white;
    }
}