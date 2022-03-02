using UnityEngine;

namespace PickUp
{
  public class ScoreDownPickUp : PickUpBase
  {
    [Header("ScoreDown Settings")] 
    [SerializeField] private int _scoreToSubtract;

    protected override void ApplyPickUp()
    {
      GameManager.Instance.SubtractScore(_scoreToSubtract);
    }
  }
}