using System.Threading.Tasks;
using UnityEngine;
using TMPro;


public class MenuGameSettings : MonoBehaviour
{
    // Information for user about currently set parameters
    public GameObject alert1;
    public GameObject alert2;
    public GameObject alert3;
    public GameObject alert4;

    // Parameters are displayed at start of program
    void Start()
    {
        alert1.GetComponent<TextMeshProUGUI>().text = "Set to " + GameSettings.GetStartingSpeed().ToString();
        alert2.GetComponent<TextMeshProUGUI>().text = "Set to " + GameSettings.GetBounceSpeedUp().ToString();
        alert3.GetComponent<TextMeshProUGUI>().text = "Set to " + GameSettings.GetGoalSpeedUp().ToString();
        alert4.GetComponent<TextMeshProUGUI>().text = "Set to " + GameSettings.GetScoreLimit().ToString();
    }

    // Methods for displaying parameters with delay (2s)
    public async Task Alert1Delayed()
    {
        await Task.Delay(2000);
        alert1.GetComponent<TextMeshProUGUI>().text = "Set to " + GameSettings.GetStartingSpeed().ToString();
    }
    public async Task Alert2Delayed()
    {
        await Task.Delay(2000);
        alert2.GetComponent<TextMeshProUGUI>().text = "Set to " + GameSettings.GetBounceSpeedUp().ToString();
    }
    public async Task Alert3Delayed()
    {
        await Task.Delay(2000);
        alert3.GetComponent<TextMeshProUGUI>().text = "Set to " + GameSettings.GetGoalSpeedUp().ToString();
    }
    public async Task Alert4Delayed()
    {
        await Task.Delay(2000);
        alert4.GetComponent<TextMeshProUGUI>().text = "Set to " + GameSettings.GetScoreLimit().ToString();
    }

    // After user enters value, text input box calls THIS. If value is correct, new Starting Speed is set.
    // If not, alert message is sent, and after delay old value is displayed.
    public async void StartingSpeed(string value)
    {
        if (float.TryParse(value, out float floatValue) && floatValue >= 1 && floatValue <= 10)
        {
            GameSettings.SetStartingSpeed(floatValue);
            alert1.GetComponent<TextMeshProUGUI>().text = "Set to " + floatValue;
        }
        else
        {
            alert1.GetComponent<TextMeshProUGUI>().text = "Provide number from 1.0 to 10.0";
            await Alert1Delayed();
        }
    }

    // After user enters value, text input box calls THIS. If value is correct, new Bounce Speed Up is set.
    // If not, alert message is sent, and after delay old value is displayed.
    public async void BounceSpeedUp(string value)
    {
        if (float.TryParse(value, out float floatValue) && floatValue >= 1 && floatValue <= 2)
        {
            GameSettings.SetBounceSpeedUp(floatValue);
            alert2.GetComponent<TextMeshProUGUI>().text = "Set to " + floatValue;
        }
        else
        {
            alert2.GetComponent<TextMeshProUGUI>().text = "Provide number from 1.0 to 2.0";
            await Alert2Delayed();
        }
    }

    // After user enters value, text input box calls THIS. If value is correct, new Goal Speed Up is set.
    // If not, alert message is sent, and after delay old value is displayed.
    public async void GoalSpeedUp(string value)
    {
        if (float.TryParse(value, out float floatValue) && floatValue >= 0 && floatValue <= 4)
        {
            GameSettings.SetGoalSpeedUp(floatValue);
            alert3.GetComponent<TextMeshProUGUI>().text = "Set to " + floatValue;
        }
        else
        {
            alert3.GetComponent<TextMeshProUGUI>().text = "Please provide number from 0.0 to 4.0";
            await Alert3Delayed();
        }
    }

    // After user enters value, text input box calls THIS. If value is correct, new Score Limit is set.
    // If not, alert message is sent, and after delay old value is displayed.
    public async void ScoreLimit(string value)
    {
        if (int.TryParse(value, out int intValue) && intValue >= 1 && intValue <= 100)
        {
            GameSettings.SetScoreLimit(intValue);
            alert4.GetComponent<TextMeshProUGUI>().text = "Set to " + intValue;
        }
        else
        {
            alert4.GetComponent<TextMeshProUGUI>().text = "Please provide a whole number from 1 to 100";
            await Alert4Delayed();
        }
    }
}
