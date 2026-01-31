using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMenu : MonoBehaviour
{
    public GameObject contentBox;
    public List<CharacterPanel> panelList = new();

    public void PlacePanel(CharacterPanel panel)
    {
        if (panelList.Count > 0)
        {
            panel.rectTransform.anchoredPosition -= new Vector2(0, 115)*panelList.Count; 
        }
        
        panelList.Add(panel);
    }
}
