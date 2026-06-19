using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class GameLogic : MonoBehaviour
{
    private const string _winMessage = "Вы победили.";
    private const string _loseMessage= "Вы проиграли.";

    [SerializeField] private float _maxGameTimer = 180f;
    [SerializeField] private int _maxGameScore;
    [SerializeField] private TMP_Text _gameTimerText;
    [SerializeField] private TMP_Text _gameScoreText;
    [SerializeField] private List<Gem> _gems;
    [SerializeField] private Hero _hero;
    [SerializeField] private GemWallet _gemCollector;

    private int _gameScore;
    private float _gameTimer;

    private void Awake()
    {
        StartGame();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
            StartGame();

        ViewGameScore();

        if (_gameScore == _maxGameScore)
        {
            _hero.StopHero();
            Debug.Log(_winMessage);
            return;
        }

        if (_gameTimer <= 0)
        {
            _gameTimer = 0;
            _hero.StopHero();
            Debug.Log(_loseMessage);
            return;
        }

        GameTimer();
    }

    private void StartGame()
    {
        _hero.StartHero();
        _gemCollector.ResetGemScore();
        foreach (Gem gem in _gems)
            gem.StartGem();

        _gameTimer = _maxGameTimer;
    }

    private void ViewGameScore()
    {
        _gameScore = _gemCollector.GemScore;
        _gameScoreText.text = _gameScore.ToString()+"/"+_maxGameScore.ToString();
    }

    private void GameTimer()
    {
        _gameTimer -= Time.deltaTime;
        _gameTimerText.text = _gameTimer.ToString("0.00");
    }
}
