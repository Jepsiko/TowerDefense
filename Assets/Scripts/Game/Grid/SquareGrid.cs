using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareGrid : GameGrid
{
    protected override Vector2 PosToCoord(Vector2Int pos)
    {
        return new Vector2(
            pos.x - (_map.Width() / 2),
            pos.y - (_map.Height() / 2)
        );
    }

    protected override Vector2Int[] GetNeighbours(Vector2Int pos)
    {
        return new Vector2Int[] {
            pos + Vector2Int.left,
            pos + Vector2Int.right,
            pos + Vector2Int.down,
            pos + Vector2Int.up
        };
    }
}
