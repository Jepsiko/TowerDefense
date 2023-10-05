using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexGrid : GameGrid
{
    protected override Vector2 PosToCoord(Vector2Int pos)
    {
        float hexHeight = 0.5f / Mathf.Tan(Mathf.PI / 6);
        if (pos.x % 2 == 0)
        {
            return new Vector2(
                (pos.x - (_map.Width() / 2)) * 0.75f,
                (pos.y - (_map.Height() / 2)) * hexHeight
            );
        }
        else
        {
            return new Vector2(
                (pos.x - (_map.Width() / 2)) * 0.75f,
                (pos.y - (_map.Height() / 2)) * hexHeight + hexHeight/2
            );
        }
    }

    protected override Vector2Int[] GetNeighbours(Vector2Int pos)
    {
        if (pos.x % 2 == 0)
        {
            return new Vector2Int[] {
                pos + new Vector2Int(-1, -1),
                pos + new Vector2Int(-1, 0),
                pos + new Vector2Int(0, 1),
                pos + new Vector2Int(1, 0),
                pos + new Vector2Int(1, -1),
                pos + new Vector2Int(0, -1)
            };
        }
        else
        {
            return new Vector2Int[] {
                pos + new Vector2Int(-1, 0),
                pos + new Vector2Int(-1, 1),
                pos + new Vector2Int(0, 1),
                pos + new Vector2Int(1, 1),
                pos + new Vector2Int(1, 0),
                pos + new Vector2Int(0, -1)
            };
        }
    }
}
