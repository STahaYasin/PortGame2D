using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class MoveThePlayer : MonoBehaviour {

    public Transform Player;
    public Transform PointToMove;
    private Collider collider;

	// Use this for initialization
	void Start () {
        collider = transform.GetComponent<Collider>();
	}
	
	// Update is called once per frame
	void Update () {
        if (collider == null) return;

        
	}
    public void MovePlayer()
    {

    }
    void OnCollisionEnter(Collision collision)
    {
        //Output the Collider's GameObject's name
        Debug.Log(collision.collider.name);
    }
}