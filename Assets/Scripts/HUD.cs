using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreLbl;
    [SerializeField] private GameObject _innerGO;
    [SerializeField] private TextMeshProUGUI _dynamicScoreLbl;

    private void Start()
    {
        SetVisible(false);
        GameManager.Instance.OnLevelCleared += ShowScreen;
    }
    
    private void Update()
    {
        _scoreLbl.text = $"Score: {GameManager.Instance.Score}";
    }
    
    private void OnDestroy()
    {
        GameManager.Instance.OnLevelCleared -= ShowScreen;
    }
    
    private void SetVisible(bool isActive)
    {
        _innerGO.SetActive(isActive);
    }
    
    private void ShowScreen()
    {
        Time.timeScale =  0;
        SetVisible(true);
        _dynamicScoreLbl.text = GameManager.Instance.Score.ToString();
    }
}
