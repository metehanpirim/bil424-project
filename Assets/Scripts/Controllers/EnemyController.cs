using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Quaternion = UnityEngine.Quaternion;

public class EnemyController : MonoBehaviour
{
    Transform target;
    NavMeshAgent agent;
    public float lookRadius = 10f;
    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if(distance <= lookRadius)
        {
            agent.SetDestination(target.position);
            if(distance <= agent.stoppingDistance)
            {
                FaceTarget();
            }
        }
    }

    void FaceTarget()
    {
        UnityEngine.Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookrotation = Quaternion.LookRotation(new UnityEngine.Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookrotation, Time.deltaTime*5f);
    }

    private void OnDrawGizmosSelected()
    { 
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
