using UnityEngine;

public class TriggerController : MonoBehaviour
{
    [SerializeField] 
    private DoorController door;

    private void OnTriggerEnter(Collider other) // When the player enters the trigger, open the door
    {
        if (!other.CompareTag("Player")) return;
        GameEvents.Instance.OpenTriggerDoor(door); // Call the event to open the door
    } // door = script door, trigger = script trigger

    private void OnTriggerExit(Collider other) // When the player exits the trigger, close the door
    {
        if (!other.CompareTag("Player")) return;
        GameEvents.Instance.CloseTriggerDoor(door); // Call the event to close the door
    }
}
