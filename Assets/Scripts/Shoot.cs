using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class Shooting : MonoBehaviour
{
    [Header("Shoot")] // Headers organize items in Inspector window
    public Transform shootingPoint;
    public GameObject bulletPrefab;

    [Header("Impact Reaction")]
    public string targetTag = "Target";
    public Color hitColor = Color.red;
    public float hitColorDuration = 0.2f;

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            GameObject arrow = Instantiate (bulletPrefab, shootingPoint.position, shootingPoint.rotation);

            var collisionScript = arrow.AddComponent<BulletCollision>();
            collisionScript.targetTag = targetTag;
            collisionScript.hitColor = hitColor; 
            collisionScript.hitDuration = hitColorDuration;

            // Destroy arrow after X seconds
            Destroy(arrow, 1.5f);
        }
    }
}

public class BulletCollision : MonoBehaviour
{
    // Hide public items in Inspector window
    [HideInInspector] public string targetTag;
    [HideInInspector] public Color hitColor;
    [HideInInspector] public float hitDuration;

    private Collider2D col2D;
    private Rigidbody2D rb2D;

    private void Awake() // Call before script start
    {
        col2D = GetComponent<Collider2D>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag(targetTag)) return;

        // Generate target reaction
        var reaction = other.GetComponent<TargetReaction>();
        if (reaction != null)
            reaction.OnHit();

        // Hide bullet during reaction
        var bs = GetComponent<SpriteRenderer>();
        if (bs != null) bs.enabled = false;

        // Destroy bullet after reaction
        Destroy(gameObject);
    }
}

