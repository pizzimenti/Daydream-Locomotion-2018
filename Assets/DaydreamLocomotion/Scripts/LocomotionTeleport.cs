using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocomotionTeleport : MonoBehaviour
{
    public float teleportRange = 75.0f;
    public GameObject teleportTargetPrefab;
    private GameObject teleportTarget;

    private LineRenderer laser;
    private Vector3 beamOrigin;
    private Vector3 beamDirection;

    private Vector3 targetPosition;
    private bool isTeleportable;
    private bool isInstantiatedTeleportPrefab;

    // Use this for initialization
    void Start()
    {
        laser = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GvrControllerInput.ClickButton)
            TeleportPrep();

        if (GvrControllerInput.ClickButtonUp)
            TeleportEngage();
    }

    // Actions to perform while user is selecting a destination
    private void TeleportPrep()
    {
        beamOrigin = GameObject.Find("Laser").transform.position;
        beamDirection = GameObject.Find("Laser").transform.forward;

        targetPosition = CalcDestination(beamOrigin, beamDirection, teleportRange);
        ShineLaser();
    }

    private void TeleportEngage()
    {
        laser.enabled = false;
        Destroy(teleportTarget);
        isInstantiatedTeleportPrefab = false;
        if (isTeleportable) transform.position = targetPosition;
    }


    private Vector3 CalcDestination(Vector3 laserOrigin, Vector3 laserDirection, float range)
    {
        Ray ray = new Ray(laserOrigin, laserDirection);
        RaycastHit raycastHit;

        // Check to see if pointed at valid destination and in range
        if (Physics.Raycast(ray, out raycastHit, range))
        {
            GameObject targetObject = raycastHit.transform.gameObject;
            if (targetObject.tag == "Terrain") isTeleportable = true;
            else isTeleportable = false;
            return raycastHit.point;
        }
        else
        {
            isTeleportable = false;
            return beamOrigin + (teleportRange * beamDirection);
        }
    }

    // Render laser beam
    private void ShineLaser()
    {
        if (!laser.enabled) laser.enabled = true;   // If line renderer is not already on, enable it
        if (isTeleportable)
        {
            laser.startColor = Color.green;
            laser.endColor = Color.green;
            if (!isInstantiatedTeleportPrefab)
            {
                teleportTarget = Instantiate(teleportTargetPrefab);
                isInstantiatedTeleportPrefab = true;
            }
            teleportTarget.transform.position = targetPosition + new Vector3(0, 1, 0);
        }
        else // Beam is either striking a non-terrain object or is striking nothing
        {
            laser.startColor = Color.red;
            laser.endColor = Color.red;
            if (isInstantiatedTeleportPrefab)
            {
                Destroy(teleportTarget);
                isInstantiatedTeleportPrefab = false;
            }
        }

        laser.SetPosition(0, beamOrigin);
        laser.SetPosition(1, targetPosition);
    }
}