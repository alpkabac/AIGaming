using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LocationManager : MonoBehaviour
{
    public string currentLocation; // The current location (e.g. "restaurant", "park")
    public GameObject buttonPrefab; // A prefab for the NPC buttons
    public Transform buttonContainer; // A container for the NPC buttons
    public TMP_InputField messageBox;

    // Change the player's location to the specified location
    public void ChangeLocation(string location)
    {
        currentLocation = location;
        UpdateNPCButtons();
    }

    // Update the NPC buttons for the current location
    void UpdateNPCButtons()
    {
        // Clear the current NPC buttons
        foreach (Transform child in buttonContainer)
        {
            Destroy(child.gameObject);
        }

        // Get a list of NPCs at the current location
        NPC[] npcs = GetNPCsAtLocation(currentLocation, GameTimeManager.timeOfDay);

        // Iterate through the NPCs
        foreach (NPC npc in npcs)
        {
            // Check the NPC's routine at the current time of day
            string routine = npc.GetRoutineForTime(GameTimeManager.timeOfDay);

            // If the NPC has a routine at the current time of day, create a button for it
            if (routine != null)
            {
                // Create a new NPC button and set its properties
                GameObject button = Instantiate(buttonPrefab, buttonContainer);
                Text buttonText = button.GetComponentInChildren<Text>();
                buttonText.text = npc.name;
                button.GetComponent<Button>().onClick.AddListener(() => { npc.Talk(messageBox.text); });
            }
        }
    }

    // Get a list of NPCs at the specified location
    public NPC[] GetNPCsAtLocation(string location, string timeOfDay)
    {
        // Get a list of all NPCs in the scene
        // ReSharper disable once IdentifierTypo
        NPC[] npcs = FindObjectsOfType<NPC>();

        // Return a list of NPCs that are at the specified location and have a routine at the specified time of day
        return npcs.Where(npc => npc.routines.ContainsKey(timeOfDay)).ToArray();
    }
}
