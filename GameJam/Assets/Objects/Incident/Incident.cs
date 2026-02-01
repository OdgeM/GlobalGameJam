using NUnit.Framework;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using UnityEngine;
using Unity.VisualScripting;

public class Incident
{

    public City location;
    public string locationName;
    public string target;
    public Villain villain;
    public IncidentPanel panel;
    public float maxLength = 3;
    public float length = 3;
    public Hero hero;

    public float incidentStakes = 1;
    public string state = "Ongoing";

    public float damageDone;
    public Character Victim;
    public Character Attacker;

    public string incidentFlavour;

    public float dateCompleted;
    public Incident(City city, Villain _villain)
    {
        villain = _villain;
        villain.SetAvailable(false);
        location = city;
        locationName = city.cityName.Trim();


        if (villain.isAlien)
        {
            string flavour = alienFlavour[Random.Range(0, alienFlavour.Length)];
            incidentFlavour = string.Format(flavour, villain.heroName.Trim(), city.cityName, villain.hometown);
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
        }
         
    }

    public void AssignHero(Hero _hero)
    {
        hero = _hero;
        hero.SetAvailable(false);
    }

    public void passTime(float timePassed)
    {
        length -= timePassed; 
    }

    public bool ResolveIncident(float date)
    {
        dateCompleted = date;
        hero.deployments++;
        villain.deployments++;
        bool result = false;

        float heroAttack = (float)hero.attack + Random.Range(-2.5f, 2.5f);
        float heroDefence = (float)hero.defence + Random.Range(-2.5f, 2.5f);

        float villainAttack = (float)villain.attack + Random.Range(-2.5f, 2.5f);
        float villainDefence = (float)villain.defence + Random.Range(-2.5f, 2.5f);

        float heroScore = heroAttack - villainDefence + 15;
        float villainScore = villainAttack - villainDefence + 15;

        float heroWinChance = heroScore / (villainScore + heroScore);

        Victim = hero;
        Attacker = villain;
        float winningScore = villainScore;

        Debug.Log(heroWinChance);
        float value = Random.value;
        Debug.Log(value);
        if (value < heroWinChance)
        {
            Debug.Log("HERo0");
            Victim = villain;
            Attacker = hero;
            winningScore = heroScore;
            result = true;
        }

        

        if (winningScore / 2 <= incidentStakes)
        {
            damageDone = incidentStakes;
        }
        else
        {
            damageDone = Random.Range(incidentStakes, winningScore/2);
        }

        

        Victim.TakeDamage(damageDone, Attacker);
        location.Deactivate();
        state = "Over";


        return result;
    }

    public void Expire(float date)
    {
        villain.deployments++;
        villain.SetAvailable(true);
        dateCompleted = date;
        location.Deactivate();
        state = "Expired";
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
