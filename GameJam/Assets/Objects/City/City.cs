using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class City : MonoBehaviour
{
    public string cityName;
    public string countryName;
    private RawImage image;

    public List<string> features;

    void Awake()
    {
        image = GetComponent<RawImage>();
        image.enabled = false;
    }

    public void Activate()
    {
        image.enabled = true;
    }
}
