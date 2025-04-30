using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private float _shootDelay = 1f;
    private float _timeSinceLastShot;

    public event Action UsingJump;
    public event Action UsingShot;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UsingJump.Invoke();
        }

        _timeSinceLastShot += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.F) && _timeSinceLastShot >= _shootDelay)
        {
            UsingShot.Invoke();
            _timeSinceLastShot = 0f;
        }
    }
}