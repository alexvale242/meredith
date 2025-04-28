using System.Linq;
using Features.Ship;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public GameObject baseComponentPrefab; 

    private Ship _ship;

    private void Start()
    {
        _ship = new Ship();
        SpawnShip();
    }

    private void SpawnShip()
    {
        foreach (var component in _ship.Components)
        {
            InstantiateBaseComponent(new Vector3(component.XPosition, component.YPosition), new Vector3(component.XSize, component.YSize));
        }
    }

    private void InstantiateBaseComponent(Vector3 localPosition, Vector3 localScale)
    {
        var component = Instantiate(baseComponentPrefab, transform);
        component.transform.localPosition = localPosition;
        component.transform.localScale = localScale;
    }
}