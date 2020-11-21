﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;



[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour
{
    
    Waypoint waypoint;
    private void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }
    void Update()
    {
        SnapToGrid();
        UpdateLabel();
    }

    private void SnapToGrid() 
    {
        transform.position = new Vector3(
            waypoint.GetGridPos().x * waypoint.GetGridSize(),
            0f,
            waypoint.GetGridPos().y * waypoint.GetGridSize() );
    }

    private void UpdateLabel()
    {
        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        textMesh.text = waypoint.GetGridPos().x + "," + waypoint.GetGridPos().y;
        gameObject.name = waypoint.GetGridPos().x + "," + waypoint.GetGridPos().y;
    }

}
