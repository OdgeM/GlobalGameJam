using TMPro;
using UnityEngine;

public class IncidentPanel : MonoBehaviour
{
    public GameObject locationNode;
    public TextMeshProUGUI incidentName;
    public TextMeshProUGUI villainName;
    public HeroSprite sprite;

    public RectTransform rectTransform;
    
    
        
    public void AssignIncident(string incidentDescription)
    {
        incidentName.text = incidentDescription;
    }

    public void SetVillain(string name, HeroSprite _sprite)
    {
        sprite = _sprite;
        villainName.text = "by " + name;
    }
}
