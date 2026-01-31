using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.UIElements;
using System.Collections;

public class Timer : MonoBehaviour
{
    public UnityEngine.UI.Toggle pauseButton;
    public UnityEngine.UI.Toggle speed1Button;
    public UnityEngine.UI.Toggle speed2Button;
    public UnityEngine.UI.Toggle speed3Button;
    public ToggleGroup toggleGroup;
    public TextMeshProUGUI dateLabel;
    // Seconds per day
    public float speed1 = 3f;
    public float speed2 = 1.5f;
    public float speed3 = 0.75f;

    public float currentSpeed = 0f;

    public int currentDate = 0;
    //private string currentButton = "Pause";

    private void Start()
    {
        StartCoroutine(TimeKeeping());
    }

    public void ButtonPressed()
    {

        switch (toggleGroup.GetFirstActiveToggle().name)
        {
            case "Speed1":
                currentSpeed = speed1;
                break;
            case "Speed2":
                currentSpeed = speed2;
                break;
            case "Speed3":
                currentSpeed = speed3;
                break;
        }

        Debug.Log(currentSpeed);
    }

    public IEnumerator TimeKeeping()
    {
        while (true)
        {
            if (!pauseButton.isOn)
            {
                yield return new WaitForSeconds(currentSpeed);
                currentDate++;
                dateLabel.text = "Day: " + currentDate.ToString();
            }
        }
        
    }
}
