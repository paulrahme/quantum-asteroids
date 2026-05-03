using Photon.Deterministic;
using UnityEngine;

namespace Quantum.Asteroids
{
    public class AsteroidsInput : MonoBehaviour
    {
        private void OnEnable()
        {
            QuantumCallback.Subscribe(this, (CallbackPollInput callback) => PollInput(callback));
        }

        private void PollInput(CallbackPollInput callback)
        {
            var i = new Input();

            i.Left = UnityEngine.Input.GetKey(KeyCode.A) || UnityEngine.Input.GetKey(KeyCode.LeftArrow);
            i.Right = UnityEngine.Input.GetKey(KeyCode.D) || UnityEngine.Input.GetKey(KeyCode.RightArrow);
            i.Up = UnityEngine.Input.GetKey(KeyCode.W) || UnityEngine.Input.GetKey(KeyCode.UpArrow);
            i.Fire = UnityEngine.Input.GetKey(KeyCode.Space); 

            callback.SetInput(i, DeterministicInputFlags.Repeatable);
        }
    }
}