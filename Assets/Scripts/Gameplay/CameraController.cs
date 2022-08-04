using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject playerObj;

    private Transform player;

    private float xOffset = -3f;
    private float yOffset = 1.08f;

    // Start is called before the first frame update
    void Start()
    {
        player = playerObj.GetComponent<Transform>();
    }
    // Late Update is called once per frame, if enabled
    void LateUpdate()
    {
        transform.position = new Vector3(player.position.x + xOffset, player.position.y + yOffset, player.position.z);
    }
}
