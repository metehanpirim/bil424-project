using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine.EventSystems;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{

    public LayerMask layermask;
    public Interactable focus;

    Camera cam;
    PlayerMotor playerMotor;


    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main; 
        playerMotor = GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        //left click
        if (Input.GetMouseButtonDown(0)){

            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 100, layermask)){
                Debug.Log("Raycast hit " + hit.collider.name + " : " + hit.point);

                playerMotor.MoveToPoint(hit.point);

                RemoveFocus();
            }
        }

        //right click
        else if (Input.GetMouseButtonDown(1))
        {

            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();

                if (interactable != null)
                {
                    SetFocus(interactable);
                }
            }
        }

    }

    void SetFocus(Interactable newFocus){

        if (newFocus != focus){
            if(focus != null)
                focus.OnRemoveFocus();

            focus = newFocus;
            playerMotor.FollowTarget(newFocus);
        }
        newFocus.OnFocus(transform);
    }

    void RemoveFocus(){

        if (focus != null)
            focus.OnRemoveFocus();

        focus = null;
        playerMotor.StopFollowingTarget();
    }
}
