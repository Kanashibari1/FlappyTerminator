using System;
using UnityEngine;

public class ShotHandler : MonoBehaviour
{
    private float _shootDelay = 1f;
    private float _timeSinceLastShot;

    public event Action Shoot;

    void Update()
    {
        _timeSinceLastShot += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.F) && _timeSinceLastShot >= _shootDelay)
        {
            Shoot.Invoke();

            _timeSinceLastShot = 0f;
        }
    }
}