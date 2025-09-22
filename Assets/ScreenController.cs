using UnityEngine;

public class ScreenController : MonoBehaviour
{
    public GameObject startCanvas;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            startCanvas.SetActive(!startCanvas.activeSelf);
        }
    }
}
