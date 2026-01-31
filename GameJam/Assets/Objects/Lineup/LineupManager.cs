using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class LineupManager : MonoBehaviour
{
    public List<Hero> heroLineup;
    public Dictionary<Hero, CharacterPanel> heroPanels;
    public int startingHeroSize = 3;
    public GameObject heroPrefab;

    public List<Villain> villainLineup;
    public int startingVillainSize = 2;
    public int idealVillains = 5;
    public GameObject villainPrefab;

    public GameObject characterPanelPrefab;
    public GameObject heroPanelContent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //InitialiseLineup();
        createCharacter();
    }

    public void InitialiseLineup()
    {
        for (int i = 0; i < startingHeroSize; i++)
        {
            Hero newHero = Instantiate(heroPrefab).GetComponent<Hero>();
            heroLineup.Add(newHero);
        }
    }


    private void createCharacter()
    {
        CharacterPanel newPanel = Instantiate(characterPanelPrefab, heroPanelContent.transform).GetComponent<CharacterPanel>();

        Hero newHero = Instantiate(heroPrefab, newPanel.locationNode.transform).GetComponent<Hero>();   
        newPanel.AssignCharacter(newHero);
    }

    public Villain SelectVillain()
    {
        int villainCount;
        if (villainLineup.Count < idealVillains)
        {
            villainCount = idealVillains;
        }
        else 
        {
            villainCount = villainLineup.Count + 1;
        }

        int index = Random.Range(0, villainCount);

        if (index == villainLineup.Count)
        {
            Villain newVillain = Instantiate(villainPrefab).GetComponent<Villain>();
            villainLineup.Add(newVillain);
            newVillain.deployments++;
            return newVillain;
            // Create new Villain
        }
        else
        {
            villainLineup[index].deployments++;
            return villainLineup[index];    
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
