# Realm Rush

A 3D isometric tower defense game built in Unity, featuring custom AI pathfinding using Breadth First Search (BFS) algorithm.

![Unity](https://img.shields.io/badge/Unity-2020+-black?style=flat-square&logo=unity)
![C#](https://img.shields.io/badge/C%23-239120?style=flat-square&logo=c-sharp&logoColor=white)

## Overview

Realm Rush is a tower defense tech demo that demonstrates fundamental AI pathfinding concepts. Instead of using Unity's built-in NavMesh system, this project implements pathfinding from scratch using the Breadth First Search algorithm.

## Features

- **Custom Pathfinding**: Breadth First Search (BFS) algorithm implementation
- **Tower Defense Mechanics**:
  - Towers that track and shoot enemies
  - Distance-based targeting system
  - Enemy hitpoints and damage system
- **3D Isometric Grid**: Voxel-style graphics with MagicaVoxel assets
- **Smart Enemies**: AI-controlled enemies that follow optimal paths
- **Dynamic Spawning**: Coroutine-based enemy wave system

## Technical Highlights

### Core Concepts Implemented
- **AI Pathfinding**: BFS algorithm for optimal route finding
- **C# Data Structures**:
  - `Queue<T>` for pathfinding queue
  - `Dictionary<Vector2Int, Waypoint>` for grid management
  - `List<T>` for waypoint paths
- **Unity Systems**:
  - Coroutines for time-based sequences
  - Editor scripts with `[ExecuteInEditMode]`
  - Particle systems for shooting effects
  - Text Mesh for debug labels

### Architecture
- Grid-based world with snapping system
- Modular tower and enemy components
- Cached pathfinding for performance
- Target acquisition system (closest enemy)

## How To Run

This is a Unity project:

1. Clone or download this repository
2. Open the project in Unity (2020 or later recommended)
3. Navigate to `Assets > Levels`
4. Open any `.unity` scene file
5. Press Play to test

## Project Structure

```
Realm_Rush/
├── Assets/            # Game assets, scripts, and scenes
├── Packages/          # Unity package dependencies
├── ProjectSettings/   # Unity project configuration
└── README.md
```

## Game Mechanics

**Towers**
- Automatically track nearest enemy
- Shoot when enemies are in range
- Use `Vector3.Distance()` for range checking
- Rotate to face targets with `LookAt()`

**Enemies**
- Follow BFS-calculated optimal path
- Take damage from tower projectiles
- Destroyed when hitpoints reach zero

**Pathfinding**
- Breadth First Search guarantees shortest path
- Explores neighbors in all valid directions
- Maintains breadcrumb trail for path reconstruction
- Prevents duplicate exploration with queue tracking

## Why Custom Pathfinding?

This project implements pathfinding from scratch rather than using Unity's NavMesh to:
- Understand the fundamentals of graph traversal algorithms
- Learn how pathfinding algorithms work under the hood
- Have full control over the pathfinding behavior
- Demonstrate BFS, Dijkstra's, and A* algorithm differences

## Technologies

- **Unity Engine** - Game development platform
- **C#** - Primary programming language
- **MagicaVoxel** - Voxel art assets
- **Breadth First Search** - Pathfinding algorithm

## License

MIT License - See [LICENSE](LICENSE) file for details

---

*This project was created as part of the Complete Unity Developer 2.0 course*
