using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Map : ScriptableObject
{
    [Serializable]
    public class MapRow
    {
        public CellType[] row;
    }

    public enum CellType { Cell, Tower, Path, Start, Finish };
    public MapRow[] grid;

    public int Width() { return grid[0].row.Length; }
    public int Height() { return grid.Length; }
    public CellType GetType(Vector2Int pos) { return grid[pos.y].row[pos.x]; }
    public bool InMap(Vector2Int pos) { return 0 <= pos.x && pos.x < Width() && 0 <= pos.y && pos.y < Height(); }
}
