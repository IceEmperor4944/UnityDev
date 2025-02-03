using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] int ammoCount = 5;
    [SerializeField] int healthCount = 10;
    [SerializeField] GameObject pickupFx;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.TryGetComponent(out PlayerTank component))
            {
                component.ammo += ammoCount;
                component.health += healthCount;
                Destroy(gameObject);
                if (pickupFx != null) Instantiate(pickupFx, transform.position, Quaternion.identity);
            }
        }
    }
}