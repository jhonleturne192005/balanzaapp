using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{

    internal class csWebSocket 
    {
        //public static String dataUser { get; set; }
        public static WebSocket socketss;

        public csWebSocket() { }

        public async void init()
        {
            HttpListener listener= new HttpListener();
            listener.Prefixes.Add("http://localhost:7000/ws/");
            listener.Start();
            Console.WriteLine("Listening for WebSocket connections... ws://localhost:7000/ws/");

            while (true)
            {
                HttpListenerContext context = await listener.GetContextAsync();
                if(context.Request.IsWebSocketRequest)
                {
                    HttpListenerWebSocketContext wsContext = await context.AcceptWebSocketAsync(null);
                    Console.WriteLine("Client connected");
                    Task.Run(()=> ReadWebSocket(wsContext.WebSocket)); 
                }
            }

        }

        public static async Task ReadWebSocket(WebSocket socket)
        {
            socketss = socket;
            byte[] buffer = new byte[1024];
            while (socket.State == WebSocketState.Open)
            {
                WebSocketReceiveResult receiveResult = await socket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                if (receiveResult.MessageType == WebSocketMessageType.Text)
                {
                    String receivedMessage = Encoding.UTF8.GetString(buffer, 0, receiveResult.Count);
                    Console.WriteLine($"Received message: {receivedMessage}");

                    byte[] bufferDat = Encoding.UTF8.GetBytes($"Hello from server");
                    //byte[] bufferDat = Encoding.UTF8.GetBytes(dataUser.ToCharArray());
                    await socket.SendAsync(new ArraySegment<byte>(bufferDat), WebSocketMessageType.Text, true, CancellationToken.None);
                }
                else if (receiveResult.MessageType == WebSocketMessageType.Close)
                {
                    await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "", CancellationToken.None);
                    Console.WriteLine("WebSocket closed.");
                }
            }
        }

        public static async Task sendMessageSocket(String dataUser)
        {
            if (socketss == null)
            {
                Console.WriteLine("No existe referencia de conexion de WebSocket....");
                return;
            }
            byte[] buffer = new byte[1024];
            byte[] bufferDat = Encoding.UTF8.GetBytes(dataUser.ToCharArray());
            await socketss.SendAsync(new ArraySegment<byte>(bufferDat), WebSocketMessageType.Text, true, CancellationToken.None);
        }



    }
}
