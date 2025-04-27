using System.Collections.Generic;
using UnityEngine;
using System.IO; // For reading files

public class ShipController : MonoBehaviour
{
    [System.Serializable]
    public class ShipComponentData
    {
        public int x;
        public int y;
    }

    [System.Serializable]
    public class ShipConfig
    {
        public List<ShipComponentData> components;
    }

    public GameObject baseComponentPrefab; // Drag your BaseComponent prefab here
    public string configFileName = "Ship"; // Name of your JSON file (no .json extension)
    public float spacing = 1.1f; // Distance between components

    private void Start()
    {
        LoadAndSpawnShip();
    }

    private void LoadAndSpawnShip()
    {
        // Load JSON text
        string filePath = Path.Combine(Application.streamingAssetsPath, configFileName + ".json");

        if (!File.Exists(filePath))
        {
            Debug.LogError("Ship config file not found at: " + filePath);
            return;
        }

        string jsonText = File.ReadAllText(filePath);

        // Deserialize JSON
        ShipConfig config = JsonUtility.FromJson<ShipConfig>(jsonText);

        if (config == null || config.components == null)
        {
            Debug.LogError("Invalid ship config data!");
            return;
        }

        // Instantiate components
        foreach (var comp in config.components)
        {
            Vector3 localPosition = new Vector3(comp.x * spacing, comp.y * spacing, 0);
            InstantiateBaseComponent(localPosition);
        }
    }

    private void InstantiateBaseComponent(Vector3 localPosition)
    {
        GameObject component = Instantiate(baseComponentPrefab, transform);
        component.transform.localPosition = localPosition;
        component.transform.localScale = Vector3.one; // 1x1 scale
    }
}