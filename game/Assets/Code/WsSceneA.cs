using UnityEngine;
using WebSocketSharp;
public class WsSceneA: MonoBehaviour {
    WebSocket sceneA;

    private void Start() {
        sceneA = new WebSocket("ws://localhost:8080");
        sceneA.Connect();
        
        sceneA.OnMessage += (stream, data) => {
            Debug.Log("[sceneA][Message]: " + data.Data);
        };
    }

    private void Update() {
        if (sceneA == null) {
            return;
        }

        if (Input.GetKeyDown(KeyCode.A)) {
            sceneA.Send("sceneB");
        }
    }
}
