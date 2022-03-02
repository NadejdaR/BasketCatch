using UnityEngine;

namespace PickUp
{
  public class AddLifePickUp : PickUpBase
  {
    [Header("ScoreDown Settings")]
    [SerializeField] private int _liveToAdd;
  
    protected override void ApplyPickUp()
    {
      GameManager.Instance.AddLive(_liveToAdd);
      Destroy(gameObject);
    }
  }
}