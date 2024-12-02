using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSetInactive : MonoBehaviour { 

   public GameObject startCanvas;
   public void SetInactive()
    {
        startCanvas.SetActive(false);
    }
}
