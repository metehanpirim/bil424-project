using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.AI;//for navmesh

//to adding navmeshagent automatically
[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour
{
    NavMeshAgent agent;        //reference to navmesh agent coming from RequireComponent
    Transform target;          //target to follow

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //update destination at each frame and follow continuously
        if (target != null){
            agent.SetDestination(target.position);
            FaceTarget();
        }
    }

    public void MoveToPoint(Vector3 targetPoint){

        agent.SetDestination(targetPoint);
    }

    public void FollowTarget(Interactable newTarget){

        agent.stoppingDistance = newTarget.radius * 0.75f;
        agent.updateRotation = false;
        target = newTarget.interactionTransform; 
    }

    public void StopFollowingTarget()
    {
        agent.stoppingDistance = 0;
        agent.updateRotation = true;
        target = null;
    }

    public void FaceTarget(){

        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 6f);
    }
}
