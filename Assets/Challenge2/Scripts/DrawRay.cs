using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawRay : MonoBehaviour
{
    public Transform origin;
    public Transform direction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(origin.position, direction.position - origin.position, Color.red);
        Debug.DrawRay(Camera.main.transform.position, direction.position - Camera.main.transform.position, Color.yellow);

    }
}
