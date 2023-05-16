using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    Vector3 offsetFromCenterOfObject;

    private void OnMouseDown()
    {
        Debug.Log("Transform position: " + transform.position);
        Debug.Log("Vector3 mouseScreenPos = Input.mousePosition: " + Input.mousePosition);
        Debug.Log("Camera.main.WorldToScreenPoint(transform.position): " + Camera.main.WorldToScreenPoint(transform.position));
        Debug.Log("mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z " + Camera.main.WorldToScreenPoint(transform.position).z);
        Vector3 mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPos);
        Debug.Log("mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPos): " + mouseWorldPosition);
        offsetFromCenterOfObject = transform.position - MouseWorldPosition();
        Debug.Log("offset = transform.position - mouseWorldPosition:" + offsetFromCenterOfObject);

        transform.GetComponent<Collider>().enabled = false;
    }

    private void Update()
    {
        Vector3 rayOrigin = Camera.main.transform.position;
        Vector3 rayDirection = MouseWorldPosition() - rayOrigin;
        Ray ray = new Ray(rayOrigin, rayDirection);
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
    }

    private void OnMouseDrag()
    {
        transform.position = offsetFromCenterOfObject + MouseWorldPosition();
        //Debug.Log("Mouse drag");
    }

    private void OnMouseUp()
    {
        Vector3 rayOrigin = Camera.main.transform.position;
        Vector3 rayDirection = MouseWorldPosition() - rayOrigin;
        if (Physics.Raycast(rayOrigin, rayDirection, out RaycastHit raycastHit))
        {
            if (raycastHit.transform.CompareTag("DropArea"))
            {
                transform.position = raycastHit.transform.position;
            }
        }
        transform.GetComponent<Collider>().enabled = true;
    }

    private Vector3 MouseWorldPosition()
    {
        Vector3 mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPos);
        return mouseWorldPosition;
    }
}
