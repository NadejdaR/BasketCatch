using UnityEngine;

public class ScoreUpPickUp : PickUpBase
{
  [SerializeField] private int _scoreToAdd;
  
  protected override void ApplyPickUp()
  {
    GameManager.Instance.AddScore(_scoreToAdd);
  }
}