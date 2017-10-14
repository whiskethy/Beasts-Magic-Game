using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

    private Animator animator;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
    }

    //universal overload is being supplied ...
    public void walk(float xIn, float yIn, float zIn)
    {
        if (zIn > 0.0f)
        {
            animator.SetBool("isWalkingForward", true);
        }
        
    }
    //... but multiple functions removes conditionals at runtime if used properly
    public void stopWalking()
    {
        animator.SetBool("isWalkingForward", false);
    }
    public void walkForward(float zIn)
    {
        animator.SetBool("isWalkingForward", true);
    }

    public void walkBackward(float zIn)
    {
        
    }
    public void walkLateral(float xIn)
    {
        
    }

    //walk vector overload. How to remove conditional checks? ... 
    public void walk(Vector3 InputDirection)
    {

        if ((InputDirection.x == 0.0f) &&(InputDirection.y == 0.0f) && (InputDirection.z == 0.0f))
        {
            animator.SetBool("isWalkingForward", false);
        }

        if (InputDirection.z > 0.0f)
        {
            animator.SetBool("isWalkingForward", true);
        }

    }
}
