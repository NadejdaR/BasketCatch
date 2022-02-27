using UnityEngine;

public abstract class PickUpBase : MonoBehaviour
{
    [Header(nameof(PickUpBase))] 
    [SerializeField] private AudioClip _applyAudioClip;
    [SerializeField] private GameObject _applyVisualEffect;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag(Tags.Basket))
        {
            PlayAudio();
            PlayVisualEffect();
            ApplyPickUp();
      
            Destroy(gameObject);
        }
    }

    protected abstract void ApplyPickUp();
  
    private void PlayVisualEffect()
    {
     // add visual effect
    }

    private void PlayAudio()
    {
        if(_applyAudioClip != null)
            AudioManager.Instance.PlayOnShot(_applyAudioClip);
    }
}
