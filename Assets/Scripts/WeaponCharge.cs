using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCharge : MonoBehaviour
{

    [SerializeField] ChargeSlot[] chargeSlots;
    [System.Serializable] 
    private class ChargeSlot
    {
        public ChargeTypes chargeTypes;
        public int chargeAmt;
    }


    public int GetCurrentCharge(ChargeTypes chargeTypes)
    {
        return GetChargeSlot(chargeTypes).chargeAmt;
    }

    public void DepleteCharge(ChargeTypes chargeTypes)
    {
        GetChargeSlot(chargeTypes).chargeAmt --;
    }
    public void ReplenishCharge(ChargeTypes chargeTypes, int chargeAmt)
    {
        GetChargeSlot(chargeTypes).chargeAmt += chargeAmt;
    }

    private ChargeSlot GetChargeSlot(ChargeTypes chargeTypes)
    {
        foreach(ChargeSlot slot in chargeSlots)
        {
            if(slot.chargeTypes == chargeTypes)
            {
                return slot;
            }
        }
        return null;
    }
}
