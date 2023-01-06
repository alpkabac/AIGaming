using UnityEngine;

public class GameTimeManager : MonoBehaviour
{
    public static string timeOfDay; // The current time of day (morning, afternoon, evening, or night)
    public int actionsTaken; // The number of actions taken by the player

    // Set the time of day to the specified value
    public void SetTimeOfDay(string time)
    {
        timeOfDay = time;
    }

    // Advance the time of day to the next interval
    public void AdvanceTime()
    {
        actionsTaken++;
        if (actionsTaken >= 4)
        {
            actionsTaken = 0;
            if (timeOfDay == "morning")
            {
                timeOfDay = "afternoon";
            }
            else if (timeOfDay == "afternoon")
            {
                timeOfDay = "evening";
            }
            else if (timeOfDay == "evening")
            {
                timeOfDay = "night";
            }
            else
            {
                timeOfDay = "morning";
            }
        }
    }
}