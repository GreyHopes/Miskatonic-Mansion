using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MovingObject {
   

    // Use this for initialization
    protected override void Start ()
    {
        base.Start();
	}

    protected override void Move(int xDir, int yDir)
    {
        print(transform.position);
        Vector2 start = transform.position;
        Vector2 end = start + new Vector2(xDir, yDir);



        if (!getCell(wallTilemap, end))
            rb2D.MovePosition(end);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Move(0, 1);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Move(0, -1);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Move(-1, 0);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Move(1, 0);
        }
    }



}
