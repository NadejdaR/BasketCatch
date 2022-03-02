using System;
using UnityEngine;

public class ScoreUpPickUp : PickUpBase
{
  [Header("ScoreUp Settings")]
  [SerializeField] private int _scoreToAdd;
  [SerializeField] private int _scoreToSubstract;
  
  protected override void ApplyPickUp()
  {
    GameManager.Instance.AddScore(_scoreToAdd);
  }

  protected override void OnCollisionEnter2D(Collision2D col)
  {
    if (col.gameObject.CompareTag(Tags.Basket))
    {
      ApplyPickUp();
      Destroy(gameObject);
    }
    
    if (col.gameObject.CompareTag(Tags.BottomWall))
    {
      GameManager.Instance.RemoveLive();
      Destroy(gameObject);
    }
    
    Destroy(gameObject);
  }
}