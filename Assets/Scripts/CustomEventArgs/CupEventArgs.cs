using UnityEngine;

namespace CustomEventArgs {
    public class CupEventArgs : System.EventArgs {
        public readonly GameObject Cup;

        public CupEventArgs(GameObject cup) {
            Cup = cup;
        }
    }
}
