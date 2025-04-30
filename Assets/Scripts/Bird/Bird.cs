using System;
using UnityEngine;

[RequireComponent(typeof(BirdMover))]
[RequireComponent(typeof(CollisionHandler))]
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

    public void Reset()
    {
        _birdMover.Reset();
    }

    public void Die()
    {
        GameOver?.Invoke();
    }

    private void ProcessCollision(IInteractable interactable)
    {
        if(interactable is Platform)
        {
            Die();
        }
    }
}
