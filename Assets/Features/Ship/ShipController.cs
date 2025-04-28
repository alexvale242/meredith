using System.Linq;
using Features.Ship;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public GameObject baseComponentPrefab; 
    public float spacing = 1.1f;

    private Ship _ship;

    private void Start()
    {
        _ship = new Ship();
        SpawnShip();
    }

    private void SpawnShip()
    {
        foreach (var localPosition in _ship.components.Select(comp => new Vector3(comp.x * spacing, comp.y * spacing, 0)))
        {
            InstantiateBaseComponent(localPosition);
        }
    }

    private void InstantiateBaseComponent(Vector3 localPosition)
    {
        var component = Instantiate(baseComponentPrefab, transform);
        component.transform.localPosition = localPosition;
        component.transform.localScale = Vector3.one; // 1x1 scale
    }
}