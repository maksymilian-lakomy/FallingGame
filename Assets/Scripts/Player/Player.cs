using System;
using System.Collections;
using System.Collections.Generic;
using CustomEventArgs;
using UnityEngine;

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
    
    private void Awake() {
        if (!i) {
            i = this;
            DontDestroyOnLoad(gameObject);
        } else
            Destroy(gameObject);
    }

    private void Start() {
        activeCup = Instantiate(cupPrefab);
        playerController = activeCup.GetComponent<PlayerController>();
        playerController.PlayerOverSpeed += OnPlayerOverSpeed;
        OnCupInstantiated();
    }
    
    private void OnPlayerOverSpeed(object sender, EventArgs args) {
        OnPlayerFailed();
        Debug.Log("Test");
    }

    private void OnCupInstantiated() {
        CupInstantiated?.Invoke(cupPrefab, new CupEventArgs(activeCup));
    }
    
    private void OnPlayerFailed() {
        PlayerFailed?.Invoke(this, EventArgs.Empty);
    } 

}
