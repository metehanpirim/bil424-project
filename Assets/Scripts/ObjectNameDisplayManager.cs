using TMPro;
using UnityEngine;

public class ObjectNameDisplayManager : MonoBehaviour
{
    private Camera mainCamera;
    public TMP_Text label;


    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            GameObject hitObject = hit.collider.gameObject;
            //Debug.Log("Üzerinde bulunan nesnenin ismi: " + hitObject.name);
            label.text = hitObject.name;
        }
        else
        {
            label.text = "";
        }
    }
}
