using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public enum InteractionType { 
        Click,
        Read,
        Collect
    }

    public InteractionType interactionType;
    public KeyCode interactKey;
    public KeyCode altKey = KeyCode.None;

    public abstract string GetDescription();
    public abstract void Interact(bool alt = false);
}
