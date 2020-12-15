using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    HealthPlayer tgt;
    [SerializeField] float dmg = 40f;



    // Start is called before the first frame update
    void Start()
    {
        tgt = FindObjectOfType<HealthPlayer>();
    }


//   A way to announce when enemy takes dmg
//    public void OnBully()
//    {
//        Debug.Log(name + "I also know u took damage");
//    }

    public void HitEvent()
    {
        if (tgt == null) return;
        tgt.DamageTaken(dmg);
        tgt.GetComponent<BloodScreen>().ShowHitImpact();
    }

}
