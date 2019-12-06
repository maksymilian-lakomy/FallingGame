using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Comparers;

public class CameraAnimatorHandler : MonoBehaviour, ICupCreateListenable {

    private Rigidbody rigidbodyCup;
    private Animator animator;

    [SerializeField]
    private float transitionDuration = 5f;
    [SerializeField]
    private float velocityScale = 5f;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate() {
        VelocityAnimation();
    }

    private void VelocityAnimation() {
        if (!rigidbodyCup) {
            animator.SetFloat("Zoom", 0f);
            return;
        }
        float velocity = Mathf.Abs(rigidbodyCup.velocity.y / velocityScale);
        float currentVelocity = animator.GetFloat("Zoom");
        animator.SetFloat("Zoom", Mathf.Lerp( currentVelocity, velocity, Time.deltaTime*transitionDuration));
    }
    
    
    public void DestroyAnimationEnded() {
        animator.SetBool("Destroy", false);
    }

    public void JumpAnimationEnded() {
        animator.SetBool("Jump", false);
    }

    public void OnCupCreate(GameObject cup) {
        rigidbodyCup = cup.GetComponent<Rigidbody>();
    }
}
