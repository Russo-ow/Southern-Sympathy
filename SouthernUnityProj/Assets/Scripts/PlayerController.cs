using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Vector3 targetPos;

    void Start() {

    }

    Vector2Int TilePos() {
        return Tile.WorldToTileSpace(transform.position);
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.W) && !TileManager.Instance.isObstacle(TilePos().x, TilePos().y + 1))
            targetPos = Tile.TileToWorldSpace(TilePos().x, TilePos().y + 1);
        if(Input.GetKeyDown(KeyCode.S) && !TileManager.Instance.isObstacle(TilePos().x, TilePos().y - 1))
            targetPos = Tile.TileToWorldSpace(TilePos().x, TilePos().y - 1);
        if(Input.GetKeyDown(KeyCode.A) && !TileManager.Instance.isObstacle(TilePos().x - 1, TilePos().y))
            targetPos = Tile.TileToWorldSpace(TilePos().x - 1, TilePos().y);
        if(Input.GetKeyDown(KeyCode.D) && !TileManager.Instance.isObstacle(TilePos().x + 1, TilePos().y))
            targetPos = Tile.TileToWorldSpace(TilePos().x + 1, TilePos().y);

        transform.position = Vector3.Lerp(transform.position, targetPos, .2f);
    }
}
