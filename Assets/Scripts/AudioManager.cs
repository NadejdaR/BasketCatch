using UnityEngine;

public class AudioManager : MonoBehaviour
{
  [SerializeField] private AudioSource _audioSource;

  private static AudioManager _instance;

  public static AudioManager Instance => _instance;

  private void Awake()
  {
    if (_instance != null)
    {
      Destroy(gameObject);
      return;
    }

    _instance = this;
    DontDestroyOnLoad(gameObject);
  }

  public void PlayOnShot(AudioClip clip)
  {
    _audioSource.PlayOneShot(clip);
  }

  public void PlayBackground(AudioClip clip)
  {
    _audioSource.clip = clip;
    _audioSource.Play();
  }
}