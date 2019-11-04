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
    
    [SerializeField]
    public GameObject destroyPrefab;
    
    private void Awake() {
        rigidbody = GetComponent<Rigidbody>();
        Player.i.PlayerState = PlayerState.Alive;
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
        if (velocityBeforePhysicsUpdate.y > -7f || !other.collider.CompareTag("Floor"))
            return;
        if (Player.i.PlayerState != PlayerState.Destroyed) {
            Instantiate(destroyPrefab, transform.position, transform.rotation);
            Player.i.PlayerState = PlayerState.Destroyed;
        }
        Destroy(gameObject);
    }
}

