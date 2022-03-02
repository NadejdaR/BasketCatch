using UnityEngine;

namespace PickUp
{
  public abstract class PickUpBase : MonoBehaviour
  {
    [Header(nameof(PickUpBase))] 
    [SerializeField] private AudioClip _applyAudioClip;
    [SerializeField] private GameObject _applyVisualEffect;

    private void OnCollisionEnter2D(Collision2D col)
    {
      if (col.gameObject.CompareTag(Tags.BottomWall))
        BottomCollision(col);

      if (col.gameObject.CompareTag(Tags.Basket))
      {
        PlayAudioBasket();
        PlayVisualEffectBasket();
        BasketCollision(col);
      }
    }

    protected virtual void BottomCollision(Collision2D col)
    {
      Destroy(gameObject);
    }

    private void BasketCollision(Collision2D col)
    {
      ApplyPickUp();
      Destroy(gameObject);
   }

    protected abstract void ApplyPickUp();
  
    private void PlayVisualEffectBasket()
    {
      // add visual effect
    }

    private void PlayAudioBasket()
    {
      if(_applyAudioClip != null)
        AudioManager.Instance.PlayOnShot(_applyAudioClip);
    }

    protected void OnCollisionEnter2D()
    {
      throw new System.NotImplementedException();
    }
  }
}