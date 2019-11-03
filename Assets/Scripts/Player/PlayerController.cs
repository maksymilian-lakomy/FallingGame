using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Comparers;

public class PlayerController : MonoBehaviour {
    [SerializeField]
    private ParticleSystem jumpParticle;

    private int jumpCounter = 0;

    private Vector3 velocityBeforePhysicsUpdate;

    private Rigidbody rigidbody;

    private void Awake() {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update() {

        Vector2? vectorDirection = null;
        // Mobile Handling
        if (TouchManager.HorizontalTouch() != Vector2.zero)
            vectorDirection = TouchManager.HorizontalTouch();
        // Keyboard Handling
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
            vectorDirection = new Vector2(-1f, 0f);
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            vectorDirection = new Vector2(1f, 0f);
        
        if (vectorDirection == null)
            return;

        Direction direction;
        if (vectorDirection.Value.x == -1)
            direction = Direction.Left;
        else
            direction = Direction.Right;

        Movement(direction);
    }

    private void FixedUpdate() {
        velocityBeforePhysicsUpdate = rigidbody.velocity;
    }

    private bool Movement(Direction direction) {
        float x = .0f;
        if (direction == Direction.Right)
            x = 150f;
        if (direction == Direction.Left)
            x = -150f;
        rigidbody.AddForce(new Vector3(x, 150, 0));
        return true;
    }
    
    private void OnCollisionEnter(Collision other) {
        Debug.Log(velocityBeforePhysicsUpdate);
        if (velocityBeforePhysicsUpdate.y < -7f && other.collider.tag == "Floor") {
            gameObject.SetActive(false);
            // if (canMove) {
                // CameraAnimatorHandler.cameraAnimator.SetBool("Destroy", true);
                // Instantiate(Player.i.destroyPrefab, transform.position, transform.rotation);
                // canMove = false;
            // }
        }
        else {
            jumpCounter = 0;
        }
    }
}
