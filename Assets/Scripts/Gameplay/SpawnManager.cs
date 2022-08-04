using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
   private RunwaySpawner runwaySpawner;

    public void SpawnTriggerEntered()
    {
        runwaySpawner.MoveRunways();
    }
    // Start is called before the first frame update
    void Start()
    {
        runwaySpawner = GetComponent<RunwaySpawner>();
    }

}
