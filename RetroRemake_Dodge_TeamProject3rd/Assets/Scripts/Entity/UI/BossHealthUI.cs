using UnityEngine;
using UnityEngine.UI;

public class BossHealthUI : MonoBehaviour
{
    [SerializeField] private Image HealthGauge;

    public void SetActiveUI(bool isActive)
    {
        gameObject.SetActive(isActive);
    }

    public void SetGaugeFill(float _fillAmount)
    {
        HealthGauge.fillAmount = _fillAmount;
    }
}