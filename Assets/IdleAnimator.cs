using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleAnimator : StateMachineBehaviour
{
    private int rand;
    public string primeiro;
    public string segundo;

    // OnStateEnter is called before OnStateEnter is called on any state inside this state machine
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rand = Random.Range(0, 2);
        if (rand == 0)
        {

            animator.SetTrigger(primeiro);
        }
        else if(rand == 1)
        {
            
            animator.SetTrigger(segundo);
        }
    }

    // OnStateUpdate is called before OnStateUpdate is called on any state inside this state machine
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    // OnStateExit is called before OnStateExit is called on any state inside this state machine
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
