using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using EasyAR;
using UnityEngine;
using System.Linq;

public class ImageFinder : ImageTargetBehaviour {
    public Dictionary<string, Country> countriesDict = new Dictionary<string, Country>();
    public static ImageFinder current;
    public CountryList countryList;
    
    private string path;
    private string jsonString;
    private string filePath;
    private string dataAsJson;
    private string target;
    Country[] loadedData;

    protected override void Start() {
        base.Start();
        countryList = JsonUtility.FromJson<CountryList>(JSONManager.instance.jsonData);

        foreach (Country c in countryList.countries) {
            AddToDictionary(c);
        }
    }

    private void OnEnable() {
        TargetFound += OnTargetFound;
        TargetLost += OnTargetLost;
    }

    protected override void OnDestroy() {
        base.OnDestroy();
        
        TargetFound -= OnTargetFound;
        TargetLost -= OnTargetLost;
    }

    private void AddToDictionary(Country _country) {
        countriesDict.Add(_country.targetName, _country);
    }

    private void OnTargetFound(TargetAbstractBehaviour obj) {
        CanvasDisplay.instance.transform.SetParent(transform);
        current = this;

        // disable secondary canvas and enable main
        CanvasSecondary.instance.canvasSec.enabled = false;
        CanvasDisplay.instance.canvasMain.enabled = true;

        //Debug.Log(name + " found");
        
        CustomEvents.TrackingFound();

        foreach (Country c in countryList.countries) {
            //Debug.Log(c.targetName);
            
            target = c.targetName.ToString();
            
            if (target == name){

                string getHdi = c.hdi.ToString();
                string hdiColored = setHdiColor(getHdi);

                // Getting Sprite icon
                string continentName = c.continent.ToLower();
                Sprite[] continentIcon = Resources.LoadAll<Sprite>("Texture/Continents/" + continentName);
                Sprite iconSprite = continentIcon.Single(s => s.name == continentName);
                // Debug.Log(iconSprite);

                CanvasDisplay.instance.countryName.text = c.name;
                CanvasDisplay.instance.capital.text = " Capital: " + c.capital;
                CanvasDisplay.instance.continent.text = c.continent;
                CanvasDisplay.instance.population.text = " Population: " + c.population;
                CanvasDisplay.instance.hdi.text = "<color=" + hdiColored + ">" + c.hdi + "</color>";
                CanvasDisplay.instance.hdiName.text = "HDI";
                CanvasDisplay.instance.contImage.enabled = true;
                CanvasDisplay.instance.contImage.sprite = iconSprite;
            }
        }

    }


    private void OnTargetLost(TargetAbstractBehaviour obj){
        CustomEvents.TrackingLost();
        CanvasSecondary.instance.canvasSec.enabled = true;        
    }

    protected override void Update() {
        base.Update();
    }

    string setHdiColor(string hdi){
        float intHdi = float.Parse(hdi);
        string hdiColored = "#000";
        if (intHdi > 0.900){
            hdiColored = "#287E28";
        } else if (intHdi > 0.800){
            hdiColored = "#00c400";            
        } else if (intHdi > 0.700){
            hdiColored = "#d3ff00";            
        } else if (intHdi > 0.600){
            hdiColored = "#ffd215";            
        } else if (intHdi > 0.500){
            hdiColored = "#ff852f";            
        } else if (intHdi > 0.400){
            hdiColored = "#ff852f";            
        } else {
            hdiColored = "#a70000";  
        }

        return hdiColored;
    }
}