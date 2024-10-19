using System.Collections;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class CanvasScript : MonoBehaviour
{
    public ARTrackedImageManager trackedImageManager; // Reference to the ARTrackedImageManager
    public GameObject canvas1;
    public GameObject canvas2;

    void OnEnable()
    {
        // Subscribe to the tracked images changed event
        trackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    void OnDisable()
    {
        // Unsubscribe to prevent memory leaks
        trackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    // This method is called whenever the tracked images are updated
    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (ARTrackedImage trackedImage in eventArgs.added)
        {
            HideCanvas(canvas1);
            ShowCanvas(canvas2);
        }
    }

    private void ShowCanvas(GameObject canvas)
    {
        // Enable the canvas if it's not already active
        if (!canvas.activeSelf)
        {
            canvas.SetActive(true);
        }
    }

    private void HideCanvas(GameObject canvas)
    {
        // Hide the canvas if it is currently active
        if (canvas.activeSelf)
        {
            canvas.SetActive(false);
        }
    }
}
