using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPivot : MonoBehaviour
{
    public Transform lastElement {set; get;}

    void Start()
    {
        lastElement = transform;
    }
}
