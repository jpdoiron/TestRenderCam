using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkangle : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    public Transform cube;
	// Update is called once per frame
	void Update () {
        float angle = Vector3.SignedAngle(transform.position, Vector3.forward, Vector3.up);
        if (angle < 0) angle = 360 + angle;
        Debug.Log(angle);
	}
}
