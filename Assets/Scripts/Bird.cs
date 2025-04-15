using System;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private CollisionHandler _birdCollisionHandler;
    private WeaponPlayer _weaponPlayer;
    private ScoreCounter _scoreCounter;
    private BirdMover _birdMover;

    public event Action GameOver;

    private void Awake()
    {
        _birdMover = GetComponent<BirdMover>();
        _scoreCounter = GetComponent<ScoreCounter>();
        _weaponPlayer = GetComponent<WeaponPlayer>();
        _birdCollisionHandler = GetComponent<CollisionHandler>();
    }

    private void OnEnable()
    {
        _weaponPlayer.Hit += ScoreChange;
        _birdCollisionHandler.CollisionDetected += ProcessCollision;
    }

    private void OnDisable()
    {
        _weaponPlayer.Hit -= ScoreChange;
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

    public void ScoreChange()
    {
        _scoreCounter.Add();
    }

    public void Reset()
    {
        _birdMover.Reset();
        _scoreCounter.Reset();
    }
}
