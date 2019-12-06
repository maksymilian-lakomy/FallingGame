using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour, ICupCreateListenable {
    private Transform cup;

    [SerializeField]
    private Vector3 offset;
    [SerializeField]
    private float transitionDuration;

    private void FixedUpdate() {
        Follow();
    }
    
    private void Follow() {
        if (!cup)
            return;
        Vector3 destinationPosition = Vector3.Lerp(transform.position, cup.position + offset,
                                                   Time.deltaTime * transitionDuration);
        transform.position = destinationPosition;
    }

    public void OnCupCreate(GameObject cup) {
        this.cup = cup.transform;
    }

}
