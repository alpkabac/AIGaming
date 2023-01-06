using System.Linq;
using UnityEngine;

// ReSharper disable once InconsistentNaming
public class NPCManager : MonoBehaviour
{

    public string[] names; // The list of NPC names
    public string[] locations; // The list of possible locations
    public string[] actions; // The list of possible actions

    public GameObject npcPrefab; // The prefab for the NPC game object
    public Transform npcParent; // The parent object for the NPC game objects (used to keep the hierarchy organized)

    void Start()
    {
        string[] availableNames = names.ToArray();
        // Generate NPCs with random names and routines
        for (int i = 0; i < 5; i++)
        {
            // Randomly select a name
            // Randomly select a name from the available names list
            int nameIndex = Random.Range(0, availableNames.Length);
            {
                string npcName = availableNames[nameIndex];

                // Remove the selected name from the available names list
                availableNames = availableNames.Where(val => val != npcName).ToArray();
            
                // Create the NPC game object and set its name
                GameObject npc = Instantiate(npcPrefab, npcParent);
                NPC npcScript = npc.GetComponent<NPC>();
                npcScript.name = npcName;

                // Generate a random routine for each time of day
                for (int j = 0; j < 4; j++)
                {
                    string timeOfDay = "";
                    if (j == 0) timeOfDay = "morning";
                    else if (j == 1) timeOfDay = "afternoon";
                    else if (j == 2) timeOfDay = "evening";
                    else if (j == 3) timeOfDay = "night";
                    
                    // Randomly select a location and an action
                    int locationIndex = Random.Range(0, locations.Length);
                    int actionIndex = Random.Range(0, actions.Length);
                    string location = locations[locationIndex];
                    string action = actions[actionIndex];

                    // Set the NPC's routine for the current time of day
                    npcScript.routines[timeOfDay] = location + " -> " + action;
                }
            }
        }
    }
}
