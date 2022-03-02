using UnityEngine;

public class Basket : MonoBehaviour
{
  private Camera _mainCamera;
  private Transform thisTransform;

  private void Start()
  {
    _mainCamera = Camera.main;
    thisTransform = transform;
  }

  private void Update()
  {
    FollowMouse();
  }

  private void FollowMouse()
  {
    Vector3 mousePosition = Input.mousePosition;
    Vector3 worldPosition = _mainCamera.ScreenToWorldPoint(mousePosition);

    Vector3 currentPosition = thisTransform.position;
    currentPosition.x = worldPosition.x;
    thisTransform.position = currentPosition;
  }
}