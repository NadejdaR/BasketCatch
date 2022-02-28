using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
  [SerializeField] private GameObject[] _pickUpPrefabs;

  private int _countArray;
  private int _randomIndex;

  private void Start()
  {
    _countArray = _pickUpPrefabs.Length;
    InvokeRepeating("SpawnPickUp", 2f,1.5f);

  }

  private void SpawnPickUp()
  {
    _randomIndex = Random.Range(0, _countArray);
    Vector3 spawnPos = new Vector3(Random.Range(-2.8f, 2.8f), 5, 0);
    Instantiate(_pickUpPrefabs[_randomIndex], spawnPos, _pickUpPrefabs[_randomIndex].transform.rotation);
  }
}