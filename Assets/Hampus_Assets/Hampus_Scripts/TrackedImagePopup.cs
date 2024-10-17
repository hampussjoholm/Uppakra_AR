using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class TrackedImagePopup : MonoBehaviour
{
    public GameObject xrOrigin; // Reference to the XR Origin
    public GameObject popupCanvas; // Reference to the Canvas object
    private ARTrackedImageManager trackedImageManager;

    void Start()
    {
        // Find the ARTrackedImageManager component from the XR Origin GameObject
        trackedImageManager = xrOrigin.GetComponent<ARTrackedImageManager>();
        
        if (trackedImageManager == null)
        {
            Debug.LogError("ARTrackedImageManager not found in XR Origin!");
        }
    }

    void OnEnable()
    {
        if (trackedImageManager != null)
            trackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    void OnDisable()
    {
        if (trackedImageManager != null)
            trackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var trackedImage in eventArgs.added)
        {
            // When a new image is detected, show the popup
            popupCanvas.SetActive(true);
        }
    }
}
