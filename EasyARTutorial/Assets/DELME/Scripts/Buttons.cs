using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour {
    public Button btnLeft;
    public Button btnRight;
    
    private void Awake() {
        btnLeft.onClick.AddListener(() => UITest.instance.Increment(-1));
        btnRight.onClick.AddListener(() => UITest.instance.Increment(1));
    }
}
