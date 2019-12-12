using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu (fileName = "new Collectable Data", menuName = "CollectableData/new Collectable Data", order = 0)]
public class CollectableData : ScriptableObject {
    public string Name;
}
