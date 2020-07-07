using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] float spawnIntervalMin = 1f;
    [SerializeField] float spawnIntervalMax = 5f;
    [SerializeField] Attacker attackerPrefab;

    bool spawning = true;


    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (spawning)
        {
            yield return new WaitForSeconds(RandSpawnTime());
            SpawnAttacker();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private float RandSpawnTime()
    {
        return Random.Range(spawnIntervalMin, spawnIntervalMax);
    }

    private void SpawnAttacker()
    {
        Attacker newAttacker = Instantiate(attackerPrefab, transform.position, transform.rotation)
                               as Attacker;
        newAttacker.transform.parent = transform;
    }
}
