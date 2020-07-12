using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResourceDisplay : MonoBehaviour
{
    [SerializeField] int resourceCount = 100;
    TextMeshProUGUI resourceDisplay;

    // Start is called before the first frame update
    void Start()
    {
        resourceDisplay = GetComponent<TextMeshProUGUI>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        resourceDisplay.text = resourceCount.ToString();
    }

    public void AddResources(int amount)
    {
        resourceCount += amount;
        UpdateDisplay();
    }

    public void SpendResources(int amount)
    {
        if (amount <= resourceCount)
        {
            resourceCount -= amount;
        }
        UpdateDisplay();
    }

    public int GetResourceCount() { return resourceCount; }
}
