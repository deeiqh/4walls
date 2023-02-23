using UnityEngine;
using WebSocketSharp;
public class WsClientB: MonoBehaviour {
    WebSocket clientB;

    private void Start() {
        clientB = new WebSocket("ws://localhost:8080");
        clientB.Connect();
        clientB.OnMessage += (stream, data) => {
            Debug.Log("[clientB][Message]: " + data.Data);
        };
    }

    private void Update() {
        if (clientB == null) {
            return;
        }

        if (Input.GetKeyDown(KeyCode.B)) {
            clientB.Send("from clientB");
        }
    }
}
