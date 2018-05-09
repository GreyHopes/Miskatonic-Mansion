using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MovingObject {

	// Use this for initialization
	protected override void Start ()
    {
        base.Start();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        { 
            Move(0, 1);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Move(0,-1);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Move(-1, 0);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Move(1,0);
        }

    }
}
