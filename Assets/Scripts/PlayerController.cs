using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Comparers;

public class PlayerController : MonoBehaviour {
    [SerializeField]
    private ParticleSystem jumpParticle;

    private int jumpCounter = 0;
    private bool canMove = true;

    private Vector3 velocityBeforePhysicsUpdate;

    
    
    public void Update() {
        if (jumpCounter > 1)
            return;
        if (!canMove)
            return;
        // if (!Input.GetKeyDown(KeyCode.RightArrow) && !Input.GetKeyDown(KeyCode.LeftArrow) && Input.touchCount <= 0)
        //     return;
        //
        // Double screenWidth = Screen.width / 2;
        // Touch touch = Input.GetTouch(0);
        
            // || (touch.position.x >= screenWidth && touch.phase == TouchPhase.Began)
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            // Player.i.Rigidbody.velocity = Vector3.zero;
            Player.i.Rigidbody.AddForce(new Vector3(150, 150, 0));
            jumpParticle.Play();
            jumpCounter++;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            // Player.i.Rigidbody.velocity = Vector3.zero;
            Player.i.Rigidbody.AddForce(new Vector3(-150, 150, 0));
            jumpParticle.Play();
            jumpCounter++;
        }
    }

    private void FixedUpdate() {
        velocityBeforePhysicsUpdate = Player.i.Rigidbody.velocity;
    }

    private void OnCollisionEnter(Collision other) {
        Debug.Log(velocityBeforePhysicsUpdate);
        if (velocityBeforePhysicsUpdate.y < -7f && other.collider.tag == "Floor") {
            gameObject.SetActive(false);
            if (canMove) {
                CameraAnimatorHandler.cameraAnimator.SetBool("Destroy", true);
                Instantiate(Player.i.destroyPrefab, transform.position, transform.rotation);
                canMove = false;
            }
        }
        else {
            jumpCounter = 0;
        }
    }
}
