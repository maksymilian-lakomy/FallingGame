using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class UIController : MonoBehaviour, IGameStateListenable, ICupCreateListenable {
    
    private GameState gameState;

    private Rigidbody cupRigidbody;

    [SerializeField]
    private Image speedBarFill;

    [SerializeField] private float speedBarFillmentSpeed = 2f;
    [SerializeField] private Color speedBarFillmentNormalColor;
    [SerializeField] private Color speedBarFillmentDangerColor;

    private void Update() {
        InputObserver();
        VelocityBar();
    }

    private void VelocityBar() {
        if (!cupRigidbody) return;
        var newAmount = Mathf.Abs(cupRigidbody.velocity.y / 7);
        speedBarFill.fillAmount = Mathf.Lerp(speedBarFill.fillAmount, newAmount, Time.deltaTime*speedBarFillmentSpeed);
        if (cupRigidbody.velocity.y < CupController.OverspeedThreshold) {
            speedBarFill.color = Color.Lerp(speedBarFill.color, speedBarFillmentDangerColor, Time.deltaTime * 5f);
        } else {
            speedBarFill.color = Color.Lerp(speedBarFill.color, speedBarFillmentNormalColor, Time.deltaTime * 5f);
        }
    }
    
    private void InputObserver() {
        switch (gameState) {
            case GameState.Ended:
                if (Input.GetKeyDown(KeyCode.Space) || Input.touchCount > 0)
                    GameManager.Instance.RestartGame();
                break;
        }
    }
    
    public void OnCupCreate(GameObject cup) {
        var cupRigidbody = cup.GetComponent<Rigidbody>();
        if (cupRigidbody)
            this.cupRigidbody = cupRigidbody;
    }
    
    public void OnGameStateChange(GameState gameState) {
        this.gameState = gameState;
    }
}
