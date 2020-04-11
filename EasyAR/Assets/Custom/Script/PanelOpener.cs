using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PanelOpener : MonoBehaviour{
    public GameObject Panel;
    public Text buttonText;

    private void Awake() {
        buttonText.text = "?";
    }

    public void showHidePanel(){
        if(Panel != null){
            bool isActive = Panel.activeSelf;

            Panel.SetActive(!isActive);
            if (isActive == true){
                buttonText.text = "?";
            } else {
                buttonText.text = "X";
            }
        }
    }

    private void Update() {

    }
}
