using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateChanger : MonoBehaviour
{

    [SerializeField] Animator animator;
    [SerializeField] string currentState = "Idle";



    public void ChangeAnimationState(string newAnimationState)
    {
        currentState = newAnimationState;
        animator.Play(newAnimationState);
    }
    // Start is called before the first frame update
    void Start()
    {
        ChangeAnimationState(currentState);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
