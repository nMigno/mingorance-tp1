using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PlayerOpacityController : MonoBehaviour
{
    [Tooltip("Sprite alpha when game is paused")]
    [Range(0.5f, 0.8f)]
    public float pausedAlpha = 0.5f;

    private SpriteRenderer sr;
    private Color originalColor;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
    }

    private void Update()
    {
        if (Time.timeScale == 0f)
        {
            // Paused: black with opacity
            Color blackWithAlpha = Color.black;
            blackWithAlpha.a = pausedAlpha;
            sr.color = blackWithAlpha;
        }
        else
        {
            // Resume: restore original color
            sr.color = originalColor;
        }
    }
}
