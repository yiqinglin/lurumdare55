using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CatMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float stopDistance = 1f;
    // public Animator animator; // Animator component for animations
    [SerializeField] private float delayTime = 3.0f; // Time in seconds before enabling the object
    public MonoBehaviour bobbingScript;
    private Transform target;
    private bool _stopped;

    void Start()
    {

        if (bobbingScript != null)
        {
            bobbingScript.enabled = false;
        }
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    void Update()
    {
        if (_stopped)
        {
            return;
        }
        if (target != null)
        {
            // Calculate distance to target
            float distance = Vector3.Distance(transform.position, target.position);

            // Move towards target if not within stop distance
            if (distance > stopDistance)
            {
                MoveTowardsTarget();
            }
            else
            {
                _stopped = true;
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

        CatManager.Instance.doneWalking += 1;

        // Update animation to idle
        // animator?.SetBool("IsWalking", false);
    }

    void StartEating()
    {
        // Update animation to eating

        if (bobbingScript != null)
        {
            bobbingScript.enabled = true;
        }
    }
}

