using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    [SerializeField] float lightFade = 0.1f;
    [SerializeField] float angleFade = 0.1f;
    [SerializeField] float minAngle = 40f;

    Light flashLight;

    private void Start()
    {
        flashLight = GetComponent<Light>();

    }

    private void Update()
    {
        LowerAngle();
        LowerBrightness();
    }

    public void AddAngle(float chargeAngle)
    {
        flashLight.spotAngle = chargeAngle;
    }


    private void LowerAngle()
    {
        if (flashLight.spotAngle <= minAngle)
        {
            return;
        }
        else
        {
            flashLight.spotAngle = flashLight.spotAngle - angleFade * Time.deltaTime;
        }
        
    }

    private void LowerBrightness()
    {
        flashLight.intensity = flashLight.intensity - lightFade * Time.deltaTime;
    }

    public void AddLight(float chargeLight)
    {
        flashLight.intensity = flashLight.intensity + chargeLight;
    }

}
