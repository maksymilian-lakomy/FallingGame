using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameStateListenable {
    void OnGameStateChange(GameState gameState);
}