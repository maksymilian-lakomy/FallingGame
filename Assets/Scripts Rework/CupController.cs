using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class CupController : MonoBehaviour {
    [SerializeField]
    private int jumpCounter = 0;

    private IEnumerable<ISmashListenable> smashListeners;

    private Rigidbody rigidbody;
    private Vector3 velocityBeforePhysicsUpdate;

    public static float OverspeedThreshold = -5f;

    [SerializeField]
    private Transform safePosition;
    
    private void Awake() {
        rigidbody = GetComponent<Rigidbody>();
        smashListeners = FindObjectsOfType<MonoBehaviour>().OfType<ISmashListenable>();
    }

    private void OnCollisionEnter(Collision other) {
        if (IsOverspeed())
            Smash();
        if (other.collider.CompareTag("Floor"))
            OnFloorCollision(other.gameObject);
    }
    
    private void Update() {
        Movement(); 
    }

    private void FixedUpdate() {
        velocityBeforePhysicsUpdate = rigidbody.velocity;
    }

    private void Movement() {
        if (!CanJump())
            return;
        int horizontalInput = InputManager.GetHorizontalInput();
        if (horizontalInput == 0)
            return;
        horizontalInput *= 150;
        rigidbody.AddForce(horizontalInput, 150f, 0);
        jumpCounter += 1;
    }

    private bool CanJump() {
        if (jumpCounter >= 2)
            return false;
        return true;
    }

    private void ResetJumpCounter() {
        jumpCounter = 0;
    }

    private void OnFloorCollision(GameObject other) {
        ResetJumpCounter();
        SaveSafePosition(other);
    }

    private bool IsOverspeed() {
        if (velocityBeforePhysicsUpdate.y > OverspeedThreshold)
            return false;
        return true;
    }

    private void Smash() {
        foreach (ISmashListenable listener in smashListeners) {
            listener.OnSmash(gameObject);
        }
    }

    private void SaveSafePosition(GameObject other) {
        if (other.layer != LayerMask.NameToLayer("SafeToSave"))
            return;
        if (!safePosition) {
            safePosition = new GameObject().transform;
            safePosition.name = "Safe position save";
        }
        safePosition.position = transform.position;
        safePosition.SetParent(other.transform);
    }

    
    
}
