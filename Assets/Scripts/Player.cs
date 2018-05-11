using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MovingObject {

    public Tilemap doorsTilemap;
    public LayerMask blockingLayer;
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
        Vector2 start = transform.position;
        Vector2 end = start + new Vector2(xDir, yDir);

        boxCollider.enabled = false;
        RaycastHit2D hit = Physics2D.Linecast(start, end, blockingLayer);
        boxCollider.enabled = true;

        if (hit.transform == null)
        {
            if (getCell(doorsTilemap, end))
                SwitchRoom(end);

            if (!getCell(wallTilemap, end))
                rb2D.MovePosition(end);
        }
        else
        {
            ColisionHandling(hit);
        }
           

    }
    protected void SwitchRoom(Vector3 doorUsed)
    {
        Vector3 camPos = CameraController.instance.GetCameraPosition();

        //We'll look at the position of the door used relative to the camera center to determine in which way we will move the camera
        if (Mathf.Abs(doorUsed.x - camPos.x) < Mathf.Abs(doorUsed.y - camPos.y)) 
        {
            //If the y component is greater in absolute value it means that we have to move vertically
            //We'll use the sign of door.y - camPos.y to determine if we have to go up or down

            CameraController.instance.MoveVertically(11 * (int)Mathf.Sign(doorUsed.y - camPos.y));
            Vector3 end = new Vector3(transform.position.x, transform.position.y + ( 4 * (int)Mathf.Sign(doorUsed.y - camPos.y)));
            rb2D.MovePosition(end);
        }
        else
        {
            //If the x component is greater it means that we have to move horizontally
            CameraController.instance.MoveHorizontally(15 * (int)Mathf.Sign(doorUsed.x - camPos.x));
            Vector3 end = new Vector3(transform.position.x + (8 * (int)Mathf.Sign(doorUsed.x - camPos.x)), transform.position.y);
            rb2D.MovePosition(end);

        }
    }

    public void ColisionHandling(RaycastHit2D hit)
    {
        if (hit.transform.tag == "Lever")
        {
            Lever lever = hit.transform.GetComponent<Lever>();
            lever.state = !lever.state;
        }
        if(hit.transform.tag == "Dialogue Trigger")
        {
            DialogueTrigger dialogueTrigger = hit.transform.GetComponent<DialogueTrigger>();
            dialogueTrigger.TriggerDialogue();
        }
    }
}
