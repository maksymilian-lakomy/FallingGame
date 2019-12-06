using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class DataStorage : MonoBehaviour, ICollectListenable {

    public static DataStorage Instance;

    [SerializeField]
    private int currentCupIndex = 0;
    [SerializeField]
    private List<CupStorage> unlockedCups = new List<CupStorage>();
    public int SugarCubeAmount { get; private set; } = 0;

    private void Awake() {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
        DontDestroyOnLoad(this);
    }
    
    public void ChangeSugarCubesAmount(int amount) {
        throw new NotImplementedException();
    }
    
    public void OnCollect(int amount) {
        ChangeSugarCubesAmount(amount);
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
