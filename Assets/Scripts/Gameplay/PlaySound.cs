using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public AudioSource IceSkating;

    public void SkatingSound()
    {
        IceSkating.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) == false)
        {
            SkatingSound();
        }
    }
}
