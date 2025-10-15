using UnityEngine;

public class ShipController : MonoBehaviour
{
    [SerializeField] private GameObject _ship;

    public void DisableShip()
    {
        _ship.SetActive(false);
    }
}