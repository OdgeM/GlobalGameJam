using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Timer timer;
    public LineupManager lineupManager;
    public Map map;


    public float daysPerIncident = 1; // Average
    public int maxIncidentsPerDay = 3;
    private int incidentsToday = 0;
    private float prevTime = 0;

    private List<Incident> currentIncidents = new();
    private List<Incident> resolvedIncidents = new();

    public IncidentMenu incidentMenu;
    public GameObject incidentPanelContent;
    private Dictionary<Incident, IncidentPanel> activeIncidentPanels = new();
    public GameObject incidentPanelPrefab;
    public GameObject spritePrefab;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!timer.pauseButton.isOn)
        {
            float timePassed;

            if (timer.timeElapsed < prevTime)
            {
                incidentsToday = 0;
                timePassed = 1 - prevTime + timer.timeElapsed;
            }
            else
            {
                timePassed = timer.timeElapsed - prevTime;
            }

            foreach(Incident incident in currentIncidents)
            {
                incident.passTime(timePassed);

                if (incident.length < 0)
                {
                    Debug.Log("OVER");
                }
            }

            if (incidentsToday < maxIncidentsPerDay)
            {
                float incidentChance = timePassed / daysPerIncident;

                if (Random.value < incidentChance)
                {
                    CreateIncident();
                }
            }

            prevTime = timer.timeElapsed;
        }
    }

    public void CreateIncident()
    {
        Debug.Log("INCIDENT");
        Villain incidentVillain = lineupManager.SelectVillain();
        Incident incident = map.GenerateIncident(incidentVillain);

        IncidentPanel newPanel = Instantiate(incidentPanelPrefab, incidentPanelContent.transform).GetComponent<IncidentPanel>();
        HeroSprite newSprite = Instantiate(spritePrefab, newPanel.locationNode.transform).GetComponent<HeroSprite>();

        incidentMenu.PlacePanel(newPanel);
        newPanel.AssignIncident("Attack on " + incident.locationName);

        StartCoroutine(waitForVillain(newSprite, incidentVillain, newPanel));

        currentIncidents.Add(incident);
    }

    public IEnumerator waitForVillain(HeroSprite sprite, Villain villain,IncidentPanel panel)
    {
        while (!villain.ready)
        {
            yield return new WaitForEndOfFrame();
        }
        Debug.Log("HERE");
        villain.SetSprite(sprite);
        panel.SetVillain(villain.heroName, sprite);
    }
}



