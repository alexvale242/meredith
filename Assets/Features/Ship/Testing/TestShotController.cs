using System;
using Features.Ship.Collision;
using Features.Ship.Components;
using UnityEngine;

namespace Features.Ship.Testing
{
    public class TestShotController : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log(collision.gameObject.name);
            // Try to get a component on the object we hit that can handle being hit
            var hitTarget = collision.GetComponent<IHittableComponent>();
            Debug.Log(hitTarget);
            hitTarget?.OnHit();

            Destroy(gameObject);
        }
    }
}