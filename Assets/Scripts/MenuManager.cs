using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {

    [SerializeField] private GameObject dresser;
    [SerializeField] private GameObject camera;
    private Animator dresserAnimator;
    private Animator cameraAnimator;

    public static MenuManager i;

    private void Awake() {
        dresserAnimator = dresser.GetComponent<Animator>();
        cameraAnimator = camera.GetComponent<Animator>();
        if (!i) {
            i = this;
        } else 
            Destroy(gameObject);

    }
    
    public void ShopButton() {
        dresserAnimator.SetBool("Drawer1", true);
        cameraAnimator.SetBool("Drawer1", true);
    }
    
    public void StartGameButton() {
        dresserAnimator.SetBool("Start", true);
        cameraAnimator.SetBool("Start", true);
    }
}
