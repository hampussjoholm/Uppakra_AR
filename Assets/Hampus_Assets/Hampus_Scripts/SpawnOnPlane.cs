using UnityEngine;
using UnityEngine.XR.ARFoundation;

namespace UnityEngine.XR.ARFoundation.Samples
{
    public class SpawnOnPlane : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("The prefab to be placed or moved.")]
        GameObject m_PrefabToPlace;

        [SerializeField]
        [Tooltip("The Scriptable Object Asset that contains the ARRaycastHit event.")]
        ARRaycastHitEventAsset m_RaycastHitEvent;

        GameObject m_SpawnedObject;

        public GameObject canvas1;
        public GameObject canvas2;
        public AudioSource audioSource; // Reference to the AudioSource that will play the sound

        public GameObject prefabToPlace
        {
            get => m_PrefabToPlace;
            set => m_PrefabToPlace = value;
        }

        public GameObject spawnedObject
        {
            get => m_SpawnedObject;
            set => m_SpawnedObject = value;
        }

        void OnEnable()
        {
            if (m_RaycastHitEvent == null || m_PrefabToPlace == null)
            {
                Debug.LogWarning($"{nameof(ARPlaceObject)} component on {name} has null inputs and will have no effect in this scene.", this);
                return;
            }

            if (m_RaycastHitEvent != null)
                m_RaycastHitEvent.eventRaised += PlaceObjectAt;
        }

        void OnDisable()
        {
            if (m_RaycastHitEvent != null)
                m_RaycastHitEvent.eventRaised -= PlaceObjectAt;
        }

        // This method is triggered when the raycast hit event occurs
        void PlaceObjectAt(object sender, ARRaycastHit hitPose)
        {
            // If no robot has been placed yet, spawn one
            if (m_SpawnedObject == null)
            {
                // Instantiate the robot at the hit position but do not move it yet
                m_SpawnedObject = Instantiate(m_PrefabToPlace, hitPose.pose.position, hitPose.pose.rotation, hitPose.trackable.transform.parent);

                HideCanvas(canvas1);
                ShowCanvas(canvas2);
                PlaySound();
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
        private void PlaySound()
        {
            // Play the sound from the AudioSource
            if (!audioSource.isPlaying) // Avoid overlapping sounds
            {
                audioSource.Play();
            }
        }
    }
}
