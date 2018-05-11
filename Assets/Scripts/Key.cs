using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : PickUpObject {

    public int id;
    public override void InteractWith<T>(T Component)
    {
        throw new System.NotImplementedException();
    }

    // Use this for initialization
    void Start ()
    {
        objectName = "Key";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
