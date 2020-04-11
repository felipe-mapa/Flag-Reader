using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasSecondary : MonoBehaviour{
    public static CanvasSecondary instance;
    public Button helpButton;
    public Canvas canvasSec;

    private void Awake() {
        instance = this;   
    }
}
