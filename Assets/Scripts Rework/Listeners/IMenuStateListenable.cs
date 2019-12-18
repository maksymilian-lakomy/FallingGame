using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public interface IMenuStateListenable {
    void OnMenuStateChange(MenuState menuState);
}
