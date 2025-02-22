﻿using System;
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

    private float jumpCooldown = 0.1f;
    private float timeSinceJumped = 0.0f;

    private AudioSource audioSource;
    
    public delegate void PlayerOverSpeedEventHandler(object sender, EventArgs args);
    public event PlayerOverSpeedEventHandler PlayerOverSpeed;

    [Header("Stats")]
    [SerializeField]
    private float maxCapacity = 100f;
    [SerializeField]
    private float capacity = 100f;
    public float Capacity => capacity;
    
    private void Awake() {
        rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        Vector2? vectorDirection = null;
        timeSinceJumped += Time.deltaTime;
        // Mobile Handling
        if (jumpCounter < 2)
        {
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
            if (timeSinceJumped > jumpCooldown)
            {
                timeSinceJumped = 0;
                Movement(direction);
            }
        }
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
        audioSource.Play();
        rigidbody.AddForce(new Vector3(x, 150, 0));
        jumpCounter += 1;
        return true;
    }
    
    private void OnCollisionEnter(Collision other) {
        if (other.collider.CompareTag("Floor")) 
            jumpCounter = 0;
        
        if (velocityBeforePhysicsUpdate.y > -5f)
            return;

        if (Player.i.PlayerState != PlayerState.NotActive) {
            Player.i.PlayerState = PlayerState.NotActive;
        }

        OnPlayerOverSpeed();
        Camera.main.GetComponent<Animator>().SetBool("Destroy", true);
    }
    
    private void OnPlayerOverSpeed() {
        PlayerOverSpeed?.Invoke(this, EventArgs.Empty);
    } 

    
}

