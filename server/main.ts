import { WebSocketServer } from "ws";

const port = 8080;
const wss = new WebSocketServer({ port }, () => {
  console.log(`Server started at port ${port}`);
});

wss.on("listening", () => {
  console.log(`Listening on ${port}`);
});

let walls: Array<any>;

wss.on("connection", function connection(scene) {
  walls = Array.from(wss.clients);

  scene.on("message", (data) => {
    console.log("[Message]: ", data.toString());

    if (data.toString() == "sceneB") {
      walls[1].send("load");
    }

    scene.send("from Server");
  });
});
