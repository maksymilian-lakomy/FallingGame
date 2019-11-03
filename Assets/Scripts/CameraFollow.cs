using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraFollow : MonoBehaviour {
    [SerializeField]
    private Transform objectToFollow;

    private Rigidbody objectToFollowRigidbody;

    [SerializeField] private Vector3 cameraOffset;
    [SerializeField] [Range(1, 20)] double cameraFollowTime;
    [SerializeField] [Range(1, 10)] double cameraFovScaleTime;

    [SerializeField]
    private Camera camera;

    private Animator cameraAnimator;

    private void Awake() {
        cameraAnimator = camera.GetComponent<Animator>();
        objectToFollowRigidbody = objectToFollow.GetComponent<Rigidbody>();
    }

    void Update() {
        if (Player.i.isActiveAndEnabled) {
            transform.position =
                Vector3.Lerp(transform.position, objectToFollow.position + cameraOffset,
                             Time.deltaTime * (float) cameraFollowTime);
            Double speed = Mathf.Abs(objectToFollowRigidbody.velocity.y / 10f);
            Double currentSpeed = cameraAnimator.GetFloat("Zoom");
            cameraAnimator.SetFloat("Zoom", Mathf.Lerp((float)currentSpeed, (float)speed, Time.deltaTime*(float)cameraFovScaleTime));
        }
        else {
            cameraAnimator.SetFloat("Zoom", 0f);
        }
    }
}
