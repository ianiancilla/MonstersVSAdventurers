using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DefenderButton : MonoBehaviour
{
    [Header ("Looks")]
    [SerializeField] Color colorDark = new Color32(22, 25, 27, 255);
    [SerializeField] Color colorLight = Color.white;

    [Header("Logic")]
    [SerializeField] Defender defenderPrefab;

    //cache
    DefenderSpawner defenderSpawner;

        private void Start()
    {
        defenderSpawner = FindObjectOfType<DefenderSpawner>();

        LabelButtonsWithCost();
    }

    private void LabelButtonsWithCost()
    {
        TextMeshProUGUI costText = GetComponentInChildren<TextMeshProUGUI>();
        costText.text = defenderPrefab.GetResourceCost().ToString();
    }

    private void OnMouseDown()
    {
        ChangeButtonColours();
        defenderSpawner.SelectedDefender = defenderPrefab;

    }

    private void ChangeButtonColours()
    {
        var buttons = FindObjectsOfType<DefenderButton>();

        foreach (DefenderButton button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = button.colorDark;
        }

        GetComponent<SpriteRenderer>().color = colorLight;
    }
}
