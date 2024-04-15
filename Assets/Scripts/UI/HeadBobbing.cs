using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBobbing : MonoBehaviour
{
    public Transform headTransform; // Reference to the head game object (child)
    private Vector3 initialHeadPosition;
    public float bobSpeed = 1.0f; // Speed of the head bobbing animation
    public float bobAmount = 0.01f; // Amount of vertical movement for the head

    private float timer = 0.0f;

    void Start()
    {
        // Assuming the head is the first child of the prefab
        headTransform = transform.GetChild(0);
        initialHeadPosition = headTransform.localPosition; // Store initial position
    }

    void Update()
    {
        timer += Time.deltaTime * bobSpeed;
        float bobOffset = Mathf.Sin(timer) * bobAmount;

        if (name == "SiameseCat Variant(Clone)")
        {
            // Apply bobbing offset to the initial y position
            headTransform.localPosition = new Vector3(initialHeadPosition.x + bobOffset,
                                                      headTransform.localPosition.y,
                                                      headTransform.localPosition.z);
        }

        // Apply bobbing offset to the initial y position
        headTransform.localPosition = new Vector3(headTransform.localPosition.x,
                                                  initialHeadPosition.y + bobOffset,
                                                  headTransform.localPosition.z);
    }
}
