using System.Collections.Generic;
using UnityEngine;

// ReSharper disable once InconsistentNaming
public class NPCData : MonoBehaviour {
public new string name; // The name of the NPC
public Dictionary<string, string> routines; // The NPC's routines, with the keys representing the time of day (morning, afternoon, evening, night) and the values representing the location and action (e.g. "restaurant -> breakfast")

    public NPCData(string name, Dictionary<string, string> routines)
    {
        this.name = name;
        this.routines = routines;
    }

}
