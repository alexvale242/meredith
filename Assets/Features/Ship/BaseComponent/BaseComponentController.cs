using UnityEngine;

public class BaseComponentController : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth = 100f;

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        UpdateColor();
    }

    private void UpdateColor()
    {
        // Normalize health to 0-1
        var healthPercent = Mathf.Clamp01(currentHealth / maxHealth);

        Color newColor;

        switch (healthPercent)
        {
            case > 1f:
                newColor = Color.white;
                break;
            case > 1f / 2f:
            {
                // Between 50% and 100%: White → Red
                var t = (healthPercent - 0.5f) * 2f; // Remap 0.5-1 to 0-1
                newColor = Color.Lerp(Color.red, Color.white, t);
                break;
            }
            default:
            {
                // Between 0% and 50%: Black → Red
                var t = healthPercent * 2f; // Remap 0-0.5 to 0-1
                newColor = Color.Lerp(Color.black, Color.red, t);
                break;
            }
        }

        _spriteRenderer.color = newColor;
    }
}