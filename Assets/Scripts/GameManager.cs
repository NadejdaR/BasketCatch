using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  [Header("Lives")] 
  [SerializeField] private int _maxLives = 5;
  [SerializeField] private int _startLives = 3;

  private static GameManager _instance;

  public static GameManager Instance => _instance;
  public int MaxLives => _maxLives;
  public event Action OnLivesChanged;

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
    if (CurrentLives <= 0)
      return;

    CurrentLives--;
    
    OnLivesChanged?.Invoke();
  }

  public void AddLive(int liveToAdd)
  {
    if (CurrentLives >= _maxLives)
      return;

    CurrentLives++;
    
    OnLivesChanged?.Invoke();
  }
}