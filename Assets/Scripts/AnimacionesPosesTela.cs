using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionesPosesTela : StateMachineBehaviour
{
    public int pose;
    private NivelControl nivelControl = null;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        nivelControl = GameObject.FindGameObjectWithTag("ControlNivel").GetComponent<NivelControl>();

        if (pose == 1)
        {
            nivelControl.tela_objeto1.SetActive(true);
        }
        else if (pose == 2)
        {
            nivelControl.tela_objeto2.SetActive(true);
        }
        else if (pose == 3)
        {
            nivelControl.tela_objeto3.SetActive(true);
        }



    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if (pose == 1)
        {
            nivelControl.tela_objeto1.SetActive(false);
        }
        else if (pose == 2)
        {
            nivelControl.tela_objeto2.SetActive(false);
        }
        else if (pose == 3)
        {
            nivelControl.tela_objeto3.SetActive(false);
        }
        //nivelControl.animacion_tela.SetInteger("diamante", 1);
    }

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
