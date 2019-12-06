using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataStorage : MonoBehaviour, ICollectListenable {

    public int CurrentCupIndex = 0;
    public List<CupStorage> UnlockedCups = new List<CupStorage>();
    public int SugarCubeAmount = 0;

    public void ChangeSugarCubesAmount(int amount) {
        throw new NotImplementedException();
    }
    
    public void OnCollect(int amount) {
        ChangeSugarCubesAmount(amount);
    }
}
