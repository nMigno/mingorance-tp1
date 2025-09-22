using UnityEngine;
using UnityEngine.InputSystem;

public class ScreenController : MonoBehaviour
{
    public GameObject startCanvas;

    private bool isPaused = true;
    void Start()
    {
        Time.timeScale = 0f; // Game starts paused

        startCanvas.SetActive(true);
    }
    private void ResumeGame()
    {
        isPaused = false;

        // Hide panel and resume time
        startCanvas.SetActive(false);
        Time.timeScale = 1f;
    }
    void Update() // Resume game after input
    {
        if (!isPaused) return;

        if (Keyboard.current.anyKey.wasPressedThisFrame)
        {
            ResumeGame();
        }
    }
}
