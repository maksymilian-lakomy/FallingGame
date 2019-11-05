using System;
using System.Collections;
using System.Collections.Generic;
using CustomEventArgs;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraFollow : MonoBehaviour {
    [CanBeNull] private Transform objectToFollow;
    private Rigidbody objectToFollowRigidbody;

    [SerializeField] private Vector3 cameraOffset;
    [SerializeField] [Range(1, 20)] double cameraFollowTime;
    [SerializeField] [Range(1, 10)] double cameraFovScaleTime;

    [SerializeField]
    private Camera camera;

    private Animator cameraAnimator;

    private void Awake() {
        cameraAnimator = camera.GetComponent<Animator>();
        Player.i.CupInstantiated += OnCupInstantiated;
    }

    private void OnCupInstantiated(object sender, CupEventArgs e) {
        objectToFollow = e.Cup.transform;
        objectToFollowRigidbody = e.Cup.GetComponent<Rigidbody>();
    }
    
    void LateUpdate() {
        if (Player.i.PlayerState == PlayerState.Active && objectToFollow != null) {
            Vector3 destinationPosition = Vector3.Lerp(transform.position, objectToFollow.position + cameraOffset,
                                                        Time.deltaTime * (float) cameraFollowTime);
            transform.position = destinationPosition;
            Double speed = Mathf.Abs(objectToFollowRigidbody.velocity.y / 10f);
            Double currentSpeed = cameraAnimator.GetFloat("Zoom");
            cameraAnimator.SetFloat("Zoom", Mathf.Lerp((float)currentSpeed, (float)speed, Time.deltaTime*(float)cameraFovScaleTime));
            transform.LookAt(objectToFollow);
        }
        else {
            cameraAnimator.SetFloat("Zoom", 0f);
        }
    }
}
