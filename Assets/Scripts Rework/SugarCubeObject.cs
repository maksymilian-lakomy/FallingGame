using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SugarCubeObject : CollectableObject {

    [SerializeField]
    private int changeAmount = 0;
    
    protected override void Collect() {
        throw new System.NotImplementedException();
    }
}
