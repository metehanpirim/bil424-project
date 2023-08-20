using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimalController : MonoBehaviour
{
    // Start is called before the first frame update
    public float lookRadius =10f;
    Transform target;
    NavMeshAgent agent;
    void Start()
    {
        target=PlayerManager.instance.player.transform;
        agent=GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance=Vector3.Distance(target.position,transform.position);
        if(distance <=lookRadius){
            Vector3 dirToPlayer=transform.position-target.position;
            Vector3 newPos=transform.position+dirToPlayer;
            agent.SetDestination(newPos);
        }
        
    }
    void OnDrawGizmosSelected(){
        Gizmos.color=Color.red;
        Gizmos.DrawWireSphere(transform.position,lookRadius);

    }
}
