using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField]
    private ParticleSystem jumpParticle;

    private int jumpCounter = 0;
    private bool canMove = true;

    private Vector3 velocityBeforePhysicsUpdate;

    public void Update() {
        // if (jumpCounter > 1)
        //     return;
        if (!canMove)
            return;
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            // Player.i.Rigidbody.velocity = Vector3.zero;
            Player.i.Rigidbody.AddForce(new Vector3(150, 0, 0));
            jumpParticle.Play();
            jumpCounter++;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            // Player.i.Rigidbody.velocity = Vector3.zero;
            Player.i.Rigidbody.AddForce(new Vector3(-150, 0, 0));
            jumpParticle.Play();
            jumpCounter++;
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            Player.i.Rigidbody.AddForce(new Vector3(0, 150, 0));
            jumpParticle.Play();
            jumpCounter++;
        }
    }

    private void FixedUpdate() {
        velocityBeforePhysicsUpdate = Player.i.Rigidbody.velocity;
    }

    private void OnCollisionEnter(Collision other) {
        Debug.Log(velocityBeforePhysicsUpdate);
        if (velocityBeforePhysicsUpdate.y < -7f) {
            gameObject.SetActive(false);
            if (canMove) {
                Instantiate(Player.i.destroyPrefab, transform.position, transform.rotation);
                canMove = false;
            }
        }
    }
}
