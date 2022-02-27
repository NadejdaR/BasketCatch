using UnityEngine;

public class ScoreUpPickUp : PickUpBase
{
  [Header("ScoreUp Settings")]
  [SerializeField] private int _scoreToAdd;
  
  protected override void ApplyPickUp()
  {
    GameManager.Instance.AddScore(_scoreToAdd);
  }
}