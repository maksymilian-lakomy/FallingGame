using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuTouchManager : MonoBehaviour {
    private void Update() {
        if (Input.touchCount <= 0)
            return;
        Touch touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Began) {
            // MenuManager.i.StartGameButton();
        }
    }
}
    