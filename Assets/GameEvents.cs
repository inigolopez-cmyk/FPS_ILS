using System;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents Instance; // Singleton instance of the GameEvents class

    public event Action onDoorTriggerEnter; // Event for when the player enters the trigger
    public event Action onDoorTriggerExit; // Event for when the player exits the trigger



    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        
    }

    public void OpenTriggerDoor() // Method to invoke the event when the player enters the trigger
    {
        onDoorTriggerEnter(); // Invoke the event
    }

    public void CloseTriggerDoor() // Method to invoke the event when the player exits the trigger
    {
        onDoorTriggerExit(); // Invoke the event
    }
}
