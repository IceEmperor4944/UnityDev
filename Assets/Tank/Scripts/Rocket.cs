using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float force = 100;
    void Start()
    {
        GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * force, ForceMode.VelocityChange);
    }
}