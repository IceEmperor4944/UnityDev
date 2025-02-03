using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTank : MonoBehaviour
{
    [SerializeField] float maxTorque = 90;
    [SerializeField] float maxForce = 1;
    [SerializeField] Transform barrel;
    [SerializeField] GameObject rocket;
    public int ammo = 10;
    public float health = 50;
    [SerializeField] TMP_Text ammoText;
    [SerializeField] TMP_Text healthText;
    [SerializeField] Slider healthBar;

    float torque;
    float force;

    Rigidbody rb;
    Destructable dest;

    public bool dead = false;
    public bool win = false;
    [SerializeField] GameObject start;
    [SerializeField] GameObject end;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        dest = GetComponent<Destructable>();
    }

    void Update()
    {
        torque = dead || win ? 0 : Input.GetAxis("Horizontal") * maxTorque;
        force = dead || win ? 0 : Input.GetAxis("Vertical") * maxForce;

        if (Input.GetButtonDown("Fire1") && ammo > 0)
        {
            ammo--;
            Instantiate(rocket, barrel.position + Vector3.up, barrel.rotation);
        }

        if(Input.GetKey(KeyCode.E) && barrel.rotation.x > -22.5)
        {
            barrel.rotation = Quaternion.Euler(barrel.rotation.eulerAngles.x - 1, barrel.rotation.eulerAngles.y, barrel.rotation.eulerAngles.z);
        }
        else if (Input.GetKey(KeyCode.Q) && barrel.rotation.x < 22.5)
        {
            barrel.rotation = Quaternion.Euler(barrel.rotation.eulerAngles.x + 1, barrel.rotation.eulerAngles.y, barrel.rotation.eulerAngles.z);
        }

        ammoText.text = "Ammo: " + ammo.ToString();
        healthText.text = "Health: " + dest.Health.ToString();
        healthBar.value = dest.Health;
        if(dest.Health <= 0)
        {
            GameManager.Instance.SetLose();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == end)
        {
            GameManager.Instance.SetWin();
            transform.position = start.transform.position;
        }
    }

    // Runs at 50 fps, so no need for Delta Time
    private void FixedUpdate()
    {
        rb.AddRelativeForce(Vector3.forward * force);
        rb.AddRelativeTorque(Vector3.up * torque);
    }
}