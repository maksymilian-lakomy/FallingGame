using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class CupController : MonoBehaviour {
    private int jumpCounter = 0;
    [SerializeField]
    private List<ISmashListenable> smashListeners = new List<ISmashListenable>();

    private void Awake() {
        throw new NotImplementedException();
    }

    private void OnCollisionEnter(Collision other) {
        throw new NotImplementedException();
    }

    private void FixedUpdate() {
        
    }

    private void Movement() {
        throw new NotImplementedException();
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
