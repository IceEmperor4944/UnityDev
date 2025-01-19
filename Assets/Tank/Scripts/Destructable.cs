using UnityEngine;

public class Destructable : MonoBehaviour, IDamageable
{
    [SerializeField] float health = 20;
    [SerializeField] GameObject destroyFx;

    bool destroyed = false;

    public void ApplyDamage(float damage)
    {
        health -= damage;
        if(health <= 0 )
        {
            destroyed = true;
            if(destroyFx != null) Instantiate(destroyFx, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}