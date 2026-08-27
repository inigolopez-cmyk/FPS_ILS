using UnityEngine;

public class TriggerController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) // When the player enters the trigger, open the door
    {
        GameEvents.Instance.OpenTriggerDoor(); // Call the event to open the door
    } // door = script door, trigger = script trigger

    private void OnTriggerExit(Collider other) // When the player exits the trigger, close the door
    {
        GameEvents.Instance.CloseTriggerDoor(); // Call the event to close the door
    }
}
