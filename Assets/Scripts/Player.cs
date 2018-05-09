using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MovingObject {

    public Tilemap doorsTilemap;
    // Use this for initialization
    protected override void Start ()
    {
        base.Start();
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

    protected override void Move(int xDir, int yDir)
    {
        print(transform.position);
        Vector2 start = transform.position;
        Vector2 end = start + new Vector2(xDir, yDir);

        if (getCell(doorsTilemap, end))
            print("Change de pièce");
            //SwitchRoom(end);

        if (!getCell(wallTilemap, end))
            rb2D.MovePosition(end);
    }

    public bool test = true;
    protected void SwitchRoom(Vector3 doorUsed)
    {
        if (test)
        {
          
         
            test = false;
        }
       
    }

}
