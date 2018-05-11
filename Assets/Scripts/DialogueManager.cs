using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    private Queue<string> setences;
    public static DialogueManager instance = null;

    public Animator animator;

    public Text nameText;
    public Text dialogueText;
    private bool dialogueInProcess;
	// Use this for initialization
	void Start ()
    {
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

        dialogueInProcess = false;
        setences = new Queue<string>();
	}

    void Update()
    {
        if(dialogueInProcess)
        {
            if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.E))
            {
                DisplayNextSetence();
            }
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                EndDialogue();
            }
        }
    }

    public void startDialogue(Dialogue dialogue)
    {
        dialogueInProcess = true;
        animator.SetBool("IsOpen", true);
        nameText.text = dialogue.name;

        setences.Clear();

        foreach(string setence in dialogue.setences)
        {
            setences.Enqueue(setence);
        }

        DisplayNextSetence();
    }

    public void DisplayNextSetence()
    {
        if(setences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string setence = setences.Dequeue();
        dialogueText.text = setence;
    }

    void EndDialogue()
    {
        dialogueInProcess = false;
        setences.Clear();
        animator.SetBool("IsOpen", false);
        Debug.Log("End of conversation");
    }
}
