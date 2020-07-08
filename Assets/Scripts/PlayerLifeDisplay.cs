using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLifeDisplay : MonoBehaviour
{
    // cache
    TextMeshProUGUI lifeDisplay;
    Scoring scoring;

    // Start is called before the first frame update
    void Start()
    {
        // cache
        lifeDisplay = GetComponent<TextMeshProUGUI>();
        scoring = FindObjectOfType<Scoring>();

        UpdateDisplay();

    }

    public void UpdateDisplay()
    {
        lifeDisplay.text = scoring.CurrentHealth.ToString();
    }
}
