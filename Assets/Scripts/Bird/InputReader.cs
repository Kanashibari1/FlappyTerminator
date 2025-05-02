using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private KeyCode _keySpace = KeyCode.Space;
    private KeyCode _keyF = KeyCode.F;

    public event Action UseJumped;
    public event Action UseShotted;

    private void Update()
    {
        if (Input.GetKeyDown(_keySpace))
        {
            UseJumped.Invoke();
        }

        if (Input.GetKeyDown(_keyF))
        {
            UseShotted.Invoke();
        }
    }
}