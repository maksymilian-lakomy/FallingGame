using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour, ICupCreateListenable, ISmashListenable {
    private Transform objectToFollow;
    private Rigidbody objectToFollowRigidbody;

    private Vector3 offset;
    private float transitionDuration;
    private float fovScaleDuration;

    private Camera camera;
    private Animator camerAnimator;

    private void Awake() {
        throw new NotImplementedException();
    }

    private void FixedUpdate() {
        throw new NotImplementedException();
    }
    
    private void Follow() {
        throw new NotImplementedException();
    }

    public void OnCupCreate(GameObject cup) {
        throw new System.NotImplementedException();
    }

    public void OnSmash(GameObject sender) {
        throw new System.NotImplementedException();
    }
}
