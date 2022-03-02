using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
  [SerializeField] private GameObject[] _pickUpPrefabs;

  [Header("Spawn")] 
  [SerializeField] private float _spawnRangeX = 2.8f;
  [SerializeField] private float _spawnRate = 1.5f;
  [SerializeField] private float _delay = 2f;
  [SerializeField] private float _delayDecrease = 5f;
  [SerializeField] private float _spawnRateDecrease = 0.2f;
  [SerializeField] private float _minSpawnRate = 0.1f;

  private int _countArray;

  private IEnumerator _spawnPickUpEnumerator;
  private IEnumerator _decreaseSpawnRateEnumerator;

  private void Start()
  {
    GameManager.Instance.OnLevelCleared += CancelSpawnInvoke;
    _countArray = _pickUpPrefabs.Length;
  }

  private void Update()
  {
    if (Input.GetMouseButtonDown(0))
    {
      SpawnInvoke();
    }
  }

  private void SpawnInvoke()
  {
    _spawnPickUpEnumerator = CreatePickUpCoroutine();
    StartCoroutine(_spawnPickUpEnumerator);

    _decreaseSpawnRateEnumerator = DecreaseSpawnRate();
    StartCoroutine(_decreaseSpawnRateEnumerator);
  }

  private void CancelSpawnInvoke()
  {
    if (_spawnPickUpEnumerator != null)
    {
      StopCoroutine(_decreaseSpawnRateEnumerator);
      StopCoroutine(_spawnPickUpEnumerator);
    }
  }

  private IEnumerator CreatePickUpCoroutine()
  {
    yield return new WaitForSeconds(_delay);

    while (true)
    {
      SpawnPickUp();

      yield return new WaitForSeconds(_spawnRate);
    }
  }

  private IEnumerator DecreaseSpawnRate()
  {
    yield return new WaitForSeconds(_delayDecrease);
    WaitForSeconds second = new WaitForSeconds(1f);
    
    while (true)
    {
      _spawnRate -= _spawnRateDecrease;
      _spawnRate = Mathf.Max(_spawnRate, _minSpawnRate);
      yield return second;
    }
  }

  private void SpawnPickUp()
  {
    int randomIndex = Random.Range(0, _countArray);
    Vector3 spawnPos = new Vector3(Random.Range(-_spawnRangeX, _spawnRangeX), 5, 0);
    GameObject pickUpPrefab = _pickUpPrefabs[randomIndex];
    Instantiate(pickUpPrefab, spawnPos, pickUpPrefab.transform.rotation);
  }
}