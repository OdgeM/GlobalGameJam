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
        Debug.Log(character.heroName);
        characterName.text = character.heroName;
    }
}
