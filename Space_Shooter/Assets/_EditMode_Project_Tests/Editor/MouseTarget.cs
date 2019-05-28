using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTarget : MonoBehaviour
{
    private Camera mainCamera;
    
    void Start()
    {
        mainCamera = FindObjectOfType<Camera>();
    }

    void Update()
    {
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            //Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);

            //transform.LookAt(pointToLook);
            transform.LookAt(new Vector3 (pointToLook.x, transform.position.y, pointToLook.z));
            // got this from here: https://www.youtube.com/watch?v=lkDGk3TjsIE&pbjreload=10
        }
    }
}
