using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightChargePickup : MonoBehaviour
{
    [SerializeField] float fillAngle = 90f;
    [SerializeField] float addCharge = 1f;

    private void OnTriggerEnter(Collider other)
    {
        //other is the player, getting a component in children of the player
        if(other.gameObject.tag == "Player")
        {
            other.GetComponentInChildren<FlashLight>().AddAngle(fillAngle);
            other.GetComponentInChildren<FlashLight>().AddLight(addCharge);
            Destroy(gameObject);

        }
    }
}
