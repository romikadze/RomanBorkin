using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack : MonoBehaviour
{
    public abstract bool IsReady { get; }
    public abstract float Cooldown { get; }
    public abstract float Damage { get; }
    public abstract void Activate();
}
