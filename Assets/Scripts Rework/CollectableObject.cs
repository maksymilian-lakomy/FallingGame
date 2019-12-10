using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public abstract class CollectableObject : MonoBehaviour {

    [SerializeField] protected IEnumerable<ICollectListenable> collectListeners;

    [SerializeField] protected CollectableType collectableType;
    [SerializeField] protected int amount;

    private void Awake() {
        collectListeners = FindObjectsOfType<MonoBehaviour>().OfType<ICollectListenable>();
    }
    
    private void OnTriggerEnter(Collider other) {
        OnCollect();
        Collect();
    }

    private void OnCollect() {
        foreach (ICollectListenable listener in collectListeners) {
            listener.OnCollect(collectableType, amount);
        }
    }
    
    protected abstract void Collect();
}
