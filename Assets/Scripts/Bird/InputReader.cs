using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private KeyCode _jump = KeyCode.Space;
    private KeyCode _shot = KeyCode.F;

    public event Action Jumped;
    public event Action Shotted;

    private void Update()
    {
        if (Input.GetKeyDown(_jump))
        {
            Jumped.Invoke();
        }

        if (Input.GetKeyDown(_shot))
        {
            Shotted.Invoke();
        }
    }
}