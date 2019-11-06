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
    [SerializeField] private GameObject cupDestroyedPrefab;
    private GameObject cupActive;
    private GameObject cupDestroyed;
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
        cupActive = Instantiate(cupPrefab, gameStart);
        playerController = cupActive.GetComponent<PlayerController>();
        playerController.PlayerOverSpeed += OnPlayerOverSpeed;
        steamFollow.ObjectToFollow = cupActive.transform;
        cupDestroyed = Instantiate(cupDestroyedPrefab);
        cupDestroyed.SetActive(false);
        OnCupInstantiated();
    }

    public void StartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        CreatePlayer();
    }
    
    private void OnPlayerOverSpeed(object sender, EventArgs args) {
        OnPlayerFailed();
    }

    private void OnCupInstantiated() {
        CupInstantiated?.Invoke(this, new CupEventArgs(cupActive));
    }
    
    private void OnPlayerFailed() {
        cupDestroyed.transform.position = cupActive.transform.position;
        cupDestroyed.transform.rotation = cupActive.transform.rotation;
        cupActive.SetActive(false);
        cupDestroyed.SetActive(true);
        PlayerFailed?.Invoke(this, EventArgs.Empty);
    } 

}
