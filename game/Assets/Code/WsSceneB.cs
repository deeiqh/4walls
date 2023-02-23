using UnityEngine;
using WebSocketSharp;
using UnityEngine.SceneManagement;

public class WsSceneB: MonoBehaviour {
    WebSocket sceneB;

    private void Start() {
        sceneB = new WebSocket("ws://localhost:8080");
        sceneB.Connect();

        sceneB.OnMessage += (stream, data) => {
            Debug.Log("[sceneB][Message]: " + data.Data);
            
            if (data.Data == "act") {
               //do something
            }
        };
    }

    private void Update() {
        if (sceneB == null) {
            return;
        }

        if (Input.GetKeyDown(KeyCode.B)) {
            sceneB.Send("from sceneB");
        }
    }
}
