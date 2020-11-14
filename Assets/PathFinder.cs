using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;


public class PathFinder : MonoBehaviour
{
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
    [SerializeField] Waypoint start = null;
    [SerializeField] Waypoint end = null;
    public bool isRunning = true;
    Waypoint searchCenter;
    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left,

    };
    List<Waypoint> path = new List<Waypoint>();

    public List<Waypoint> GetPath()
    {
        LoadBlocks();
        BreadthFirstSearch();
        CreatePath(); 
        return path;
    }

    void Start()
    {
    }

    private void CreatePath()
    {
        path.Add(end);
        Waypoint previous = end.exploredFrom;
        while (previous != start)
        {
            path.Add(previous);
            previous = previous.exploredFrom; 
        }
        path.Add(start);
        path.Reverse();
    }

    private void BreadthFirstSearch()
    {
        queue.Enqueue(start);
        if (queue.Peek() == end)
        {
            return;
        }
        while (queue.Count > 0 && isRunning)
        {
            searchCenter = queue.Dequeue();
            HaltIfEndFound();
            ExploreNeighbours();
            searchCenter.isExplored = true;
        }

    }

    private void HaltIfEndFound()
    {
        if (searchCenter == end)
        {
            isRunning = false;
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
            Vector2Int neighbourCoordinates = searchCenter.GetGridPos() + direction;
            if (grid.ContainsKey(neighbourCoordinates))
            {
                QueueNeighbours(neighbourCoordinates);
            }
        }
    }

    private void QueueNeighbours(Vector2Int neighbourCoordinates)
    {
        Waypoint neighbour = grid[neighbourCoordinates];
        if (neighbour.isExplored == false || queue.Contains(neighbour))
        {
            queue.Enqueue(neighbour);
            neighbour.exploredFrom = searchCenter;
        }
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints)
        {
            var gridPos = waypoint.GetGridPos();
            if (grid.ContainsKey(gridPos))
            {
            }
            else
            {
                grid.Add(gridPos, waypoint);
            }

            if (waypoint == start || waypoint == end)
            {
                waypoint.SetTopColor(Color.red);
            }
        }
    }
}
