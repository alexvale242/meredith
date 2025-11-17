using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour
{
    [Header("Settings")]
    [Tooltip("Multiplier for orbital speed. Higher values = faster orbits overall.")]
    public float orbitalSpeedMultiplier = 100f;

    private GameObject _star;
    private float _orbitRadius;
    private float _calculatedOrbitSpeed;

    public void Initialize(GameObject star)
    {
        _star = star;

        if (_star != null)
        {
            // Calculate initial orbit radius from star
            _orbitRadius = Vector3.Distance(transform.position, _star.transform.position);

            // Calculate orbital speed using Kepler's third law
            // Angular velocity ∝ r^(-3/2) - closer planets orbit faster
            _calculatedOrbitSpeed = orbitalSpeedMultiplier / Mathf.Pow(_orbitRadius, 1.5f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!_star)
            return;

        // Rotate around the star using calculated orbital speed
        transform.RotateAround(_star.transform.position, Vector3.forward, _calculatedOrbitSpeed * Time.deltaTime);
    }
}
