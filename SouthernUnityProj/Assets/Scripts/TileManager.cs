using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {
    public static TileManager Instance;

    void Awake() {
        if(Instance != null) {
            Destroy(Instance.gameObject);
            Debug.LogError("2 TileManagers in scene. Destroying older TileManager.");
        }
        Instance = this;
    }

    public int mapSize;

    public Tile[,] map;

    void Start() {
        map = new Tile[mapSize, mapSize];
        MapFromChildren();
    }

    public bool isObstacle(int x, int y) {
        if(x < 0 || x >= mapSize || y < 0 || y >= mapSize)
            return true;
        return map[x, y].isObstacle;
    }

    public Tile getTile(int x, int y) {
        if(x < 0 || x >= mapSize || y < 0 || y >= mapSize)
            return null;
        else return map[x, y];
    }

    public Tile getTile(GameObject o) {
        int x = (int)o.transform.position.x;
        int y = (int)o.transform.position.z;
        if(x < 0 || x >= mapSize || y < 0 || y >= mapSize)
            return null;
        else return map[x, y];
    }

    void MapFromChildren() {
        if(GetComponentsInChildren<Tile>().Length != mapSize * mapSize) {
            Debug.LogError("Incorrect number of Tiles parented to TileManager.");
        }
        foreach(Tile tile in GetComponentsInChildren<Tile>()) {
            map[tile.pos.x, tile.pos.y] = tile;
        }
    }
}
