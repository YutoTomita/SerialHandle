using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterControll : MonoBehaviour {

    float horizontal, vertical;
    Rigidbody rb;
    int waittime;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    void Update() {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Jump");
    }

    void FixedUpdate() {
        CharacterController controller = GetComponent<CharacterController>();
        float angleZ = transform.localEulerAngles.z;
        // カメラの方向から、X-Z平面の単位ベクトルを取得
        var cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        var vectorAngle = Quaternion.Euler(0f, -1f*angleZ, 0f) * cameraForward * vertical;
        var fly = new Vector3(0,1,0) * vertical;
        //vectorAngle = vectorAngle * 5f;
        fly = fly / 2f;

        if (vertical != 0 && waittime == 0){
            waittime = 50;
            rb.velocity = vectorAngle + fly;
        }else if(waittime > 0){
            waittime--;
        }
        
    }
}
