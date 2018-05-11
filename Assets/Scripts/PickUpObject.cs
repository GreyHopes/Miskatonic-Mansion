using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickUpObject : MonoBehaviour
{
    public Sprite Srite;
    protected string objectName;
    public void OnPickUp()
    {
        DialogueTrigger dt = GetComponent<DialogueTrigger>();
        dt.TriggerDialogue();
        this.gameObject.SetActive(false);
    }

    //Function that triggers when the object can interact with another game object
    public abstract void InteractWith <T>(T Component) where T : Component;
}
