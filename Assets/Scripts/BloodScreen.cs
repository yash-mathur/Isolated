using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodScreen : MonoBehaviour
{
    [SerializeField] Canvas hitCanvas;
    [SerializeField] float hitTime = 0.3f;

    private void Start()
    {
        hitCanvas.enabled = false;
    }

    public void ShowHitImpact()
    {
        StartCoroutine(ShowBlood());
    }

    IEnumerator ShowBlood()
    {
        hitCanvas.enabled = true;
        yield return new WaitForSeconds(hitTime);
        hitCanvas.enabled = false;
    }
}
