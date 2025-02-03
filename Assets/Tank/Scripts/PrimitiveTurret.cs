using System.Collections;
using UnityEngine;

public class PrimitiveTurret : MonoBehaviour
{
    [SerializeField] GameObject rocketPrefab;
    [SerializeField] Transform barrel;
    [SerializeField, Range(0.5f, 5)] float spawnTime;
    [SerializeField, Range(0.5f, 5)] float spawnTimeMin;
    [SerializeField, Range(0.5f, 5)] float spawnTimeMax;

    float spawnTimer;

    void Start()
    {
        StartCoroutine(SpawnFire());
        //spawnTimer = spawnTime;
    }

    void Update()
    {
        //spawnTimer -= Time.deltaTime;
        //if (spawnTimer <= 0)
        //{
        //    spawnTimer = spawnTime;
        //    Instantiate(rocketPrefab, barrel.position, barrel.rotation);
        //}
    }

    IEnumerator SpawnFire()
    {
        while (true)
        {
            spawnTime = Random.Range(spawnTimeMin, spawnTimeMax);
            yield return new WaitForSeconds(spawnTime);
            Instantiate(rocketPrefab, barrel.position, barrel.rotation);
        }
    }
}