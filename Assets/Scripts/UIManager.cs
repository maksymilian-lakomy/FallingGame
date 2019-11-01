using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour {

    [Header("Velocity")] 
    [SerializeField] TextMeshProUGUI velocityText;

    void Update() {
        velocityText.text = Player.i.Rigidbody.velocity.y.ToString();
    }

}
