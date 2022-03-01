using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
  [SerializeField] private GameObject[] _pickUpPrefabs;
  
  [Header("Spawn")]
  [SerializeField] private float _spawnRangeX = 2.8f;
  [SerializeField] private float _delay = 2f;
  [SerializeField] private float _spawnRate = 1.5f;
  [SerializeField] private float _spawnRateDecrease = 0.5f;
  [SerializeField] private float _minSpawnRate = 0.1f;

  private IEnumerator _spawnPickUp;
  private IEnumerator _decreaseSpawnRate;

  private int _countArray;

  public void Begin()
  {
    _spawnPickUp = SpawnPickUp();
    StartCoroutine(_spawnPickUp);

    _decreaseSpawnRate = DecreaseSpawnRate();
    StartCoroutine(_decreaseSpawnRate);
  }

  public void Stop()
  {
    StopCoroutine(_spawnPickUp);
    StopCoroutine(_decreaseSpawnRate);
  }

  private void Update()
  {
    if (Input.GetMouseButtonDown(0))
    {
      _countArray = _pickUpPrefabs.Length;
      InvokeRepeating(nameof(SpawnPickUp), _delay, _spawnRate);
    }
  }

  private IEnumerator SpawnPickUp()
  {
    while (true)
    {
      int randomIndex = Random.Range(0, _countArray);
      Vector3 spawnPos = new Vector3(Random.Range(-_spawnRangeX, _spawnRangeX), 5, 0);
      GameObject pickUpPrefab = _pickUpPrefabs[randomIndex];
      Instantiate(pickUpPrefab, spawnPos, pickUpPrefab.transform.rotation);
    }
  }

  private IEnumerator DecreaseSpawnRate()
  {
    yield return new WaitForSeconds(_delay);
    WaitForSeconds seconds = new WaitForSeconds(1f);
    
    while (true)
    {
      _spawnRate -= _spawnRateDecrease;
      _spawnRate = Mathf.Max(_spawnRate, _minSpawnRate);
      yield return seconds;
    }
  }
}