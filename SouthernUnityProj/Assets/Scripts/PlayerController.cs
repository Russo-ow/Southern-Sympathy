using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, TurnObject {

    Vector3 targetPos;

    public GameObject winPopup;
    public GameObject losePopup;

    bool levelInitialized;

    void Awake() {
        foreach(Tile tile in FindObjectsOfType<Tile>())
            tile.Init();
        FindObjectOfType<TurnManager>().Init();
        FindObjectOfType<TileManager>().Init();
        Init();
        foreach(Enemy enemy in FindObjectsOfType<Enemy>())
            enemy.Init();
        levelInitialized = true;
    }

    void Init() {
        TurnManager.Instance.turnObjects.Add(this);
        targetPos = new Vector3(TilePos().x, 0, TilePos().y);
    }

    Vector2Int TilePos() {
        return Tile.WorldToTileSpace(transform.position);
    }

    void Update() {
        if(!levelInitialized)
            return;

        /* Keyboard Input
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
        */
        if(Input.touchSupported) {
            if(Input.touchCount > 0) {
                Touch t = Input.GetTouch(0);
                RaycastHit hit;
                if(t.phase == TouchPhase.Began && Physics.Raycast(Camera.main.ScreenToWorldPoint(t.position), Camera.main.transform.forward, out hit)) {
                    Tile targetTile = TileManager.Instance.getTile(hit.point);
                    Debug.Log("Touch:" + targetTile.pos);
                    if(Mathf.Abs(TilePos().x - targetTile.pos.x) + Mathf.Abs(TilePos().y - targetTile.pos.y) == 1 && !targetTile.isObstacle) {
                        targetPos = Tile.TileToWorldSpace(targetTile.pos);
                        TurnManager.Instance.NewTurn();
                    }
                }
            }
        } else {
            RaycastHit hit;
            if(Input.GetMouseButtonDown(0) && Physics.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Camera.main.transform.forward, out hit)) {
                Tile targetTile = TileManager.Instance.getTile(hit.point);
                Debug.Log("Touch:" + targetTile.pos);
                if(Mathf.Abs(TilePos().x - targetTile.pos.x) + Mathf.Abs(TilePos().y - targetTile.pos.y) == 1 && !targetTile.isObstacle) {
                    targetPos = Tile.TileToWorldSpace(targetTile.pos);
                    TurnManager.Instance.NewTurn();
                }
            }
        }

        transform.position = Vector3.Lerp(transform.position, targetPos, .2f);
    }

    public void TurnUpdate() { }

    public void TurnLateUpdate() {
        Tile currentTile = TileManager.Instance.getTile(targetPos);
        if(currentTile.isGoal) {
            winPopup.SetActive(true);
            Debug.Log("Goal");
        } else if(currentTile.isTarget) {
            losePopup.SetActive(true);
            Debug.Log("Death");
        }
    }
}
