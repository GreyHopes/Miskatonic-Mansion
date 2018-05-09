using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MovingObject : MonoBehaviour {

    private BoxCollider2D boxCollider;
    private Rigidbody2D rb2D;
    public LayerMask layer;
    public Tilemap wallTilemap;

	// Use this for initialization
	protected virtual void Start ()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rb2D = GetComponent<Rigidbody2D>();
	}

    protected void Move (int xDir,int yDir)
    {
        print(transform.position);
        Vector2 start = transform.position;
        Vector2 end = start + new Vector2(xDir, yDir);

      

        if (!getCell(wallTilemap,end))
            rb2D.MovePosition(end);
    }

    private TileBase getCell(Tilemap tilemap, Vector2 cellWorldPos)
    {
        return tilemap.GetTile(tilemap.WorldToCell(cellWorldPos));
    }
    private bool hasTile(Tilemap tilemap, Vector2 cellWorldPos)
    {
        return tilemap.HasTile(tilemap.WorldToCell(cellWorldPos));
    }
}
