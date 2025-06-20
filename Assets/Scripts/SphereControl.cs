using UnityEngine;

public class SphereControl : MonoBehaviour
{
    [SerializeField] private Material _material;
    [SerializeField] private Vector3 _scale;
    [SerializeField] private float _force = 3000f;

    private readonly float _distance = 5f;
    private Camera _camera;
    private bool _connectedToMouse;

    private Rigidbody _rigidbodySphere;
    private Transform _transformSphere;
    private Vector3 _direction;

    private void Start()
    {
        _rigidbodySphere = GetComponent<Rigidbody>();
        _transformSphere = GetComponent<Transform>();
        _rigidbodySphere.useGravity = false;
        _connectedToMouse = true;
        _camera = Camera.main;
        _direction = _camera.transform.forward * _force;
    }

    private void Update()
    {
        if (_connectedToMouse)
        {
            FixItToMouse(_transformSphere);
        }

        if (Input.GetMouseButtonUp(0))
        {
            _rigidbodySphere.useGravity = true;
            _connectedToMouse = false;
            _rigidbodySphere.AddForce(_direction);
            CreateSphere();
        }
    }

    private void OnCollisionEnter(Collision cube)
    {
        if (cube.gameObject.CompareTag("Respawn"))
        {
        }
    }

    private void CreateSphere()
    {
        var sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.GetComponent<Renderer>().material = _material;
        _transformSphere = sphere.GetComponent<Transform>();
        _transformSphere.localScale = _scale;
        _rigidbodySphere = sphere.AddComponent<Rigidbody>();
        _rigidbodySphere.useGravity = false;
    }

    private void FixItToMouse(Transform transformSphere)
    {
        var mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _distance);
        var mousePositionInTheWorld = _camera.ScreenToWorldPoint(mousePosition);
        transformSphere.position = mousePositionInTheWorld;
    }
}