using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasDisplay : MonoBehaviour {
    public static CanvasDisplay instance;

    private Text targetName;
    public Text countryName;
    public Text capital;
    public Text continent;
    public Text population;
    public Text hdi;
    public Text hdiName;
    public Image contImage;

    private Country country;
    public Canvas canvasMain;

    private void Awake() {
        instance = this;
    }

    void Start(){
        canvasMain = GetComponent<Canvas>();
        canvasMain.enabled = false;
    }

}