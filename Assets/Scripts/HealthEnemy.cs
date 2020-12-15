using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEnemy : MonoBehaviour
{
    [SerializeField] float hitPoint = 100f;

    bool isKilled = false;

    public bool IsKilled()
    {
        return isKilled;
    }
    public void DamageTaken(float damage)
    {
        //Messages
        BroadcastMessage("OnBully");
        hitPoint -= damage;
        if(hitPoint <= 0)
        {
            Death();
        }

    }
    private void Death()
    {
        if(isKilled)
        {
            return;
        }
        //check if dead or not
        isKilled = true;
        //PLAY falling back anim
        GetComponent<Animator>().SetTrigger("DEATH");
    }
}
