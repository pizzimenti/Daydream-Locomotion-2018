using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocomotionWalking : MonoBehaviour
{
    [Range(0f, 0.3f)]
    public float walkingSpeed = 0.15f; // speed of overall movement with 0.15 being close to walking speed
    [Range(0f, 1f)]
    public float strafeSpeed = 0.75f; // speed of side-to-side movement as a percentage of walkingSpeed

    // Update is called once per frame
    void Update()
    {
        if (GvrControllerInput.ClickButton) return;  // Prevents walking while user prepares to teleport
        if (GvrControllerInput.IsTouching)  Walk();
    }

    private void Walk()
    {
        Vector2 touchCoords = GvrControllerInput.TouchPos;   // gather user thumb position

        if (touchCoords.x > 0.6f || // don't move if user thumb is relatively centered
            touchCoords.x < 0.4f ||
            touchCoords.y > 0.6f ||
            touchCoords.y < 0.4f )
        {
            transform.position += Camera.main.transform.forward * (-touchCoords.y + 0.5f) * walkingSpeed;
            transform.position += Camera.main.transform.right * (touchCoords.x - 0.5f) * walkingSpeed * strafeSpeed;
        }
    }
}