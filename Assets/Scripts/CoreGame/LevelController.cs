using System.Collections;
using System.Collections.Generic;
using UnityEditor.XR;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject levelCompleteWindow;
    [SerializeField] GameObject defenderMenu;

    private bool spawnersStopped = false;
    public bool TimeUp { get; set; }

    AttackerSpawner[] spawners;

    // Start is called before the first frame update
    void Start()
    {
        TimeUp = false;
        levelCompleteWindow.SetActive(false);
        spawners = FindObjectsOfType<AttackerSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckLevelClear();
    }

    private void CheckLevelClear()
    {
        if (TimeUp)
        {
            StopSpawners();
            if (CountAttackers() <= 0 && spawnersStopped)
            {
                foreach (AttackerSpawner spawner in spawners)
                {
                    if (!spawner.DoneSpawning) { return; }
                }
                LevelComplete();
            }
        }
    }

    private void LevelComplete()
    {
        levelCompleteWindow.SetActive(true);
        defenderMenu.SetActive(false);
        FindObjectOfType<DefenderSpawner>().SelectedDefender = null;
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
            foreach (AttackerSpawner spawner in spawners)
            { spawner.Spawning = false; }

            spawnersStopped = true;
        }
    }
}
