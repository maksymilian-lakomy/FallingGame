using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SugarCubeObject : CollectableObject {
    
    protected override void Collect() {
        Destroy(gameObject);
    }
}
