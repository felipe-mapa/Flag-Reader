using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuOpener : MonoBehaviour {
    public Canvas menuCanvas;
    private Button menuButton;

    private void Awake() {
        menuButton = GetComponent<Button>();
        menuButton.onClick.AddListener(() => enableCanvas());
    }

    private void enableCanvas()
    {
        menuCanvas.enabled = true;
        MenuButtons.instance.FadeIn();
    }

}
