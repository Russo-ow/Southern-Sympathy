using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {
    public bool isObstacle;
    public bool isGoal;
    public bool isTarget;

    public Vector2Int pos;

    public MeshRenderer mr;
    public Material normalTile;
    public Material targetTile;

    public void Init() {
        pos = WorldToTileSpace(transform.position);
    }

    private void Update() {
        mr.material = isTarget ? targetTile : normalTile;
    }

    public static Vector2Int WorldToTileSpace(Vector3 p) {
        return new Vector2Int(Mathf.RoundToInt(p.x), Mathf.RoundToInt(p.z));
    }

    public static Vector3 TileToWorldSpace(Vector2Int p) {
        return new Vector3(p.x, 0, p.y);
    }

    public static Vector3 TileToWorldSpace(int x, int y) {
        return new Vector3(x, 0, y);
    }
}
