using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using UnityEngine;

public class DataStorage : MonoBehaviour, ICollectListenable {

    public static DataStorage Instance;

    [SerializeField]
    private int currentCupIndex = 0;
    [SerializeField]
    private List<CupStorage> unlockedCups = new List<CupStorage>(); 
    
    public Dictionary<CollectableData, int> CollectableStorage = new Dictionary<CollectableData, int>();

    public static List<IInventoryChange> InventoryChangeListeners = new List<IInventoryChange>();
    

    private void Awake() {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
        DontDestroyOnLoad(this);
    }
    
    public void OnCollect(CollectableData collectableData, int amount) {
        if (!CollectableStorage.ContainsKey(collectableData))
            CollectableStorage.Add(collectableData, amount);
        else
            CollectableStorage[collectableData] += amount;
        foreach (IInventoryChange listener in InventoryChangeListeners) {
            listener.OnChange(collectableData, CollectableStorage[collectableData]);
        }
    }
    
    public GameObject GetCup() {
        foreach (CupStorage cupStorage in unlockedCups) {
            if (cupStorage.Key == currentCupIndex)
                return cupStorage.Prefab;
        }
        return null;
    }

    public GameObject GetSmashedCup() {
        foreach (CupStorage cupStorage in unlockedCups) {
            if (cupStorage.Key == currentCupIndex)
                return cupStorage.SmashedPrefab;
        }
        return null;
    }
}
