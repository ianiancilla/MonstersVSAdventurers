using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceAccess : MonoBehaviour
{
    public void AddResources(int amount)
    {
        FindObjectOfType<ResourceDisplay>().AddResources(amount);
    }
}
