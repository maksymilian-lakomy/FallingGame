using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class ShelfTrap : MonoBehaviour {
    private Animator animator;

    [SerializeField] [Range (0.1f, 3f)] private float timerSpeed = 1f;
    
    private void Awake() {
        animator = GetComponent<Animator>();
    }
    
    private void OnTriggerEnter(Collider other) {
        if (!other.gameObject.CompareTag("Player"))
            return;
        animator.SetBool("Timer Started", true);
        animator.speed = 2;
    }

    public void OnTimerEnded() {
        animator.speed = 1;
        animator.SetBool("Timer Ended", true);
    }
}
