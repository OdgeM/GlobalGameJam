using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Incident
{

    public City location;
    public string locationName;
    public string target;
    public Villain villain;
    public IncidentPanel panel;
    public float length = 3;


    public string incidentFlavour;
    public Incident(City city, Villain _villain)
    {
        villain = _villain;
        location = city;
        locationName = city.cityName.Trim();


        if (villain.isAlien)
        {
            string flavour = alienFlavour[Random.Range(0, alienFlavour.Length)];
            incidentFlavour = string.Format(flavour, villain.heroName, city.cityName, villain.hometown);
        }
        else
        {
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
         
    }

    public void passTime(float timePassed)
    {
        length -= timePassed; 
    }




    static string[] villainFlavour =
    {
        "{0} is attacking {2}!",
        "{0} is causing chaos {1} {2}!",
        "{0} is running amok {1} {2}!",
        "{0} is enacting a dastardly plan {1} {2}!"
    };

    static string[] alienFlavour =
    {
        "An alien from {2}, {0}, is invading {1}!",
        "Aliens from the planet {2} are attacking {1}!",
        "Extraterrestrials lead by {0} are conducting an invasion of {1}!"
    };

}
