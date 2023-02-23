using UnityEngine;
using WebSocketSharp;
public class WsClientA: MonoBehaviour {
    WebSocket clientA;

    private void Start() {
        clientA = new WebSocket("ws://localhost:8080");
        clientA.Connect();
        clientA.OnMessage += (stream, data) => {
            Debug.Log("[clientA][Message]: " + data.Data);
        };
    }

    private void Update() {
        if (clientA == null) {
            return;
        }

        if (Input.GetKeyDown(KeyCode.A)) {
            clientA.Send("from clientA");
        }
    }
}
