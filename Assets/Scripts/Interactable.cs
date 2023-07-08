using UnityEngine;


//base class for all interactable objects
public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    public Transform interactionTransform;

    bool isFocus = false;
    Transform player;
    bool hasInteracted = false;

    private void Update()
    {
        if (isFocus && !hasInteracted){

            float distance = Vector3.Distance(interactionTransform.position, player.position);

            if (distance <= radius){
                Interact();
                hasInteracted =true;
            }
        }
    }

    //overwritable method for the classes which are inherited from this class
    public virtual void Interact(){

        //Default action when the method is not overwrited
        Debug.Log("INTERACT");
    }

    public void OnFocus(Transform playerTransform){
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }

    public void OnRemoveFocus(){
        isFocus = false;
        player = null;
        hasInteracted = false;
    }

    private void OnDrawGizmosSelected(){
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}
