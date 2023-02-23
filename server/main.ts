import { WebSocketServer } from "ws";

const port = 8080;
const wss = new WebSocketServer({ port }, () => {
  console.log(`Server started at port ${port}`);
});

wss.on("listening", () => {
  console.log(`Listening on ${port}`);
});

wss.on("connection", function connection(stream) {
  stream.on("message", (data) => {
    console.log("[Message]: ", data.toString());
    stream.send("from Server");
  });
});
