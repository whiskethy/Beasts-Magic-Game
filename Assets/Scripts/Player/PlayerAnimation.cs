using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {
    
    private Animator animator;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
    }

    public void attackOne(bool isAttacking)
    {
      animator.SetBool("attackOne", isAttacking);
    }

    //universal overload is being supplied ...
    public void walk(float xIn, float yIn, float zIn, float speed)
    {
        if (zIn > 0.0f)
        {
            animator.SetBool("walkingForward", true);
            animator.SetBool("isIdle", false);
        }

    }

    //walk vector overload. How to remove conditional checks? ... 
    public void walk(Vector3 InputDirection, float speed)
    {

        if (Equals(InputDirection.x, 0.0f) && Equals(InputDirection.y, 0.0f) && Equals(InputDirection.z, 0.0f))
        {
            stopWalking();
        }

        if (InputDirection.z > 0.0f)
        {
            walkForward(InputDirection.z, speed);
        }
        if (InputDirection.z < 0.0f)
        {
            walkForward(InputDirection.z, speed);
        }

    }


    //... but multiple functions removes conditionals at runtime if used properly
    public void stopWalking()
    {
        animator.SetBool("walkingForward", false);
        animator.SetBool("walkingBackward", false);
        animator.SetBool("walkingRight", false);
        animator.SetBool("walkingLeft", false);
        animator.SetBool("isIdle", true);
    }
    public void walkForward(float zIn, float speed)
    {
        animator.SetBool("walkingForward", true);
        animator.SetBool("walkingBackward", false);
        animator.SetFloat("movementSpeed", speed);
        animator.SetBool("isIdle", false);
        animator.SetBool("walkingRight", false);
    }

    public void walkBackward(float zIn, float speed)
    {
        animator.SetBool("walkingBackward", true);
        animator.SetBool("walkingForward", false);
        animator.SetFloat("movementSpeed", speed);
        animator.SetBool("isIdle", false);
        animator.SetBool("walkingRight", false);
    }
    public void walkLateral(float xIn, float speed)
    {
        animator.SetBool("walkingForward", false);
        animator.SetBool("walkingBackward", false);
        animator.SetFloat("movementSpeed", speed);
        animator.SetBool("isIdle", false);

        if (xIn > 0)
        {
            animator.SetBool("walkingRight", true);
            animator.SetBool("walkingLeft", false);
        }

        if (xIn < 0)
        {
            animator.SetBool("walkingRight", false);
            animator.SetBool("walkingLeft", true);
        }
    }


}
