using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // public

    // [sf]
    [SerializeField] GameObject playerCharacter;
    [SerializeField] ObstcaleSpawner inGameSpawner;
    [SerializeField] Rigidbody player;
   
    [SerializeField] float movementSpeed = 20f;

    // private

    private bool _gameStart = false;

    public static float _hp = 100f;
    private float _hMovement;
    private float _vMovement;

    private int _score;

    // same order for methoeds

    public bool GetGameStart()
    {
        return _gameStart;
    }

    /// <summary>
    /// left<0>Right
    /// </summary>
    /// <returns></returns>
    public float GetHMovement()
    {
        return _hMovement;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_gameStart)
        {
            if (player.position.x > 30)
            {
                inGameSpawner.enabled = true;
            }

            // Movement
            _hMovement = Input.GetAxis("Horizontal") * (movementSpeed / 2);
            _vMovement = Input.GetAxis("Vertical") * movementSpeed;

            if (_vMovement <= 5)
            {
                _vMovement = 5;
            }

            if (PauseDeathMenu.CanPlayerMove())
            {
                transform.Translate(new Vector3(_vMovement, 0f, _hMovement * -1) * Time.deltaTime);
            }

            _score = (int)player.position.x;
        }

        if (Input.GetKey(KeyCode.W) == true) { _gameStart = true; }
    }

    
}
