using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public abstract class CollectableObject : MonoBehaviour {
    
    [SerializeField]
    protected List<ICollectListenable> collectListeners = new List<ICollectListenable>();
    private void OnTriggerEnter(Collider other) {
        Collect();
    }

    protected abstract void Collect();
}
