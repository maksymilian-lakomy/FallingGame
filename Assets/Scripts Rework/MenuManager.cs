using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {

    public MenuState MenuState { get; private set; } = MenuState.Main;

    private void SetMenuState(MenuState menuState) {
        MenuState = menuState;
    }
    
    public void ShopButton() {
        Debug.Log("Test Shop");
    }

    public void StartGameButton() {
        Debug.Log("Fantastycznie");
    }
}
