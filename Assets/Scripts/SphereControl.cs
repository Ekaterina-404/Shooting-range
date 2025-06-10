using System;
using System.Collections;
using System.Collections.Generic;

using Unity.VisualScripting;

using UnityEngine;

public class SphereControl : MonoBehaviour
{
    private readonly float _distance = 5f;
    private Rigidbody _rigidbodySphere;
    private Transform _transformSphere;
    [SerializeField] private Material _material;
    [SerializeField] private Vector3 _scale;


    private void Start() //Awake
    {
        _rigidbodySphere = GetComponent<Rigidbody>();
        _transformSphere = GetComponent<Transform>();
        _rigidbodySphere.useGravity = false;
    }

    private void Update()
    {
        if (_rigidbodySphere.useGravity == false)
        {
            FixItToMouse(_transformSphere);
        }

        if (Input.GetMouseButtonUp(0))
        {
            _rigidbodySphere.useGravity = true;
            _rigidbodySphere.AddForce(Camera.main.transform.forward * 3000);
            CreateSphere();
        }
    }
    private void CreateSphere()
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.GetComponent<Renderer>().material = _material;
        _transformSphere = sphere.GetComponent<Transform>();
        _transformSphere.localScale = _scale;
        _rigidbodySphere = sphere.AddComponent<Rigidbody>();
        _rigidbodySphere.useGravity = false;
    }

    private void FixItToMouse(Transform transformSphere) //Цепляем объект к курсору мыши
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _distance);
        Vector3 mousePositionInTheWorld = Camera.main.ScreenToWorldPoint(mousePosition);
        transformSphere.position = mousePositionInTheWorld;
    }
    private void OnCollisionEnter(Collision cube) 
    {
        if (cube.gameObject.CompareTag("Respawn"))
        {
            
        } 
    }
}
