using System;
using System.Collections;
using System.Collections.Generic;

using Unity.VisualScripting;

using UnityEngine;

public class SphereControl : MonoBehaviour
{
    private Rigidbody _rigitbodySphere;
    public float _speed = 5f;
    public int _impulse = 300;
    public float _velocityScaler;
    public float _velocity;
    private Vector3 _mousePosition;

    private void Start() //Awake
    {
        _rigitbodySphere = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector3 _mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5f);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(_mousePosition);
        //определить позицию мыши в текущем кадре в мировых координатах (метод ScreenToWorldPoint класса камера)
        //Vector3 direction = objPosition - transform.position;
        //direction.Normalize(); //найти вектор, исходящий из центра сферы, и направленный к позиции мыши
        //transform.position = objPosition;
        _velocity = Vector3.Distance(transform.position, _mousePosition) * _velocityScaler;

        if (Input.GetMouseButton(0))
        {
            Vector3 direction = (_mousePosition - _rigitbodySphere.transform.position);
            direction.Normalize();
            _rigitbodySphere.velocity = direction * _velocity;
            var vx = _rigitbodySphere.velocity * direction.x;
            var vy = _rigitbodySphere.velocity * direction.y;
            var vz = _rigitbodySphere.velocity * direction.z;

            //if (Input.GetMouseButton(0))
            //{
                //if (Input.GetKey(KeyCode.A))
                //{
                    //_rigitbodySphere.AddForce(0f, 0f, 5f);
                //}
            //}
        }
    }
}