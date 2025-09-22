using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class TargetReaction : MonoBehaviour
{
    public Color hitColor = Color.red;
    public float hitDuration = 0.05f;

    private SpriteRenderer sr;
    private Color originalColor;
    private Coroutine flashCoroutine;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
    }

    public void OnHit()
    {
        // Stop on-course coroutine
        if (flashCoroutine != null)
            StopCoroutine(flashCoroutine);

        // Start new coroutine
        flashCoroutine = StartCoroutine(FlashRoutine());
    }

    private IEnumerator FlashRoutine() // Reaction event
    {
        sr.color = hitColor;
        yield return new WaitForSeconds(hitDuration);
        sr.color = originalColor;
        flashCoroutine = null;
    }
}
