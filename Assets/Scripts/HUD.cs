using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public TextMeshProUGUI ScoreLbl;

    private void Update()
    {
        ScoreLbl.text = $"Score: {GameManager.Instance.Score}";
    }
}
