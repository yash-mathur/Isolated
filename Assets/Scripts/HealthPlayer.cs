using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlayer : MonoBehaviour
{
    [SerializeField] float hitPoint = 100f;

    public void DamageTaken(float damage)
    {
        hitPoint -= damage;
        if (hitPoint <= 0)
        {
            GetComponent<DeathHandle>().DeathHandler();
        }

    }
}
