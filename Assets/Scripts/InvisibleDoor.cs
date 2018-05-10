using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleDoor : MonoBehaviour {

    public List<Lightbulb> controlling_bulbs;
    private BoxCollider2D boxCollider;

	// Use this for initialization
	void Start ()
    {
        boxCollider = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        bool test = true;
        int i = 0;
        while(test && i < controlling_bulbs.Count)
        {
            test = test && controlling_bulbs[i].state;
            i++;
        }

        if(test)
        {
            boxCollider.enabled = false;
        }
        else
        {
            boxCollider.enabled = true;
        }
	}
}
