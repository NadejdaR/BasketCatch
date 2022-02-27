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
  }

  private void Update()
  {
    SpawnPickUp();
  }

  private void SpawnPickUp()
  {
    _randomIndex = Random.Range(0, _countArray);
    Instantiate(_pickUpPrefabs[_randomIndex], new Vector3(0, 0, 20), _pickUpPrefabs[_randomIndex].transform.rotation);
  }
}