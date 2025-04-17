using System;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private CollisionHandler _birdCollisionHandler;
    private BirdMover _birdMover;

    public event Action GameOver;

    private void Awake()
    {
        _birdMover = GetComponent<BirdMover>();
        _birdCollisionHandler = GetComponent<CollisionHandler>();
    }

    private void OnEnable()
    {
        _birdCollisionHandler.CollisionDetected += ProcessCollision;
    }

    private void OnDisable()
    {
        _birdCollisionHandler.CollisionDetected -= ProcessCollision;
    }

    private void ProcessCollision(IInteractable interactable)
    {
        if(interactable is Platform)
        {
            Die();
        }
    }

    public void Die()
    {
        GameOver?.Invoke();
    }

    public void Reset()
    {
        _birdMover.Reset();
    }
}
