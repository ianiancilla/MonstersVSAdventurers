using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner: MonoBehaviour
{
    [SerializeField] Defender defender;

    private void OnMouseDown()
    {
        SpawnDefender(GetSquareCentre());
    }

    private void SpawnDefender(Vector2 spawnPos)
    {
        Instantiate(defender, spawnPos, Quaternion.identity);
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
