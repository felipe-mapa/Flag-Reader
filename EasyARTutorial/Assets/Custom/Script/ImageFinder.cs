using System.Collections.Generic;
using System.IO;
using EasyAR;
using UnityEngine;

public class ImageFinder : ImageTargetBehaviour {
    public Dictionary<string, Country> countriesDict = new Dictionary<string, Country>();
    public static ImageFinder current;
    public CountryList countryList;
    public Sprite contImage;
    
    private string path;
    private string jsonString;
    private string filePath;
    private string dataAsJson;
    private string target;
    Country[] loadedData;

    protected override void Awake() {
        base.Awake();
        Debug.Log(Application.persistentDataPath);
        filePath = System.IO.Path.Combine(Application.streamingAssetsPath, "country.json");
        UnityEngine.Networking.UnityWebRequest www = UnityEngine.Networking.UnityWebRequest.Get(filePath);
        
        dataAsJson = File.ReadAllText (filePath);
        countryList = JsonUtility.FromJson<CountryList> (dataAsJson);

        foreach (Country c in countryList.countries) {
            AddToDictionary(c);
        }
    }
    
    protected override void Start() {
        base.Start();
    }

    private void OnEnable() {
        TargetFound += OnTargetFound;
        TargetLost += OnTargetLost;
    }


    private void OnDisable() {
        TargetFound -= OnTargetFound;
        TargetLost -= OnTargetLost;

    }

    private void AddToDictionary(Country _country) {
        countriesDict.Add(_country.targetName, _country);
    }

    private void OnTargetFound(TargetAbstractBehaviour obj) {
        CanvasDisplay.instance.transform.SetParent(transform);
        current = this;

        // Debug.Log(name + " found");
        CustomEvents.TrackingFound();

        foreach (Country c in countryList.countries) {
            // Debug.Log(c.targetName);
            
            target = c.targetName.ToString();
            
            if (target == name){
                CanvasDisplay.instance.countryName.text = c.name;
                CanvasDisplay.instance.capital.text = "Capital: " + c.capital;
                CanvasDisplay.instance.continent.text = c.continent;
                CanvasDisplay.instance.population.text = "Population: " + c.population;
                CanvasDisplay.instance.hdi.text = c.hdi;
                CanvasDisplay.instance.hdiName.text = "HDI";
                CanvasDisplay.instance.contImage.enabled = true;
                CanvasDisplay.instance.contImage.sprite = contImage;
            }
        }

    }


    private void OnTargetLost(TargetAbstractBehaviour obj){
        target = "";
    }

    protected override void Update() {
        base.Update();
    }

}