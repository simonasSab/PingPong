using UnityEngine;

public static class GameSettings
{
    // Set and get input for Starting speed
    public static void SetStartingSpeed(float value)
    {
        PlayerPrefs.SetFloat("startingSpeed", value);
    }

    public static float GetStartingSpeed()
    {
        return PlayerPrefs.GetFloat("startingSpeed", 5f);
    }

    // Set and get multiplier input for Speed-up after bounce
    public static void SetBounceSpeedUp(float value)
    {
        PlayerPrefs.SetFloat("bounceSpeedUp", value);
    }

    public static float GetBounceSpeedUp()
    {
        return PlayerPrefs.GetFloat("bounceSpeedUp", 1.05f);
    }

    // Set and get addifier input for Speed-up after goal
    public static void SetGoalSpeedUp(float value)
    {
        PlayerPrefs.SetFloat("goalSpeedUp", value);
    }

    public static float GetGoalSpeedUp()
    {
        return PlayerPrefs.GetFloat("goalSpeedUp", 0.5f);
    }

    // Set and get input for the score limit
    public static void SetScoreLimit(int value)
    {
        PlayerPrefs.SetInt("scoreLimit", value);
    }

    public static int GetScoreLimit()
    {
        return PlayerPrefs.GetInt("scoreLimit", 15);
    }
}
