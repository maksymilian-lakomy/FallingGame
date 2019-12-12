using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour, ISmashListenable {

    public static GameManager Instance;
    
    [SerializeField]
    private CupController cupController;
    [SerializeField]
    private Transform levelStart;

    private GameState gameState;
    
    
    public GameState GameState {
        get => gameState;
        private set {
            foreach (IGameStateListenable listener in gameStateListeners) {
                listener.OnGameStateChange(value);
            }
            gameState = value;
        }
    }

    private IEnumerable<ICupCreateListenable> cupCreateListeners;
    private IEnumerable<IGameStateListenable> gameStateListeners;
    

    private void Awake() {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
        cupCreateListeners = FindObjectsOfType<MonoBehaviour>().OfType<ICupCreateListenable>();
        gameStateListeners = FindObjectsOfType<MonoBehaviour>().OfType<IGameStateListenable>();
        InitializeGame();
    }
    
    private void InitializeGame() {
        GameObject cup = Instantiate(DataStorage.Instance.GetCup(), levelStart.position, levelStart.rotation);
        cupController = cup.GetComponent<CupController>();
        GameState = GameState.Active;
        foreach (ICupCreateListenable listener in cupCreateListeners) {
            listener.OnCupCreate(cup);
        }
    }
    
    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnSmash(GameObject sender) {
        Transform position = sender.transform;
        Destroy(sender);
        Instantiate(DataStorage.Instance.GetSmashedCup(), position.position, position.rotation);
        GameState = GameState.Ended;
    }
}
