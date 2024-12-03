using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour { 

   public GameObject startCanvas;
   public void inactivateStartCanvas()
    {
        startCanvas.SetActive(false);
    }
}
