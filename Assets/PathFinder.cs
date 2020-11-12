using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
    [SerializeField] Waypoint start;
    [SerializeField] Waypoint end;
    [SerializeField]  bool isRunning = true;
    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left,

    };

    // Start is called before the first frame update
    void Start()
    {
        LoadBlocks();
        PathFind();
        // ExploreNeighbours();
    }

    private void PathFind()
    {
        queue.Enqueue(start);
        if (queue.Peek() == end)
        {
            print("start and end the same point!");
            return;
        }
        while (queue.Count > 0 && isRunning)
        {
            var searchCenter = queue.Dequeue();
            print("Searching from: " + searchCenter);
            HaltIfEndFound(searchCenter);
            isRunning = false;
        }

        print("Finished pathfinding!");
    }

    private void HaltIfEndFound(Waypoint searchCenter)
    {
        if (searchCenter == end)
        {
            print("Searching from end node , Stopping!");
        }
    }

    private void ExploreNeighbours()
    {
        if (!isRunning)
        {
            return;
        }
        foreach (Vector2Int direction in directions)
        {
            Vector2Int explorationCoordinates = start.GetGridPos() + direction;
            print(explorationCoordinates);
            try
            {
            grid[explorationCoordinates].SetTopColor(Color.blue);
            }
            catch
            {

            }
        }
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
        int lastWaypoint = waypoints.Length;
        foreach (Waypoint waypoint in waypoints)
        {
            var gridPos = waypoint.GetGridPos();
            if (grid.ContainsKey(gridPos))
            {
                Debug.LogWarning("OverLAPPING");
            }
            else
            {
                grid.Add(gridPos, waypoint);
                waypoint.SetTopColor(Color.black);
            }

            if (waypoint == start || waypoint == end)
            {
                waypoint.SetTopColor(Color.red);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
