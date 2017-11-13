using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerAnimation : MonoBehaviour
{

    private Animator animator;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void attackOne(bool isAttacking)
    {
        animator.Play("lightAttack");
    }

    public void attackTwo(bool isAttacking)
    {
        animator.Play("heavyAttack");
    }

    public void lightHit()
    {
        animator.Play("lightHit");
    }

    public void blocking()
    {
        animator.SetBool("blocking", true);
        animator.SetBool("walkingForward", false);
        animator.SetBool("walkingBackward", false);
        animator.SetBool("walkingRight", false);
        animator.SetBool("walkingLeft", false);
        animator.SetBool("isIdle", false);
    }

    public void unBlocking()
    {
        animator.SetBool("blocking", false);
        animator.SetBool("walkingForward", false);
        animator.SetBool("walkingBackward", false);
        animator.SetBool("walkingRight", false);
        animator.SetBool("walkingLeft", false);
        animator.SetBool("isIdle", true);
    }

    public void blockingImpact()
    {
        animator.Play("blockImpact");
    }
    public void death()
    {
        animator.Play("death");
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
        animator.SetFloat("movementSpeed", speed);
        animator.SetBool("isIdle", false);
        animator.SetBool("walkingForward", true);
        animator.SetBool("walkingBackward", false);
        animator.SetBool("walkingRight", false);
        animator.SetBool("walkingLeft", false);
    }

    public void walkBackward(float zIn, float speed)
    {
        animator.SetFloat("movementSpeed", speed);
        animator.SetBool("isIdle", false);
        animator.SetBool("walkingForward", false);
        animator.SetBool("walkingBackward", true);
        animator.SetBool("walkingRight", false);
        animator.SetBool("walkingLeft", false);
    }
    public void walkLateral(float xIn, float speed)
    {
        animator.SetFloat("movementSpeed", speed);
        animator.SetBool("isIdle", false);
        animator.SetBool("walkingForward", false);
        animator.SetBool("walkingBackward", false);

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
