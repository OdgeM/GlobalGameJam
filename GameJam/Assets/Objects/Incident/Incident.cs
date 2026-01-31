using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Incident
{
    public enum Type
    {
        Villain,
        Alien
    }

    public City location;
    private string locationName;
    private string target;
    public Villain villain;

    public string incidentFlavour;
    public Incident(City city)
    {
        location = city;
        locationName = city.cityName.Trim();

        target = ""; 
        string connector = "in"; 

        if (city.features.Count > 0 && Random.value > 0.5f)
        {
            int idx = Random.Range(0, city.features.Count);
            target = city.features[idx].Trim() + " in ";
            connector = "at";
        }
        
        target += locationName;

        string flavour = villainFlavour[Random.Range(0, villainFlavour.Length)];
        incidentFlavour = string.Format(flavour, villain.heroName, connector, target);
        Debug.Log(incidentFlavour);
    }


    static string[] villainFlavour =
    {
        "{0} is attacking {2}!",
        "{0} is causing chaos {1} {2}!",
        "{0} is running amok in {1} {2}!",
        "{0} is enacting a dastardly plan {1} {2}!"
    };
}
