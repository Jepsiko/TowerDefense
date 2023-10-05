using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameGrid : MonoBehaviour
{
    [Header("Cell Prefabs")]
    public GameObject tilePrefab;
    public GameObject towerTilePrefab;
    public GameObject pathTilePrefab;
    public GameObject startTilePrefab;
    public GameObject finishTilePrefab;

    private GameObject[,] _tiles;
    private Vector2Int _startPos;
    private Vector2Int _finishPos;
    private Transform[] _path;

    private GameController _controller;
    protected Map _map;

    protected abstract Vector2 PosToCoord(Vector2Int pos);
    protected abstract Vector2Int[] GetNeighbours(Vector2Int pos);

    public void GenerateGrid(Map map)
    {
        _controller = GetComponent<GameController>();
        _map = map;
        _tiles = new GameObject[map.Width(), map.Height()];
        for (int x = 0; x < map.Width(); x++)
        {
            for (int y = 0; y < map.Height(); y++)
            {
                _tiles[x, y] = SpawnCellAt(new Vector2Int(x, y));
            }
        }
        _path = CreatePath();
    }

    private GameObject SpawnCellAt(Vector2Int pos)
    {
        GameObject cell;
        switch (_map.GetType(pos))
        {
            case Map.CellType.Tower:
                cell = Instantiate(towerTilePrefab, _controller.grid);
                break;
            case Map.CellType.Path:
                cell = Instantiate(pathTilePrefab, _controller.grid);
                break;
            case Map.CellType.Start:
                cell = Instantiate(startTilePrefab, _controller.grid);
                _startPos = pos;
                break;
            case Map.CellType.Finish:
                cell = Instantiate(finishTilePrefab, _controller.grid);
                _finishPos = pos;
                break;
            case Map.CellType.Cell:
            default:
                cell = Instantiate(tilePrefab, _controller.grid);
                break;
        }
        
        cell.name = pos.ToString();
        cell.transform.position = PosToCoord(pos);
        return cell;
    }

    public GameObject GetFinishTile()
    {
        return GetTile(_finishPos).gameObject;
    }

    private Transform GetTile(Vector2Int pos)
    {
        return _tiles[pos.x, pos.y].transform;
    }

    private Vector2Int GetNextPathTile(Vector2Int current, Vector2Int previous)
    {
        foreach (Vector2Int neighbour in GetNeighbours(current))
        {
            if (_map.InMap(neighbour) && neighbour != previous &&
               (_map.GetType(neighbour) == Map.CellType.Path || _map.GetType(neighbour) == Map.CellType.Finish))
                return neighbour;
        }
        throw new System.Exception("No valid next path tile found !");
    }

    private Transform[] CreatePath()
    {
        List<Transform> waypoints = new List<Transform>();
        Vector2Int previous = _startPos;
        Vector2Int current = previous;
        while (current != _finishPos)
        {
            waypoints.Add(GetTile(current));
            Vector2Int temp = current;
            current = GetNextPathTile(current, previous);
            previous = temp;
        }
        waypoints.Add(GetTile(current));
        return waypoints.ToArray();
    }

    public Transform[] GetPath()
    {
        return _path;
    }
}
