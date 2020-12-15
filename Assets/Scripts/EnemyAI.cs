using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float trnSpeed = 5f;
    //range is in unity units, rangeChase = if player in range it activate
    [SerializeField] float rangeChase = 7f;


    NavMeshAgent navMeshAgent;
    float disTgt = Mathf.Infinity;
    //Provoked yes/no, is chilling by default
    bool isbullied = false;
    HealthEnemy health;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        health = GetComponent<HealthEnemy>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health.IsKilled())
        {
            //If dead turn off this component, have to stop navmesh too
            enabled = false;
            navMeshAgent.enabled = false;
        }
        //Calculate the actual distance on every update
        disTgt = Vector3.Distance(target.position, transform.position);
        if (isbullied)
        {
            crgTgt();
        }
        else if (disTgt <= rangeChase)  // If player comes in , chase
        {
            isbullied = true;
            //if player shoots 
            //
        }
    }
    //what charging actually is
    private void crgTgt()
    {
        faceTgt();
        if (disTgt >= navMeshAgent.stoppingDistance)
        {
            flwTgt();
        }

        if (disTgt <= navMeshAgent.stoppingDistance)
        {
            atkTgt();
        }
    }

    public void OnBully()
    {
        isbullied = true;
    }

    private void flwTgt()
    {
        GetComponent<Animator>().SetBool("ATTACK", false);
        GetComponent<Animator>().SetTrigger("MOVE");
        navMeshAgent.SetDestination(target.position);
    }

    private void atkTgt()
    {
        GetComponent<Animator>().SetBool("ATTACK", true);
        Debug.Log(name + "HIT! HIT!  HIT! on" + target.name);
    }

    private void faceTgt()
    {
        Vector3 dir = (target.position - transform.position).normalized;
        Quaternion lookRot = Quaternion.LookRotation(new Vector3(dir.x, 0, dir.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, Time.deltaTime * trnSpeed);

    }

    private void OnDrawGizmosSelected()
    {
        //Draw a wire mesh around enemy, good for dev
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, rangeChase);
    }

}
