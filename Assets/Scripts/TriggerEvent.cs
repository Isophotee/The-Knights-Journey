using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum TypeTag
{
    Player,       // The player
    Trap,         // Traps that damage the player
    Checkpoint,   // Checkpoints to save respawn position
    Finish,       // Finish line to end the level
    Trigger,      // General-purpose trigger
}

public class TriggerEvent : MonoBehaviour
{
    public TypeTag targetTag; // The tag of the object this trigger interacts with
    public UnityEvent<GameObject> OnTrigger; // Event triggered on interaction

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(targetTag.ToString())) // Compare the target tag
        {
            Debug.Log($"{gameObject.tag} interacted with {col.gameObject.tag}");
            OnTrigger?.Invoke(col.gameObject); // Trigger the UnityEvent
        }
    }
}
