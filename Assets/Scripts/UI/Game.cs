using UnityEngine;

[RequireComponent(typeof(ScoreCounter))]
public class Game : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private SpawnerEnemy _spawnerEnemy;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private EndScreen _endScreen;
    [SerializeField] private WeaponPlayer _weaponPlayer;

    private ScoreCounter _scoreCounter;

    private void Awake()
    {
        _scoreCounter = GetComponent<ScoreCounter>();
    }

    private void OnEnable()
    {
        _weaponPlayer.Hit += Add;
        _startScreen.PlayButtonClicked += OnPlayButtonClick;
        _endScreen.RestartButtonClicked += OnRestartButtonClick;
        _bird.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _weaponPlayer.Hit -= Add;
        _startScreen.PlayButtonClicked -= OnPlayButtonClick;
        _endScreen.RestartButtonClicked -= OnRestartButtonClick;
        _bird.GameOver -= OnGameOver;
    }

    private void Start()
    {
        Time.timeScale = 0f;
        _startScreen.Open();
        _endScreen.Close();
    }

    private void OnGameOver()
    {
        Time.timeScale = 0f;
        _endScreen.Open();
    }

    private void OnRestartButtonClick()
    {
        _endScreen.Close();
        StartGame();
    }

    private void OnPlayButtonClick()
    {
        _startScreen.Close();
        StartGame();
    }

    private void StartGame()
    {
        Time.timeScale = 1.0f;
        _bird.Reset();
        _spawnerEnemy.Reset();
        _scoreCounter.Reset();
        _weaponPlayer.Reset();
    }

    private void Add()
    {
        _scoreCounter.Add();
    }
}
