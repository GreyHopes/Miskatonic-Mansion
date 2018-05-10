using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightbulb : MonoBehaviour {


    public Sprite sprite_on;
    public Sprite sprite_off;
    private SpriteRenderer spriteRenderer;
    public bool state = false;

    // Use this for initialization
    void Start ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(state)
        {
            spriteRenderer.sprite = sprite_on;
        }
        else
        {
            spriteRenderer.sprite = sprite_off;
        }
	}
}
