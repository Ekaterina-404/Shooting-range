using System;
using System.Collections;
using System.Collections.Generic;

using Unity.VisualScripting;

using UnityEngine;

public class SphereControl : MonoBehaviour
{
    private Rigidbody _rigitbodySphere;
    private Transform _transformSphere;
    private readonly float _distance = 5f;
    [SerializeField] private GameObject _spherePrefab;
    //private GameObject _sphereClone;

    private void Start() //Awake
    {
        _rigitbodySphere = GetComponent<Rigidbody>();
        _transformSphere = GetComponent<Transform>();
        _rigitbodySphere.useGravity = false;
    }

    private void Update()
    {
        if (_rigitbodySphere.useGravity == false)
        {
            FixItToMouse();
        }

        if (Input.GetMouseButtonUp(0)) //усиливается бросок, зависимость силы от времени, GetMouseButton
        {
            _rigitbodySphere.useGravity = true;
            _rigitbodySphere.AddForce(Camera.main.transform.forward * 3000);
            Instantiate(_spherePrefab, new Vector3(Input.mousePosition.x, Input.mousePosition.y, _distance), Quaternion.identity);
        }
    }

    private void FixItToMouse() //Цепляем объект к курсору мыши
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _distance);
        Vector3 mousePositionInTheWorld = Camera.main.ScreenToWorldPoint(mousePosition);
        _transformSphere.position = mousePositionInTheWorld;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject
            .CompareTag("Respawn")) //где тег, который присвоен объекту который соприкасается с объектом на котором висит данный скрипт
        {
            Destroy(this.gameObject);
        }
    }

    /*private void FixedUpdate()
    {

    } */
}