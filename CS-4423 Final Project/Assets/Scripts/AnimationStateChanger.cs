using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateChanger : MonoBehaviour
{

    [SerializeField] Animator animator;
    [SerializeField] string currentState = "Idle";



    
    // Start is called before the first frame update
    void Start()
    {
        ChangeAnimationState(currentState);
    }

    public void ChangeAnimationState(string newAnimationState)
    {
        if(newAnimationState == currentState)
        {
            return;
        }

        currentState = newAnimationState;
        animator.Play(newAnimationState);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
