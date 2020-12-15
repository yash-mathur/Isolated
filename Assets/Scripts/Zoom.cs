using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Zoom : MonoBehaviour
{
    [SerializeField] Camera fpsCam;
    [SerializeField] float zoomOut = 60f;
    [SerializeField] float zoomIn = 30f;
    [SerializeField] float zoomOutSensi = 2f;
    [SerializeField] float zoomInSensi = 0.5f;
    //From unity's rigid body default script
    [SerializeField] RigidbodyFirstPersonController fpsControl;

    bool zoomToggle = false;

    private void OnDisable()
    {
        ZoomingOut();
    }

    private void Update()
    {
        //When user presses down right mouse btn, zoom it, if he presses it again zoom out ie normal view
        if(Input.GetMouseButtonDown(1))
        {
            if (zoomToggle == false)
            {
                ZoomingIn();
            }
            else
            {
                ZoomingOut();
            }
        }
    }

    private void ZoomingOut()
    {
        zoomToggle = false;
        fpsCam.fieldOfView = zoomOut;
        fpsControl.mouseLook.XSensitivity = zoomOutSensi;
        fpsControl.mouseLook.YSensitivity = zoomOutSensi;
    }

    private void ZoomingIn()
    {
        zoomToggle = true;
        fpsCam.fieldOfView = zoomIn;
        fpsControl.mouseLook.XSensitivity = zoomInSensi;
        fpsControl.mouseLook.YSensitivity = zoomInSensi;
    }
}
