using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class UIAnimatorHandler : MonoBehaviour, IGameStateListenable {
    private Animator animator;
    
    private void Awake() {
        animator = GetComponent<Animator>();
    }

    private void DisplayUI(GameState gameState) {
        switch (gameState) {
            case GameState.Ended: 
                animator.SetBool("Ended", true);
                break;
            case GameState.Active:
                animator.SetBool("Ended", false);
                break;
        }
    }
    
    public void OnGameStateChange(GameState gameState) {
        DisplayUI(gameState);
    }
}
