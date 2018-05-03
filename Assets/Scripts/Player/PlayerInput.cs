using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

	    public float speed = 2.5f;
	    bool canMove;
	    Vector3 pos;
	    Transform tr;

	    void Start ()
	    {
	        bool canMove = true;

	    }

	    void Movement ()
	    {
	        if (Input.GetKey (KeyCode.UpArrow))
	        {
	            transform.Translate(Vector3.up * speed * Time.deltaTime);
	        }
	        if (Input.GetKey (KeyCode.RightArrow))
	        {
	            transform.Translate(Vector3.left * speed * Time.deltaTime);
	        }
	        if (Input.GetKey (KeyCode.DownArrow))
	        {
	            transform.Translate(Vector3.down * speed * Time.deltaTime);
	        }
	        if (Input.GetKey (KeyCode.LeftArrow))
	        {
	            transform.Translate(Vector3.right * speed * Time.deltaTime);
	        }

	    }

	    void FixedUpdate ()
	    {
	        if (canMove = true)
	        {
	            Movement ();

	        }

	    }
	}
