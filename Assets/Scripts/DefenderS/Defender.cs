using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int resourceCost = 100;

    public int GetResourceCost() { return resourceCost; }
}
