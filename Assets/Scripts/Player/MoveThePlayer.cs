using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class MoveThePlayer : MonoBehaviour {
    
    public Transform PointToMove;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        
	}
    void OnTriggerEnter(Collider other)
    {
        if (other == null || PointToMove == null) return;

        GameObject player = other.gameObject;
        player.transform.position = PointToMove.transform.position;
    }
}