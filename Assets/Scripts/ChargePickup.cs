using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargePickup : MonoBehaviour
{
    [SerializeField] ChargeTypes chargeTypes;
    [SerializeField] int chargeAmount = 5;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("TRIGGERED!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            FindObjectOfType<WeaponCharge>().ReplenishCharge(chargeTypes, chargeAmount);
            Destroy(gameObject);
        }
    }
}
