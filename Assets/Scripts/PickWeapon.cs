using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PickWeapon : MonoBehaviour
{
    [SerializeField] int curWeap = 0;

    private void Start()
    {
        ActiveWeapon();
    }

    private void ActiveWeapon()
    {
        int weaponIdx = 0;

        foreach (Transform weapon in transform)
        {
            if(weaponIdx == curWeap)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            weaponIdx = weaponIdx + 1;
        }
    }

    private void Update()
    {
        int prevWeap = curWeap;

        KeyInput();
        ScrollWheel();

        if (prevWeap != curWeap)
        {
            ActiveWeapon();
        }

    }

    private void ScrollWheel()
    {
        if (Input.GetAxis("Mouse ScrollWheel") >0)
        {
            //if we already at 2, loop to 0 (-1 for correct index as we start at 0)
            if(curWeap >= transform.childCount -1)
            {
                curWeap = 0;
            }
            else
            {
                curWeap = curWeap + 1;
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            //if we already at 2, loop to 0 (-1 for correct index as we start at 0)
            if (curWeap <= 0)
            {
                curWeap = transform.childCount -1;
            }
            else
            {
                curWeap = curWeap - 1;
            }
        }
    }

    private void KeyInput()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            curWeap = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            curWeap = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            curWeap = 2;
        }

    }
}

