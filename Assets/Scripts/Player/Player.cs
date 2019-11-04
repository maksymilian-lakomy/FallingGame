using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    
    public static Player i;
    public PlayerState PlayerState = PlayerState.Alive;
    
    private void Awake() {
        if (!i) {
            i = this;
            DontDestroyOnLoad(gameObject);
        } else
            Destroy(gameObject);
    }

    public void Destroy() {
        
    }

}
