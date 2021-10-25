using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, TurnObject {

    Vector3 targetPos;

    void Awake() {
        TurnManager.Instance.turnObjects.Add(this);
    }

    Vector2Int TilePos() {
        return Tile.WorldToTileSpace(transform.position);
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.W) && !TileManager.Instance.isObstacle(TilePos().x, TilePos().y + 1)) {
            targetPos = Tile.TileToWorldSpace(TilePos().x, TilePos().y + 1);
            TurnManager.Instance.NewTurn();
        }
        if(Input.GetKeyDown(KeyCode.S) && !TileManager.Instance.isObstacle(TilePos().x, TilePos().y - 1)) {
            targetPos = Tile.TileToWorldSpace(TilePos().x, TilePos().y - 1);
            TurnManager.Instance.NewTurn();
        }
        if(Input.GetKeyDown(KeyCode.A) && !TileManager.Instance.isObstacle(TilePos().x - 1, TilePos().y)) {
            targetPos = Tile.TileToWorldSpace(TilePos().x - 1, TilePos().y);
            TurnManager.Instance.NewTurn();
        }
        if(Input.GetKeyDown(KeyCode.D) && !TileManager.Instance.isObstacle(TilePos().x + 1, TilePos().y)) {
            targetPos = Tile.TileToWorldSpace(TilePos().x + 1, TilePos().y);
            TurnManager.Instance.NewTurn();
        }

        transform.position = Vector3.Lerp(transform.position, targetPos, .2f);
    }

    public void TurnUpdate() { }

    public void TurnLateUpdate() {
        Tile currentTile = TileManager.Instance.getTile(targetPos);
        if(currentTile.isTarget) {
            //Death
            Debug.Log("Death");
        }
        if(currentTile.isGoal) {
            //Reached Goal
            Debug.Log("Goal");
        }
    }
}
