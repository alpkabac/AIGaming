using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public string NPCName; // The NPC's name
    public Image portrait; // The NPC's portrait image
    public Dictionary<string, string> routines; // The NPC's routines for each time of day (morning, afternoon, evening, night)
    public string[] responses; // The NPC's responses to player messages

    private ConversationManager conversationManager; // A reference to the ConversationManager script

    public NPC(Dictionary<string, string> routines)
    {
        this.routines = routines;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Get a reference to the ConversationManager script
        conversationManager = FindObjectOfType<ConversationManager>();
    }

    // Talk to the NPC
    public void Talk(string message)
    {
        // Add the player's message to the conversation history and display it in the chatbox
        conversationManager.AddMessage(true, message, portrait);

        // Get a random response from the NPC's responses list
        int responseIndex = Random.Range(0, responses.Length);
        string response = responses[responseIndex];

        // Add the NPC's response to the conversation history and display it in the chatbox
        conversationManager.AddMessage(false, response, portrait);
    }

    public string GetRoutineForTime(string timeOfDay)
    {
            return routines[timeOfDay];
    }
    
}

