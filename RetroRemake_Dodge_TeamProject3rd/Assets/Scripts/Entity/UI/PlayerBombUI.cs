using UnityEngine;

public class PlayerBombUI : MonoBehaviour
{
    public void SetBomb(bool isHolding)
    {
        gameObject.SetActive(isHolding);
    }
}
