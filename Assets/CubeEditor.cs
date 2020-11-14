using System.Collections;
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

    [MenuItem("GameObject/Create At 0 #&0")]
    static void createAtZero()
    {

        GameObject go = new GameObject("GameObject");
        go.transform.position = Vector3.zero;
        go.transform.rotation = Quaternion.identity;

    }


    [MenuItem("GameObject/Create Empty Parent #&e")]
    static void createEmptyParent()
    {

        GameObject go = new GameObject("GameObject");

        if (Selection.activeTransform != null)
        {
            go.transform.parent = Selection.activeTransform.parent;
            go.transform.Translate(Selection.activeTransform.position);
            Selection.activeTransform.parent = go.transform;
        }



    }

    [MenuItem("GameObject/Create Empty Duplicate #&d")]

    static void createEmptyDuplicate()
    {



        GameObject go = new GameObject("GameObject");
        if (Selection.activeTransform != null)
        {

            go.transform.parent = Selection.activeTransform.parent;
            go.transform.Translate(Selection.activeTransform.position);

        }



    }

    [MenuItem("GameObject/Create Empty Child #&n")]

    static void createEmptyChild()
    {



        GameObject go = new GameObject("GameObject");



        if (Selection.activeTransform != null)
        {

            go.transform.parent = Selection.activeTransform;
            go.transform.Translate(Selection.activeTransform.position);

        }



    }
}
