using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformData : MonoBehaviour
{
    private string filePath = Application.streamingAssetsPath + "/country.json";
    private string dataAsJson;
    public Dictionary<string, Country> countriesDict = new Dictionary<string, Country>();

    public CountryList countryList;

    private void Awake() {
        dataAsJson = File.ReadAllText (filePath);
        countryList = JsonUtility.FromJson<CountryList> (dataAsJson);

        foreach (Country c in countryList.countries) {
            AddToDictionary(c);
            // Debug.Log(c.targetName);
        }

        // foreach (string s in countriesDict.Keys) {
        //     Debug.Log(s);
        // }

        Debug.Log(gameObject.name);

        // foreach (Country c in loadedData) {
        //     Debug.Log(c.countries);
        // }
    }



    void AddToDictionary(Country _country) {
        countriesDict.Add(_country.targetName, _country);
    }
}
