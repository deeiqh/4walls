using UnityEngine;
using WebSocketSharp;
public class WsClientOne: MonoBehaviour {
    WebSocket clientOne;

    private void Start() {
        clientOne = new WebSocket("ws://localhost:8080");
        clientOne.Connect();
        clientOne.OnMessage += (stream, data) => {
            Debug.Log("[clientOne][Message]: " + data.Data);
        };
    }

    private void Update() {
        if (clientOne == null) {
            return;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            clientOne.Send("from clientOne");
        }
    }
}