using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour {

    public List<Lightbulb> controlled_bulbs;
    public Sprite sprite_on;
    public Sprite sprite_off;

    private SpriteRenderer spriteRenderer;
    public bool state = false;
      
	// Use this for initialization
	void Start ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
	    if(state)
        {
            spriteRenderer.sprite = sprite_on;
            foreach (Lightbulb lb in controlled_bulbs)
            {
                lb.state = true;
            }
        }
        else
        {
            spriteRenderer.sprite = sprite_off;
            foreach (Lightbulb lb in controlled_bulbs)
            {
                lb.state = false;
            }
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (state)
        {
            spriteRenderer.sprite = sprite_on;
            foreach (Lightbulb lb in controlled_bulbs)
            {
                lb.state = true;
            }
        }
        else
        {
            spriteRenderer.sprite = sprite_off;
            foreach (Lightbulb lb in controlled_bulbs)
            {
                lb.state = false;
            }
        }
    }
}
