using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLifeUI : MonoBehaviour
{
    private Image imageComponent;
    [SerializeField] private Sprite[] LifeSprites;

    private void Awake()
    {
        imageComponent = GetComponent<Image>();
    }

    public void SetLife(int grade)
    {
        imageComponent.sprite = LifeSprites[grade];
    }
}