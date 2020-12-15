using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float gunrange = 100f;
    [SerializeField] float damage = 30;
    [SerializeField] TextMeshProUGUI chargeText;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] WeaponCharge chargeStatus;
    [SerializeField] ChargeTypes chargeTypes;
    [SerializeField] float cooldownShoot = 0.5f;

    bool allowShoot = true;
    private void OnEnable()
    {
        allowShoot = true;
    }

    void Update()
    {
        DisplayCharge();
        if (Input.GetMouseButtonDown(0) && allowShoot == true)
        {
            StartCoroutine(Shoot());
        }

    }

    private void DisplayCharge()
    {
        int currentCharge = chargeStatus.GetCurrentCharge(chargeTypes);
        chargeText.text = currentCharge.ToString();
    }
    IEnumerator Shoot()
    {
        allowShoot = false;
        if (chargeStatus.GetCurrentCharge(chargeTypes) > 0)
        {
            MuzzleFlashPlay();
            RaycastProcess();
            chargeStatus.DepleteCharge(chargeTypes);
        }
        yield return new WaitForSeconds(cooldownShoot);
        allowShoot = true;
    }

    private void MuzzleFlashPlay()
    {
        muzzleFlash.Play();
    }

    private void RaycastProcess()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, gunrange))
        {
            HitImpact(hit);
            HealthEnemy target = hit.transform.GetComponent<HealthEnemy>();
            if (target == null)
            {
                return;
            }
            target.DamageTaken(damage);
        }
        else
        {
            return; //Returning this fixes the null reference error we get when we shoot the skybox 
        }
    }

    private void HitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffect,hit.point,Quaternion.LookRotation(hit.normal));
        Destroy(impact, .1f);
    }
}
