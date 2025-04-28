using UnityEngine;

namespace Features.Ship.Collision
{
    public class HittableComponentController : MonoBehaviour, IHittableComponent
    {
        public float health = 100f;
        public void OnHit()
        {
            Debug.Log("Hit!");
            health -= 10;
            Debug.Log($"Health now {health}!");
        }
    }
}