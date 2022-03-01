using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  [Header("Lives")] 
  [SerializeField] private int _maxLives;
  [SerializeField] private int _startLives;

  private static GameManager _instance;
  public static GameManager Instance => _instance;
  public int MaxLives => _maxLives;
  public event Action OnLivesChanged;
  public event Action OnLevelCleared;
  public int CurrentLives { get; private set; }
  public int Score { get; private set; }

  private void Awake()
  {
    if (_instance != null)
    {
      Destroy(gameObject);
      return;
    }

    _instance = this;
    DontDestroyOnLoad(gameObject);

    CurrentLives = _startLives;
  }

  public void Reload()
  {
    Score = 0;
    CurrentLives = _startLives;
  }

  public void AddScore(int score)
  {
    Score += score;
  }

  public void SubtractScore(int score)
  {
    Score -= score;
  }

  public void RemoveLive()
  {
    CurrentLives--;

    if (CurrentLives <= 0)
      OnLevelCleared?.Invoke();

    OnLivesChanged?.Invoke();
  }

  public void AddLive(int liveToAdd)
  {
    CurrentLives++;

    if (CurrentLives >= _maxLives)
      CurrentLives = _maxLives;

    OnLivesChanged?.Invoke();
  }
}