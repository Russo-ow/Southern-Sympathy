using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, TurnObject {
    public DirUtility.RotateDir rotateDir;
    public DirUtility.Dir currentDir;
    public int range;

    Vector2Int TilePos() {
        return Tile.WorldToTileSpace(transform.position);
    }

    public void Init() {
        UpdateTargedTiles();
        TurnManager.Instance.turnObjects.Add(this);
    }

    public void TurnUpdate() {
        currentDir = DirUtility.NextDir(rotateDir, currentDir);
        UpdateTargedTiles();
    }

    public void TurnLateUpdate() { }

    public void UpdateTargedTiles() {
        Vector2Int currentPos = TilePos();
        Vector2Int checkDir = Vector2Int.zero;
        int mapSize = TileManager.Instance.mapSize;
        switch(currentDir) {
            case DirUtility.Dir.Up:
                checkDir = Vector2Int.up;
                break;
            case DirUtility.Dir.Down:
                checkDir = Vector2Int.down;
                break;
            case DirUtility.Dir.Left:
                checkDir = Vector2Int.left;
                break;
            case DirUtility.Dir.Right:
                checkDir = Vector2Int.right;
                break;
        }
        for(int i = 1;i <= range;i++) {
            Vector2Int tPos = new Vector2Int(currentPos.x + checkDir.x * i, currentPos.y + checkDir.y * i);
            if(0 <= tPos.x && tPos.x < mapSize && 0 <= tPos.y && tPos.y < mapSize) {
                Tile t = TileManager.Instance.map[tPos.x, tPos.y];
                if(!t.isObstacle)
                    t.isTarget = true;
            }
        }
    }
}
