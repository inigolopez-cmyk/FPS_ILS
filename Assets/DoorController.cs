using UnityEngine;
using DG.Tweening;

public class DoorController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() // Subscribe to events when the object is enabled
    {
        GameEvents.Instance.onDoorTriggerEnter += OpenDoor; // Subscribe to the event when the object is enabled
        GameEvents.Instance.onDoorTriggerExit += CloseDoor; // Subscribe to the event when the object is enabled
    }

    private void OnDisable() // Unsubscribe from events when the object is disabled
    {
        GameEvents.Instance.onDoorTriggerEnter -= OpenDoor; // Unsubscribe from the event when the object is disabled
        GameEvents.Instance.onDoorTriggerExit -= CloseDoor; // Unsubscribe from the event when the object is disabled
    }

    private void OnDestroy() // Unsubscribe from events when the object is destroyed
    {
        GameEvents.Instance.onDoorTriggerEnter -= OpenDoor; // Unsubscribe from the event when the object is destroyed
        GameEvents.Instance.onDoorTriggerExit -= CloseDoor; // Unsubscribe from the event when the object is destroyed
    }

    void OpenDoor() // Method to open the door
    {
        //transform.Translate(new Vector3 (-4.29f, 2.56f, -10.3f)); // Move the door to the open position
        transform.DOMoveY(0,2); // Move the door to the open position using DOTween
    }

    void CloseDoor() // Method to close the door
    {
        //transform.Translate(new Vector3 (4.29f, -2.56f, 10.3f)); // Move the door to the closed position
        transform.DOMoveY(3.36f, 2); // Move the door to the closed position using DOTween
    }
}
