using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class UIController : MonoBehaviour, IGameStateListenable {
    
    private GameState gameState;

    private void Update() {
        InputObserver();
    }

    private void InputObserver() {
        switch (gameState) {
            case GameState.Ended:
                if (Input.GetKeyDown(KeyCode.Space) || Input.touchCount > 0)
                    GameManager.Instance.RestartGame();
                break;
        }
    }
    
    public void OnGameStateChange(GameState gameState) {
        this.gameState = gameState;
    }
}
