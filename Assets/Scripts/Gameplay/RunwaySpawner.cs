using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RunwaySpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> runways;

    private float offset = 60f;

    public void MoveRunways()
    {
        GameObject moveRunway = runways[0];
        runways.Remove(moveRunway);
        float newX = runways[runways.Count - 1].transform.position.x + offset;
        moveRunway.transform.position = new Vector3(newX, 0, 0);
        runways.Add(moveRunway);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (runways != null && runways.Count > 0)
        {
            runways = runways.OrderBy(r => r.transform.position.x).ToList();
        }
    }
}
