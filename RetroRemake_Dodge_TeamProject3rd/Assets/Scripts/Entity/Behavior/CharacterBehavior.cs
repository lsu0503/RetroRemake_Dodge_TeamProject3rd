using System;
using UnityEngine;

public class CharacterBehavior : MonoBehaviour
{
    public event Action<ProjectileData> OnHitEvent;
    public event Action OnDieEvent;
    public event Action OnSpawnEvent;

    public virtual bool OnHit(ProjectileData projData)
    {
        CallHitEvent(projData);
        return true;
    }

    public void CallHitEvent(ProjectileData projData)
    {
        OnHitEvent?.Invoke(projData);
    }

    public void CallDieEvent()
    {
        OnDieEvent?.Invoke();
    }

    public void CallSpawnEvent()
    {
        OnSpawnEvent?.Invoke();
    }
}
