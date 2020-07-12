using System.Collections;
using System.Collections.Generic;
using UnityEditor.XR;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject levelCompleteWndow;

    private bool spawnersStopped = false;
    public bool TimeUp { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        TimeUp = false;

        levelCompleteWndow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (TimeUp)
        {
            StopSpawners();

            if (CountAttackers() <= 0)
            {
                levelCompleteWndow.SetActive(true);
            }
        }
    }

    private int CountAttackers()
    {
        Attacker[] attackers = FindObjectsOfType<Attacker>();
        return attackers.Length;
    }

    private void StopSpawners()
    {
        if (!spawnersStopped)
        {
            AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();

            foreach (AttackerSpawner spawner in spawners)
            {
                spawner.Spawning = false;
            }
            spawnersStopped = true;
        }
    }
}
