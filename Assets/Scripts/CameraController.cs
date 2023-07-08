using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform targetToFollow;
    public Vector3 offset;
    public float pitch = 2f;
    public float zoomSpeed = 6f;
    public float minZoom = 5f;
    public float maxZoom = 13f;

    //to the rotation
    public float yawSpeed = 100f;

    private float currentZoom = 10f;
    private float yawInput = 0f;

    // Update is called once per frame
    void Update(){
        //to change the zoom properties
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

        yawInput -= Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;
    }

    void LateUpdate(){
        //to follow the player
        transform.position = targetToFollow.position - offset * currentZoom;
        transform.LookAt(targetToFollow.position + Vector3.up * pitch);
        transform.RotateAround(targetToFollow.position, Vector3.up, yawInput);
    }
}
