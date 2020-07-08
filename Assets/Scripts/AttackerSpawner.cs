using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] float spawnIntervalMin = 1f;
    [SerializeField] float spawnIntervalMax = 5f;
    [SerializeField] Attacker[] attackerPrefabs;

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

    private float RandSpawnTime()
    {
        return Random.Range(spawnIntervalMin, spawnIntervalMax);
    }

    private void SpawnAttacker()
    {
        // pick a random attacker - choose random index number within array length
        var attacker = attackerPrefabs[Random.Range(0, attackerPrefabs.Length)];
        Spawn(attacker);
    }

    private void Spawn( Attacker attacker)
    {
        Attacker newAttacker = Instantiate(attacker, transform.position, transform.rotation)
                                       as Attacker;
        newAttacker.transform.parent = transform;
    }
}
