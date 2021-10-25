using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour {
    public static TurnManager Instance;

    private void Awake() {
        if(Instance != null) {
            Debug.LogError("2 TurnManager Instances active.");
            Destroy(Instance);
        }
        Instance = this;
    }

    public List<TurnObject> turnObjects = new List<TurnObject>();
    public int turn;

    public void NewTurn() {
        turn++;
        foreach(Tile t in TileManager.Instance.map)
            t.isTarget = false;
        foreach(TurnObject t in turnObjects)
            t.TurnUpdate();
        foreach(TurnObject t in turnObjects) {
            t.TurnLateUpdate();
        }
    }
}
