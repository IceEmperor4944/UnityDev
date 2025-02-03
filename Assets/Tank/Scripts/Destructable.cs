using UnityEngine;

public class Destructable : MonoBehaviour, IDamageable
{
    [SerializeField] float health = 20;
    [SerializeField] GameObject destroyFx;
    [SerializeField] AudioClip damageSound;

    bool destroyed = false;

    public float Health { get { return health; } set { health = (value < 0) ? 0 : value; } }

    public void ApplyDamage(float damage)
    {
        AudioSource audio = GetComponent<AudioSource>();

        audio.clip = damageSound;
        audio.Play();
        health -= damage;
        if (health <= 0 )
        {
            destroyed = true;
            if(destroyFx != null) Instantiate(destroyFx, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}