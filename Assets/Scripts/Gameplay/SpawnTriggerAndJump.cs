using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnTriggerAndJump : MonoBehaviour
{

    public UnityEvent boxAdded;

    public GameObject DeathUi;//
    // SpawnRelated
    public SpawnManager spawnManager;//
    GameObject GetParent;
    public static bool playerDead = false;

    // HP Related
    public static float hp = 100f;

    // Jump Related
    private Rigidbody penguinPlayer;//
    private float jumpForce = 6f;//
    private bool groundCheck;//
    private int reward = 0;

  
    public void AddReward()
    {
        reward++;
    }

    public int GetReward()
    {
        return reward;
    }
    // Start is called before the first frame update
    void Start()//
    {
        penguinPlayer =  GetComponent<Rigidbody>();
        groundCheck = true;
    }
    // Update is called once per frame
    void Update()//
    {
        if (groundCheck == true && Input.GetButton("Jump"))
        {
            penguinPlayer.velocity = new Vector3(0f, jumpForce, 0f);
            groundCheck = false;
        }
        if (hp <= 0f)
        {
            DeathSequence();
        }
    }
    void DeathSequence()
    {
        PauseDeathMenu.IsPlayerDead = true;
        DeathUi.SetActive(true);
    }
    private void OutOfBoundSeq()
    {
        PauseDeathMenu.Restart();
        Debug.Log("Out Of Bound Initiated");
    }
    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "OutOfBound":
                OutOfBoundSeq();
                break;
            case "Reward":
                boxAdded.Invoke();
                Destroy(other.transform.parent.gameObject);
                break;
            default:
                spawnManager.SpawnTriggerEntered();
                break;
        }
        //spawnManager.SpawnTriggerEntered();
        //if (other.tag == "OutOfBound");
    }
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Ground":
                groundCheck = true;
                break;
            case "Enemy":
                HpReduce();
              break;                
        }
    }
    private void HpReduce()
    {

        if (hp <= 0)
        {
            hp = 0;
            DeathSequence();
        }
        else
        {
            hp -= 25;
        }
        Debug.Log(hp);
    }
}

