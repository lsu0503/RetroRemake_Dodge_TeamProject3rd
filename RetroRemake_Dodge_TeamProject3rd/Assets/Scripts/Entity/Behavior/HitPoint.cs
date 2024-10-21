using UnityEngine;

public class HitPoint : MonoBehaviour
{
    [SerializeField] private CharacterBehavior behavior;

    public void OnHit(ProjectileData projData)
    {
        behavior.OnHit(projData);
    }
}
