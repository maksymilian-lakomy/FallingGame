using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public void Update() {
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            Debug.Log("Space pressed");
            Player.i.Rigidbody.velocity = Vector3.zero;
            Player.i.Rigidbody.AddForce(new Vector3(150, 250, 0));
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            Debug.Log("Space pressed");
            Player.i.Rigidbody.velocity = Vector3.zero;
            Player.i.Rigidbody.AddForce(new Vector3(-150, 250, 0));
        }
    }
}
