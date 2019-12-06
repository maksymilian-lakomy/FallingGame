using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class DataStorage : MonoBehaviour, ICollectListenable {

    public static DataStorage Instance;

    public int CurrentCupIndex { get; private set; } = 0;
    public List<CupStorage> UnlockedCups { get; private set; } = new List<CupStorage>();
    public int SugarCubeAmount { get; private set; } = 0;

    private void Awake() {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(this);
    }
    
    public void ChangeSugarCubesAmount(int amount) {
        throw new NotImplementedException();
    }
    
    public void OnCollect(int amount) {
        ChangeSugarCubesAmount(amount);
    }
}
