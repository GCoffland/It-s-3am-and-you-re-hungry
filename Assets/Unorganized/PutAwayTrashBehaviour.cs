﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutAwayTrashBehaviour : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Events.getEventByType(typeof(CardboardBoxInteractEvent)).occured)
        {
            GameObject.Find("TrashCanLid").GetComponent<Animator>().Play("LidFlip");
            SoundEffectPlayer.instance.Play("Sounds/SoundEffects/TrashCanUse");
            animator.transform.GetChild(2).GetComponent<SpriteRenderer>().color = Color.clear;
            animator.Play("RunAway");
            SoundEffectPlayer.instance.Play("Sounds/SoundEffects/Scream");
            /*
            animator.transform.GetChild(1).GetComponent<Animator>().Play("ShowExclamation");
            animator.Play("RunAway");
            SoundEffectPlayer.instance.Play("Sounds/SoundEffects/Scream");
            */
        }
        else
        {
            GameObject.Find("TrashCanLid").GetComponent<Animator>().Play("LidFlip");
            SoundEffectPlayer.instance.Play("Sounds/SoundEffects/TrashCanUse");
            animator.Play("GoBack");
            GameObject.Find("TrashCanLid").GetComponent<Animator>().Play("FlipClosed");
            animator.transform.GetChild(2).GetComponent<SpriteRenderer>().color = Color.clear;
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
