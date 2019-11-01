using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    [SerializeField]
    private Transform objectToFollow;

    [SerializeField] private Vector3 cameraOffset;
    [SerializeField] [Range(1, 20)] double time;
    void Update() {
        transform.position =
            Vector3.Lerp(transform.position, objectToFollow.position + cameraOffset, Time.deltaTime * (float)time);
    }
}
