using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {
    [SerializeField] public Transform ObjectToFollow;

    private void LateUpdate() {
        if (ObjectToFollow)
            transform.position = ObjectToFollow.position;
    }
}
