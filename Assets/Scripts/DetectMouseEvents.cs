using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DetectMouseEvents : MonoBehaviour
{
    private void OnMouseDown()
    {
        Vector3 mouseScreenPos = Input.mousePosition;
        // Debug.Log("Mouse screen position: " + mouseScreenPos);
        Vector3 objectScreenPosition = Camera.main.WorldToScreenPoint(transform.position);
        // Debug.Log("Origin screen position: " + objectScreenPosition);
        // Debug.Log("Distance from camera to Origin GO: " +
        //           Vector3.Distance(Camera.main.transform.position,transform.position));
        // mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        mouseScreenPos.z = objectScreenPosition.z;
        
        Vector3 mouseClickedInWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPos);
        // mouseClickedInWorldPosition.z = transform.position.z;
        // Debug.Log("Mouse clicked in world coordinates: " + mouseClickedInWorldPosition);

        transform.GetComponent<Collider>().enabled = false;

    }


    private void OnMouseDrag()
    {
        Vector3 mouseScreenPos = Input.mousePosition;
        Vector3 objectScreenPosition = Camera.main.WorldToScreenPoint(transform.position);
        mouseScreenPos.z = objectScreenPosition.z;
        Vector3 mouseClickedInWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPos);
        transform.position = mouseClickedInWorldPosition;
    }

    private void OnMouseUp()
    {
        Debug.Log("Mouse up");
        // Disparar un raycast origin direction
        Vector3 rayOrigin = Camera.main.transform.position;
        Vector3 rayDirection = (transform.position - Camera.main.transform.position).normalized;
        Debug.DrawRay(rayOrigin, rayDirection, Color.red);
        
        if (Physics.Raycast(rayOrigin, rayDirection,
                out RaycastHit hitInfo,100f, LayerMask.GetMask("Quads")))
        {
            Debug.Log(hitInfo.transform.name);
            transform.position = hitInfo.transform.position;
        }
        
        transform.GetComponent<Collider>().enabled = enabled;
    }
}
