using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstcaleSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> _obstacles;
    
    [SerializeField] GameObject runwayPrefab;
    [SerializeField] GameObject _playerGameObject;
    [SerializeField] GameObject _rewardCarboard;

    [SerializeField] float deltaX;

    private Transform _playerTransform;

    private float _lastSpawn;
    private const float _timeLap = 3f;
    private float _timePassed = 0f;

    void Start()
    {
        _playerTransform = _playerGameObject.GetComponent<Transform>();
        _lastSpawn = _playerTransform.position.x + deltaX;
        _timePassed = _timeLap;
        SpawnObstacles();
    }

    void Update()
    {
        SpawnObstacles();

    }

    private void SpawnObstacles()
    {
        if (_playerTransform.position.x > _lastSpawn - deltaX * 3)
        {
            float yValue;
            for (int i = 0; i < 6; i++)
            {
                int index = Random.Range(0, _obstacles.Count);
                switch (index)
                {
                    case 0:
                        yValue = 6.3f;
                        break;
                    default:
                        yValue = 0f;
                        break;
                }
                Instantiate(_obstacles[index], new Vector3(_lastSpawn, yValue, 0), _playerTransform.rotation);
                Instantiate(_rewardCarboard, new Vector3(_lastSpawn + (deltaX/2) , 0, 0), _playerTransform.rotation);
                _lastSpawn += deltaX;
            }
            deltaX --;
            if (deltaX <= 5) { deltaX = 5; }
        }
    }
}