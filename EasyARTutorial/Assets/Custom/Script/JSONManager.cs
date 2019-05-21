using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONManager : MonoBehaviour {
    public static JSONManager instance;
        
    public TextAsset jsonFile;
    
    public string jsonData { get; set; } 

    private void Awake() {
        instance = this;

        jsonData = jsonFile.ToString();
    }
}
