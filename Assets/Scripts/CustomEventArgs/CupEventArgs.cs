using UnityEngine;

namespace CustomEventArgs {
    public class CupEventArgs : System.EventArgs {
        public readonly GameObject Cup;
        public readonly Rigidbody RigidbodyCup;

        public CupEventArgs(GameObject cup) {
            Cup = cup;
            RigidbodyCup = cup.GetComponent<Rigidbody>();
        }
    }
}
