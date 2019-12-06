using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class CupController : MonoBehaviour {
    [SerializeField]
    private int jumpCounter = 0;
    [SerializeField]
    private List<ISmashListenable> smashListeners = new List<ISmashListenable>();

    private Rigidbody rigidbody;
    private Vector3 velocityBeforePhysicsUpdate;
    
    private void Awake() {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision other) {
        // throw new NotImplementedException();
    }

    private void FixedUpdate() {
        Movement();
        velocityBeforePhysicsUpdate = rigidbody.velocity;
    }

    private void Movement() {
        if (jumpCounter >= 2)
            return;
        int horizontalInput = InputManager.GetHorizontalInput();
        if (horizontalInput == 0)
            return;
        horizontalInput *= 150;
        rigidbody.AddForce(horizontalInput, 150f, 0);
        jumpCounter += 1;
    }

    private bool CanJump() {
        throw new NotImplementedException();
    }

    private void ResetJumpCounter() {
        throw new NotImplementedException();
    }

    private void OnFloorCollision() {
        throw new NotImplementedException();
    }

    private bool IsOverspeed() {
        throw new NotImplementedException();
    }

    private void Smash() {
        throw new NotImplementedException();
    }
    
    
}
