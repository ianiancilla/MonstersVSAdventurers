using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner: MonoBehaviour
{
    [SerializeField] AudioClip placementSound;

    public Defender SelectedDefender { get; set; }

    // cache
    ResourceDisplay resources;

    private void Start()
    {
        resources = FindObjectOfType<ResourceDisplay>();
    }

    private void OnMouseDown()
    {
        SpawnDefender(GetSquareCentre());
    }

    private void SpawnDefender(Vector2 spawnPos)
    {
        
        if (SelectedDefender)
        {
            var cost = SelectedDefender.GetResourceCost();

            if (cost <= resources.GetResourceCount())
            {
                resources.SpendResources(cost);
                Defender newDefender = Instantiate(SelectedDefender, spawnPos, Quaternion.identity) as Defender;
                AudioSource.PlayClipAtPoint(placementSound, transform.position);
            }
        }

    }

    private Vector2 GetSquareCentre()
    {
        var clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float squareX = Mathf.RoundToInt(clickPos.x);
        float squareY = Mathf.RoundToInt(clickPos.y);

        var squareCentre = new Vector2(squareX, squareY);
        return squareCentre;
    }

}
