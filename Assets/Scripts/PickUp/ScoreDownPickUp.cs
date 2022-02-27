using UnityEngine;

public class ScoreDownPickUp : PickUpBase
{
  [SerializeField] private int _scoreToSubtract;

  protected override void ApplyPickUp()
  {
    GameManager.Instance.SubtractScore(_scoreToSubtract);
  }
}