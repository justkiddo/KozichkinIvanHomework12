using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransform : MonoBehaviour
{
    [SerializeField] private Camera _camera;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _camera.transform.position = new Vector3(37, 32, 53);
            _camera.transform.rotation = Quaternion.Euler(28,180,0);
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _camera.transform.position = new Vector3(-50, 25, 14);
            _camera.transform.rotation = Quaternion.Euler(38,90,0);
        }
    }
}
