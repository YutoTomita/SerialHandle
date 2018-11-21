using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraVector : MonoBehaviour {
    Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GameObject.Find("Main Camera").GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 speed = rb.velocity.normalized;
        this.transform.Translate(speed);
	}
}
