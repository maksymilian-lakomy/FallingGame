﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollectListenable {
    void OnCollect(CollectableData collectableData, int amount);
}
