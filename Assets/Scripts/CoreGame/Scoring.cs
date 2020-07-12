using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring : MonoBehaviour
{
    [SerializeField] int startingHealth = 500;

    public float CurrentHealth { get; set; }

    // cache
    PlayerLifeDisplay lifeDisplay;


    // Start is called before the first frame update
    void Start()
    {
        // cache
        lifeDisplay = FindObjectOfType<PlayerLifeDisplay>();

        CurrentHealth = startingHealth;
        lifeDisplay.UpdateDisplay();

    }

    public void TakeDamage(float damage)
    {
        if (damage < CurrentHealth)
        {
            CurrentHealth -= damage;
            lifeDisplay.UpdateDisplay();
        }
        else
        {
            CurrentHealth = 0;
            lifeDisplay.UpdateDisplay();
            FindObjectOfType<SceneLoader>().LoadLoseScene();
        }
    }


}
