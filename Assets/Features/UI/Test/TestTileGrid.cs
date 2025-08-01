using UnityEngine;
using UnityEngine.UI;

public class TestTileGrid : MonoBehaviour
{
    public GameObject tilePrefab;       // Prefab with an Image component
    public int rows = 8;
    public int columns = 8;

    private void Start()
    {
        var grid = GetComponent<GridLayoutGroup>();
        if (grid == null)
        {
            Debug.LogError("CheckerboardGrid requires a GridLayoutGroup on the same GameObject.");
            return;
        }
        
        var rt = GetComponent<RectTransform>();

        // Get current rect size
        float width = rt.rect.width;
        float height = rt.rect.height;

        // Set spacing and padding to zero just in case
        grid.spacing = Vector2.zero;
        grid.padding = new RectOffset(0, 0, 0, 0);

        // Calculate cell size
        float cellWidth = width / columns;
        float cellHeight = height / rows;
        grid.cellSize = new Vector2(cellWidth, cellHeight);
        
        // Create tiles
        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < columns; x++)
            {
                GameObject tile = Instantiate(tilePrefab, transform);
                Image img = tile.GetComponent<Image>();
                bool isBlack = (x + y) % 2 == 0;
                img.color = isBlack ? Color.red : Color.white;
            }
        }
    }
}