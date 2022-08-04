using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> _coins;
    [SerializeField] GameObject _obstaPrefab;
    [SerializeField] GameObject _player;

    
    MeshRenderer _getSize;
    Transform _character;

    void Start()
    {
        _getSize = _obstaPrefab.GetComponentInChildren<MeshRenderer>();
        _character = _player.GetComponent<Transform>();
    }

    private void Update()
    {
        SpawnCoins();
    }

    IEnumerator SpawnCoins()
    {
        int num = Random.Range(0, 100);
        if (num < 25)
        {
            yield return Instantiate(_coins[0], new Vector3(_player.transform.position.x + 20, 0, _player.transform.position.z), gameObject.transform.rotation);
        }
        else if (num == 0)
        {
            yield return Instantiate(_coins[1], new Vector3(_player.transform.position.x + 20, 0, _player.transform.position.z), gameObject.transform.rotation);
        }
        else
        {
            yield return new WaitForSeconds(2);
        }
    }
}