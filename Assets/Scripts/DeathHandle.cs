using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandle : MonoBehaviour
{
    [SerializeField] Canvas endCanvas;

    private void Start()
    {
        //When we start canvas is off, prevents menu on screen
        endCanvas.enabled = false;
    }

    public void DeathHandler()
    {
        //Show main menu when we die, YOUDIED!
        endCanvas.enabled = true;
        //Stops the time, fixes game vs cursor fighting over 
        Time.timeScale = 0;
        
        //Allowing free cursor on screen Not Locked
        Cursor.lockState = CursorLockMode.None;
        //show cursor
        Cursor.visible = true;

        //Stop weap switch when dead
        FindObjectOfType<PickWeapon>().enabled = false;
    }



}
