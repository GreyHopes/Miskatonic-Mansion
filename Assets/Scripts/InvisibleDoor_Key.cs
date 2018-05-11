using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleDoor_Key : MonoBehaviour {

    public Key keyToOpen;
    public DialogueTrigger triggerLocked;
    public DialogueTrigger triggerOpen;

    public void tryToOpen(List<Key> keychain)
    {
        int i = 0;
        bool test = false;

        while(!test && i < keychain.Count)
        {
            test = (keychain[i].id == keyToOpen.id);
        }

        if (test)
            Open();
        else
            Locked();
    }

    public void Locked()
    {
        triggerLocked.TriggerDialogue();
    }

    public void Open()
    {
        triggerOpen.TriggerDialogue();
        gameObject.SetActive(false);
    }
}
