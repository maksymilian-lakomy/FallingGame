using System;
using System.Collections;
using System.Collections.Generic;
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

    [SerializeField] private Color panelColor = new Color(0.8901961f, 0.7294118f, 0.4f, 1f);
    [SerializeField] private Color dangerColor = Color.red;
    
    void Update() {
        if (Player.i.PlayerState == PlayerState.Alive)
            velocityBar.fillAmount = Mathf.Lerp(velocityBar.fillAmount, Mathf.Abs(playerRB.velocity.y / 10f), Time.deltaTime*10f);
            if (playerRB.velocity.y <= -6f)
                velocityBar.color = Color.Lerp(velocityBar.color, dangerColor, Time.deltaTime * 2f);
            else
                velocityBar.color = Color.Lerp(velocityBar.color, panelColor, Time.deltaTime * 2f);


    }

    public void ShopButton() {
        
    }

}
