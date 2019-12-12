using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInventoryChange {
    void OnChange(CollectableData collectableData, int newAmount);
}