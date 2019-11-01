using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimatorHandler : MonoBehaviour {
    
    public static Animator cameraAnimator;

    private void Awake() {
        cameraAnimator = GetComponent<Animator>();
    }
    
    public void DestroyAnimationEnded() {
        cameraAnimator.SetBool("Destroy", false);
    }
}
