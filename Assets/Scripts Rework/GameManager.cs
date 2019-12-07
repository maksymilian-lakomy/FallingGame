using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour, ISmashListenable {
    [SerializeField]
    private CupController cupController;
    [SerializeField]
    private Transform levelStart;

    private IEnumerable<ICupCreateListenable> cupCreateListeners;

    private void Awake() {
        cupCreateListeners = FindObjectsOfType<MonoBehaviour>().OfType<ICupCreateListenable>();
        InitializeGame();
    }
    
    private void InitializeGame() {
        GameObject cup = Instantiate(DataStorage.Instance.GetCup(), levelStart.position, levelStart.rotation);
        cupController = cup.GetComponent<CupController>();
        foreach (ICupCreateListenable listener in cupCreateListeners) {
            listener.OnCupCreate(cup);
        }
    }
    
    public void RestartGame() {
        throw new NotImplementedException();
    }

    public void OnSmash(GameObject sender) {
        Transform position = sender.transform;
        Destroy(sender);
        Instantiate(DataStorage.Instance.GetSmashedCup(), position.position, position.rotation);
    }
}
