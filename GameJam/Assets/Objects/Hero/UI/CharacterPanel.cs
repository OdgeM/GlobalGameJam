using TMPro;
using UnityEngine;

public class CharacterPanel : MonoBehaviour
{
    public GameObject locationNode;
    public TextMeshProUGUI characterName;
    public Character character;

    public RectTransform rectTransform;
    
    

    public void AssignCharacter(Character _character)
    {
        character = _character;
        characterName.text = character.heroName;
    }
}
