using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour {
    public static Player i;
    
    public Rigidbody Rigidbody { get; private set; }

    public GameObject destroyPrefab;
    
    void Awake() {
        Rigidbody = transform.GetComponent<Rigidbody>();
        if (!i) {
            i = this;
            DontDestroyOnLoad(gameObject);
        } else
            Destroy(gameObject);
    }

}
