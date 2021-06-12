using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPivot : MonoBehaviour
{
    public Transform lastElement {get; set;}
    public int lastIndex {get; set;}

    void Start()
    {
        lastElement = transform;
        lastIndex = 0;
    }
}
