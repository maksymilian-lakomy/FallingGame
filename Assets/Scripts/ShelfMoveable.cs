using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfMoveable : MonoBehaviour {
    
    private Vector3 startPosition;
    [SerializeField] private Transform endPosition;
    private bool toEndPosition = true;
    [SerializeField] [Range(1f, 6f)] float moveSpeed = 1f;

    private void Awake() {
        startPosition = transform.position;
    }

    private void Update() {
        if (toEndPosition == true) {
            transform.position =
                Vector3.MoveTowards(transform.position, new Vector3(endPosition.position.x, transform.position.y, transform.position.z), Time.deltaTime * moveSpeed);
            if (Mathf.Round(transform.position.x) == Mathf.Round(endPosition.position.x))
                toEndPosition = false;
        } else {
            transform.position =
                Vector3.MoveTowards(transform.position, new Vector3(startPosition.x, transform.position.y, transform.position.z), Time.deltaTime * moveSpeed);
            if (Mathf.Round(transform.position.x) == Mathf.Round(startPosition.x))
                toEndPosition = true;
        }
    }
}
