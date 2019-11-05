using System;
using System.Collections;
using System.Collections.Generic;
using CustomEventArgs;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
    
    public static Player i;
    public PlayerState PlayerState = PlayerState.Active;
    
    public delegate void PlayerFailedEventHandler(object sender, EventArgs args);
    public event PlayerFailedEventHandler PlayerFailed;

    public delegate void CupInstantiatedEventHandler(object sender, CupEventArgs args);

    public event CupInstantiatedEventHandler CupInstantiated;
    
    private PlayerController playerController;
    [SerializeField] private GameObject cupPrefab;
    private GameObject activeCup;
    [SerializeField] private Transform gameStart;
    
    [SerializeField] private Follow steamFollow;
    
    private void Awake() {
        if (!i) {
            i = this;
            // DontDestroyOnLoad(gameObject);
        } else
            Destroy(gameObject);
    }

    private void Start() {
        CreatePlayer();
    }

    private void CreatePlayer() {
        activeCup = Instantiate(cupPrefab, gameStart);
        playerController = activeCup.GetComponent<PlayerController>();
        playerController.PlayerOverSpeed += OnPlayerOverSpeed;
        steamFollow.ObjectToFollow = activeCup.transform;
        OnCupInstantiated();
    }

    public void StartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        CreatePlayer();

    }
    
    private void OnPlayerOverSpeed(object sender, EventArgs args) {
        OnPlayerFailed();
        Debug.Log("Test");
    }

    private void OnCupInstantiated() {
        CupInstantiated?.Invoke(this, new CupEventArgs(activeCup));
    }
    
    private void OnPlayerFailed() {
        PlayerFailed?.Invoke(this, EventArgs.Empty);
    } 

}
