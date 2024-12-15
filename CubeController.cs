using UnityEngine;
using Random = UnityEngine.Random;

public class CubeController : MonoBehaviour
{
    [SerializeField] private CubePool _cubePool;
    [SerializeField] private float _deathTime = 1f;
    [SerializeField] private float _minLifeTime = 2f;
    [SerializeField] private float _maxLifeTime = 5f;
    
    private bool _hasColorChanghed = false;
    private Renderer _rend;

    private void Awake()
    {
        _rend = GetComponent<Renderer>();

        _cubePool = FindObjectOfType<CubePool>();
    }

    private void Start()
    {
        ResetCube();
    }

    private void Update()
    {
        if (_deathTime > 0 && Time.time > _deathTime)
        {
            _cubePool.ReturnCube(gameObject);

            ResetCube();
        }
    }

    public void OnPlatformHit()
    {
        if (!_hasColorChanghed)
        {
            float lifeTime = Random.Range(_minLifeTime, _maxLifeTime);
            
            _hasColorChanghed = true;
            
            _rend.material.color = Color.green;
            
            _deathTime = Time.time + lifeTime;
        }
    }

    private void ResetCube()
    {
        _hasColorChanghed = false;

        _deathTime = -1f;
        
        _rend.material.color = Color.white;
    }
}
