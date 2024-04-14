using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CatMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float stopDistance = 1f;
    // public Animator animator; // Animator component for animations

    private Transform target;

    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    void Update()
    {
        if (target != null)
        {
            Debug.Log("trying to update");
            // Calculate distance to target
            float distance = Vector3.Distance(transform.position, target.position);

            // Move towards target if not within stop distance
            if (distance > stopDistance)
            {
                MoveTowardsTarget();
            }
            else
            {
                StopMovement();
                StartEating();
            }
        }
    }

    void MoveTowardsTarget()
    {
        Vector3 direction = target.position - transform.position;
        direction.Normalize();

        transform.Translate(direction * moveSpeed * Time.deltaTime);

        // Update animation to walking
        // animator?.SetBool("IsWalking", true);
    }

    void StopMovement()
    {
        // transform.rotation = Quaternion.LookRotation(target.position - transform.position); // Face the target
        moveSpeed = 0f;

        // Update animation to idle
        // animator?.SetBool("IsWalking", false);
    }

    void StartEating()
    {
        // Update animation to eating
        // animator?.SetBool("IsEating", true);
    }
}

