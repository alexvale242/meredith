using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarSystemController : MonoBehaviour
{
    private struct PlanetOrbit
    {
        public float angle;
        public float radius;

        public PlanetOrbit(float angle, float radius)
        {
            this.angle = angle;
            this.radius = radius;
        }
    }
    [Header("Prefab References")]
    public GameObject starPrefab;
    public GameObject planetPrefab;

    [Header("Settings")]
    public int planetCount = 5;
    public float minOrbitRadius = 5f;
    public float maxOrbitRadius = 100f;
    [Tooltip("Minimum angle difference between planets in degrees")]
    public float minAngleDifference = 30f;
    [Tooltip("Minimum radius difference between planet orbits")]
    public float minRadiusDifference = 10f;

    private GameObject _starInstance;
    private readonly List<GameObject> _planetInstances = new List<GameObject>();
    private readonly List<PlanetOrbit> _planetOrbits = new List<PlanetOrbit>();

    // Start is called before the first frame update
    void Start()
    {
        InstantiateStar();
        InstantiatePlanets();
    }

    private void InstantiateStar()
    {
        if (starPrefab == null)
        {
            Debug.LogWarning("Star prefab is not assigned to SolarSystemController!");
            return;
        }

        _starInstance = Instantiate(starPrefab, transform.position, Quaternion.identity, transform);
    }

    private void InstantiatePlanets()
    {
        if (planetPrefab == null)
        {
            Debug.LogWarning("Planet prefab is not assigned to SolarSystemController!");
            return;
        }

        if (_starInstance == null)
        {
            Debug.LogWarning("Star must be instantiated before planets!");
            return;
        }

        const int maxAttempts = 100;

        for (var i = 0; i < planetCount; i++)
        {
            float angle = 0f;
            float radius = 0f;
            Vector3 planetPosition = Vector3.zero;
            var validPositionFound = false;

            // Try to find a valid orbital position
            for (var attempt = 0; attempt < maxAttempts; attempt++)
            {
                // Generate random angle in radians (0 to 2π)
                angle = Random.Range(0f, 2f * Mathf.PI);

                // Generate random radius between min and max
                radius = Random.Range(minOrbitRadius, maxOrbitRadius);

                // Check if orbit is valid (unique angle and radius)
                if (IsValidPlanetOrbit(angle, radius))
                {
                    validPositionFound = true;
                    break;
                }
            }

            if (!validPositionFound)
            {
                Debug.LogWarning($"Could not find valid orbit for planet {i + 1} after {maxAttempts} attempts. Skipping.");
                continue;
            }

            // Calculate position using polar coordinates
            var x = transform.position.x + radius * Mathf.Cos(angle);
            var y = transform.position.y + radius * Mathf.Sin(angle);
            planetPosition = new Vector3(x, y, transform.position.z);

            // Store the orbital parameters
            _planetOrbits.Add(new PlanetOrbit(angle, radius));

            // Instantiate planet as child of solar system
            var planet = Instantiate(planetPrefab, planetPosition, Quaternion.identity, transform);
            _planetInstances.Add(planet);

            // Initialize planet with star reference
            var planetController = planet.GetComponent<PlanetController>();
            if (planetController != null)
            {
                planetController.Initialize(_starInstance);
            }
        }
    }

    private bool IsValidPlanetOrbit(float angle, float radius)
    {
        // Convert angle to degrees for comparison
        var angleDegrees = angle * Mathf.Rad2Deg;

        // Check against all existing planet orbits
        foreach (var existingOrbit in _planetOrbits)
        {
            var existingAngleDegrees = existingOrbit.angle * Mathf.Rad2Deg;

            // Check angle difference (accounting for circular wrap-around)
            var angleDiff = Mathf.Abs(angleDegrees - existingAngleDegrees);
            // Handle wrap-around (e.g., 350° and 10° are only 20° apart)
            if (angleDiff > 180f)
            {
                angleDiff = 360f - angleDiff;
            }

            if (angleDiff < minAngleDifference)
            {
                return false;
            }

            // Check radius difference
            var radiusDiff = Mathf.Abs(radius - existingOrbit.radius);
            if (radiusDiff < minRadiusDifference)
            {
                return false;
            }
        }

        return true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
