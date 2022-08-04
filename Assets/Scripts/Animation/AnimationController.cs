using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
   
    Animator animator;
    
    PlayerController playerController;
    [SerializeField] GameObject player;

    private void Awake()
    {
        playerController = player.GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.GetGameStart() == true)
        {
            animator.SetBool("IsStarted", true);
            animator.SetBool("IsIdle", false);
        }

        if (playerController.GetHMovement() > 0)
        {
            animator.SetBool("RightTurn", true);
            animator.SetBool("LeftTurn", false);
        }
        else if(playerController.GetHMovement() < 0)
        {
            animator.SetBool("LeftTurn", true);
            animator.SetBool("RightTurn", false);
        }
        else
        {
            animator.SetBool("LeftTurn", false);
            animator.SetBool("RightTurn", false);
        }
    }
}
