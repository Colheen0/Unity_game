using UnityEngine;

public class OSCBridge : MonoBehaviour 
{
    public DoorController[] AllDoors; 

public void TriggerGlobal()
{
    if (AllDoors == null) return; 
    foreach(var door in AllDoors)
    {
        if (door != null) 
        {
            door.ToggleDoor(); 
        }
    }
}
}