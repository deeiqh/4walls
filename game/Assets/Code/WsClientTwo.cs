using UnityEngine;
using WebSocketSharp;
public class WsClientTwo: MonoBehaviour {
    WebSocket clientOne;

    private void Start() {
        clientOne = new WebSocket("ws://localhost:8080");
        clientOne.Connect();
        clientOne.OnMessage += (stream, data) => {
            Debug.Log("[clientTwo][Message]: " + data.Data);
        };
    }

    private void Update() {
        if (clientOne == null) {
            return;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            clientOne.Send("from clientTwo");
        }
    }
}