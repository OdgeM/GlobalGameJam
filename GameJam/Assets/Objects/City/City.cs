using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class City : MonoBehaviour
{
    public string cityName;
    public string countryName;
    public RawImage image;
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

    public void Deactivate()
    {
        image.enabled = false;
    }
}
