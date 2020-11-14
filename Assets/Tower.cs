using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    [SerializeField] Transform ObjectToPan;
    [SerializeField] Transform TargetToLookAt;

    void Update()
    {
        ObjectToPan.LookAt(TargetToLookAt);
    }
}
