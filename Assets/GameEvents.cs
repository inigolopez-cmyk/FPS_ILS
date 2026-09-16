using System;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents Instance; // Singleton instance of the GameEvents class

    //public event Action onDoorTriggerEnter; // Event for when the player enters the trigger
    //public event Action onDoorTriggerExit; // Event for when the player exits the trigger

    public event Action<DoorController> onDoorTriggerEnter;
    public event Action<DoorController> onDoorTriggerExit;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        
    }

    //public void OpenTriggerDoor() // Method to invoke the event when the player enters the trigger
    //{
    //    onDoorTriggerEnter(); // Invoke the event
    //}

    //public void CloseTriggerDoor() // Method to invoke the event when the player exits the trigger
    //{
    //    onDoorTriggerExit(); // Invoke the event
    //}

    public void OpenTriggerDoor(DoorController door)
    {
        if (onDoorTriggerEnter != null)
        {
            onDoorTriggerEnter(door);
        }
    }

    public void CloseTriggerDoor(DoorController door)
    {
        if (onDoorTriggerExit != null)
        {
            onDoorTriggerExit(door);
        }
    }

}
