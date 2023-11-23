using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    private Animator animator;
    
    public string animationState;
    public KeyCode keyTrigger = KeyCode.Space;
    public float transitionSeconds = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
        if (animator == null)
            animator = gameObject.GetComponent<Animator>();

        if (animator == null)
            Debug.LogWarning("Please add an animator component on "+gameObject);
        else
        {
            if(animationState != "")
            {
                int stateId = Animator.StringToHash(animationState);
                if(animator.HasState(0, stateId) == false)
                {
                    Debug.LogWarning("I can't find no animation state called "+ animationState);
                }

            }
            else
            {
                Debug.LogWarning("Please specify the name of the animation in animationState");
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(animator == null)
        {
            Debug.LogWarning("Please add an animator component");
        }
        else if (Input.GetKeyDown(keyTrigger))
        {
            animator.CrossFadeInFixedTime(animationState, transitionSeconds);
        }
        


    }
}
