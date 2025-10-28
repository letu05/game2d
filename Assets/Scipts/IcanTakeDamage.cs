using UnityEngine;

public interface IcanTakeDamage 
{
    // Interface for objects that can take damage
    void TakeDamage(int damageAmount,Vector2 hitPoint, GameObject hitDirection);
}
