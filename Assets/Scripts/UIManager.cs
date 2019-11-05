using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UIManager : MonoBehaviour {

    [Header("Velocity")] 
    [SerializeField] Image velocityBar;

    [SerializeField] private Scene menu;
    [SerializeField] private List<Scene> levels = new List<Scene>();

    [SerializeField] private Rigidbody playerRB;
    
    void Update() {
        if (!playerRB)
            return;
        velocityBar.fillAmount = Mathf.Lerp(velocityBar.fillAmount, Mathf.Abs(playerRB.velocity.y / 10f), Time.deltaTime*10f);
        if (playerRB.velocity.y <= -7f)
            velocityBar.color = Color.red;
        else
            velocityBar.color = new Color(0.8901961f, 0.7294118f, 0.4f, 1f);


    }

    public void ShopButton() {
        
    }

}
