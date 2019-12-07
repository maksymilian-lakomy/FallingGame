using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public static class InputManager {
    public static int GetHorizontalInput() {
        int horizontalInput = GetTouchHorizontalInput();
        if (horizontalInput == 0)
            horizontalInput = GetKeyboardHorizontalInput();
        return horizontalInput;
    }
    
    private static int GetKeyboardHorizontalInput() {
        if (Input.GetKeyDown(KeyCode.RightArrow))
            return 1;
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            return -1;
        return 0;
    }
    
    private static int GetTouchHorizontalInput() {
        if (Input.touchCount <= 0 || Input.GetTouch(0).phase != TouchPhase.Began)
            return 0;
        float screenCenterAxis = Screen.width / 2f;
        Touch touch = Input.GetTouch(0);
        if (touch.position.x >= screenCenterAxis)
            return 1;
        else
            return -1;
    }
}
