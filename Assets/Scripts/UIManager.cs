using System;
using System.Collections;
using System.Collections.Generic;
using CustomEventArgs;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UIManager : MonoBehaviour {

    [Header("Velocity")] 
    [SerializeField] Image velocityBar;

    [SerializeField] private Scene menu;
    [SerializeField] private List<Scene> levels = new List<Scene>();

    [SerializeField] private Rigidbody playerRB;


    [SerializeField] private Animator levelsCanvasAnimator;
    [SerializeField] private Color panelColor = new Color(0.8901961f, 0.7294118f, 0.4f, 1f);
    [SerializeField] private Color dangerColor = Color.red;

    private void Awake() {
        Player.i.PlayerFailed += PlayerFailed;
        Player.i.CupInstantiated += OnCupInstantiated;
    }
    
    private void Update() {
        if (Player.i.PlayerState == PlayerState.Active && playerRB) {
            velocityBar.fillAmount = Mathf.Lerp(velocityBar.fillAmount, Mathf.Abs(playerRB.velocity.y / 10f),
                                                Time.deltaTime * 10f);
            if (playerRB.velocity.y <= -4f)
                velocityBar.color = Color.Lerp(velocityBar.color, dangerColor, Time.deltaTime * 2f);
            else
                velocityBar.color = Color.Lerp(velocityBar.color, panelColor, Time.deltaTime * 2f);
        } else if (Player.i.PlayerState == PlayerState.NotActive) {
            if (Input.GetKeyDown(KeyCode.Space) || TouchManager.IsTouch()) {
                Player.i.StartGame();
            }
        }
    }

    private void PlayerFailed(object sender, EventArgs args) {
        Debug.Log("tst");
        levelsCanvasAnimator.SetBool("Not Active", true);
        levelsCanvasAnimator.SetBool("Active", false);
        levelsCanvasAnimator.SetBool("Static", false);
    }

    private void OnCupInstantiated(object sender, CupEventArgs args) {
        
        Debug.Log("Test");
        levelsCanvasAnimator.SetBool("Active", true);
        playerRB = args.RigidbodyCup;
    }

}
