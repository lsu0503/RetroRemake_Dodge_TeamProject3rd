using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BossResultUI : MonoBehaviour
{
    private BossDefeatInformation info;

    [SerializeField] private Image bossImg;
    [SerializeField] private TextMeshProUGUI ratioTxt;
    [SerializeField] private TextMeshProUGUI totalScoreTxt;

    public void UpdateUI(BossDefeatInformation info, int playerNum)
    {
        bossImg.sprite = info.bossImg;
        ratioTxt.text = string.Format($"{info.damageRatio[playerNum]:p2}");
        totalScoreTxt.text = info.totalScore.ToString();
    }
}