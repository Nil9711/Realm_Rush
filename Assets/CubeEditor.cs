﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
[SelectionBase]
public class CubeEditor : MonoBehaviour
{
    
    [Range(0f,20f)][SerializeField] float gridSize = 10f;
    TextMesh textMesh;
    void Update()
    {
        Vector3 snapPos;
        snapPos.x = Mathf.RoundToInt(transform.localPosition.x / gridSize) * gridSize;
        snapPos.z = Mathf.RoundToInt(transform.localPosition.z / gridSize) * gridSize;
        transform.position = new Vector3(snapPos.x,0f,snapPos.z);

        textMesh = GetComponentInChildren<TextMesh>();
        textMesh.text = snapPos.x / gridSize + "," + snapPos.z / gridSize;
    }
}
