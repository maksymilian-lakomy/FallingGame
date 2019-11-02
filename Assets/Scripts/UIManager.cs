using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UIManager : MonoBehaviour {

    [Header("Velocity")] 
    [SerializeField] TextMeshProUGUI velocityText;

    [SerializeField] private Scene menu;
    [SerializeField] private List<Scene> levels = new List<Scene>();
    
    void Update() {
        Scene currentScene = SceneManager.GetActiveScene();
        if (levels.Contains(currentScene)) {
            velocityText.text = Player.i.Rigidbody.velocity.y.ToString();
        } else if (currentScene == menu) {
            
        }
    }

    public void ShopButton() {
        
    }

}
