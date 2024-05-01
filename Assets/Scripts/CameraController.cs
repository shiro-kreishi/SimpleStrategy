using System;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraController : MonoBehaviour
{
   [SerializeField] private float rotateSpeed = 10.0f;
   private float _mult = 1f; 
   [SerializeField] private float speed = 10.0f;
   [SerializeField] private float zoomSpeed = 10.0f;

   private void Update()
   {
      float horizontal = Input.GetAxis("Horizontal");
      float vertical = Input.GetAxis("Vertical");
      
      float rotate = 0f;
      if (Input.GetKey(KeyCode.Q))
         rotate = -1f;
      else if (Input.GetKey(KeyCode.E))
         rotate = 1f;
      _mult = Input.GetKey(KeyCode.LeftShift) ? 2f : 1f;
      transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime * rotate * _mult, Space.World);
      transform.Translate(new Vector3(horizontal, 0, vertical) * Time.deltaTime * _mult * speed, Space.Self);
      
      transform.position += transform.up * zoomSpeed * Time.deltaTime * Input.GetAxis("Mouse ScrollWheel");

      transform.position = new Vector3(
         transform.position.x,
         Mathf.Clamp(transform.position.y, -20f, 30f),
         transform.position.z
      );
   }
}
