using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class IncidentMenu : MonoBehaviour
{
    public GameObject contentBox;
    public List<IncidentPanel> panelList = new();

    public void PlacePanel(IncidentPanel panel)
    {
        if (panelList.Count > 0)
        {
            panel.rectTransform.anchoredPosition -= new Vector2(0, 115)*panelList.Count; 
        }
        
        panelList.Add(panel);
    }
}
