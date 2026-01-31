using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Map : MonoBehaviour
{
    public GameObject cityContainer;
    public static List<City> cities;
    private List<City> activeCities = new();
    private List<Incident> currentIncidents = new();
    private List<Incident> resolvedIncidents = new();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        City[] childCity = cityContainer.GetComponentsInChildren<City>();
        cities = childCity.OfType<City>().ToList();

        //Incident newIncident = new Incident(cities[0]);
        //Debug.Log(newIncident.incidentFlavour);

        
    }



    public City GetRandomCity()
    {
        int idx = Random.Range(0, cities.Count);
        City chosenCity = cities[idx];
        return chosenCity;
    }
    public void GenerateIncident()
    {
        List<City> availableCities = cities.Where(city => !activeCities.Contains(city)).ToList();
        int idx = Random.Range(0, availableCities.Count);
        City chosenCity = availableCities[idx];

        chosenCity.Activate();
        activeCities.Add(chosenCity);
        Incident newIncident = new Incident(chosenCity); 
        currentIncidents.Add(newIncident); 

    }
}
