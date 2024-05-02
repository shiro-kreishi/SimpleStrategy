using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceObjects : MonoBehaviour
{

    [SerializeField] private LayerMask layer;
    [SerializeField] private float rotationSpeed = 60f;

    private void Start()
    {
        PlaceObject();
    }
    
    private void Update()
    {
        PlaceObject();

        if (Input.GetMouseButtonDown(0))
        {
            Destroy(gameObject.GetComponent<PlaceObjects>());
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
        }
    }
    
    private void PlaceObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1000f, layer))
        {
            transform.position = hit.point;
        }
    }
}
