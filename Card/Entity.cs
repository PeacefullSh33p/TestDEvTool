using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{

    public abstract void TakeDamage(int Damage);

    protected abstract bool ShouldDie();

    protected abstract void Die();
}
