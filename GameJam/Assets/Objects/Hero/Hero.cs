using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public int characterSeed = 1234567;
    public float alienChance = 0.1f;
    private bool isAlien = false; 

    [Header("Visuals")]

    public HeroSprite sprite;

    public float pantsChance = .5f;
    public float capeChance = .5f;
    public float insigniaChance = .5f;
    public float headwearChance = .5f;
    public float armAccentChance = .25f;
    public float baldChance = 0.1f;

    private float goldenRatio = 0.618033988749895f;

    public List<Color> humanSkinColours;
    public List<Color> hairColours;

    private Color mainColour;
    private Color accentColour;

    private Color skinColour;
    private Color eyeColour = Color.white;

    private bool hasHair = true;
    private Color hairColour;
    private int hairIndex = 0;

    private Color bodyColour;
    private Color armColour;
    private Color legColour;
    private Color bootColour;

    private bool hasHeadwear = false;
    private Color headwearColour;
    private int headwearIndex = 0;

    private bool hasPants = false;
    private Color pantsColour;

    private bool hasCape = false;
    private Color capeColour;

    private bool hasInsignia = false;
    private Color insigniaColour;
    private int insigniaIndex = 0;  

    [Header("Details")]
    public string heroName;
    public string realName;
    public int age;
    public string hometown;
    public string backstory;

    public void Start()
    {
        //Random.InitState(characterSeed);

        if (Random.value < alienChance)
        {
            isAlien = true;
        }

        GenerateColours();
        SetSprite();
    }
    
    private void GenerateColours()
    {
        if (isAlien) {
            skinColour = Random.ColorHSV();
            hasHair = false;
        }
        else
        {
            int skinIdx = Random.Range(0, humanSkinColours.Count);
            skinColour = humanSkinColours[skinIdx];


            if (Random.value > baldChance)
            {
                int hairColourIdx = Random.Range(0, hairColours.Count);
                hairColour = hairColours[hairColourIdx];

                hairIndex = Random.Range(0, sprite.hairSprites.Count); 
            }
            else
            {
                hasHair = false;
            }
        }


        Vector3 mainColourHSV = GenerateColour();
        mainColour = Color.HSVToRGB(mainColourHSV.x,mainColourHSV.y,mainColourHSV.z);

        Vector3 accentColourHSV = GenerateColour();
        float multiplier = 1;
        if (Random.value > 0.5)
        {
            multiplier = -1;
        }

        accentColourHSV.x = mainColourHSV.x + multiplier * goldenRatio;

        accentColour = Color.HSVToRGB(accentColourHSV.x,accentColourHSV.y, accentColourHSV.z);

        bodyColour = mainColour;

        if (Random.value < pantsChance)
        {
            hasPants = true;
            pantsColour = accentColour;
            legColour = mainColour;
            bootColour = accentColour;
        }
        else
        {
            hasPants = false;
            legColour = accentColour;
            bootColour = mainColour;
        }

        if (Random.value < capeChance)
        {
            hasCape = true;
            capeColour = accentColour;
        }

        if (Random.value < insigniaChance)
        {
            hasInsignia = true;
            insigniaColour = accentColour;

            insigniaIndex = Random.Range(0, sprite.insigniaSprites.Count);
        }

        if (Random.value < armAccentChance)
        {
            armColour = accentColour;   
        }
        else
        {
            armColour = mainColour;
        }

        if (Random.value < headwearChance)
        {
            hasHeadwear = true;
            headwearColour = accentColour;

            headwearIndex = Random.Range(0, sprite.headwearSprites.Count);

            eyeColour = Color.white;
        }

    }

    private Vector3 GenerateColour()
    {
        float h = Random.value;
        float s = Random.value;
        float v = Random.value;

        return new Vector3(h, s, v);
    }

    private void SetSprite()
    {
        sprite.SetSkinColour(skinColour);
        sprite.SetEyeColour(eyeColour);
        sprite.SetSuitColour(bodyColour, armColour, legColour, bootColour);
        sprite.SetHair(hasHair, hairIndex, hairColour);
        sprite.SetHeadwear(hasHeadwear, headwearIndex, headwearColour);
        sprite.SetInsignia(hasInsignia, insigniaIndex, insigniaColour);
        sprite.SetPants(hasPants, pantsColour);
        sprite.SetCape(hasCape, capeColour);
    }

}
