using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace AppTelao
{
    class Servidor
    {
        MainWindow mainWindow;

        public Servidor(MainWindow m)
        {
            this.mainWindow = m;          
        }

        public void Up()
        {
            TcpListener server = null;
            try
            {
                Int32 port = 13000;
                IPAddress localAddr = IPAddress.Parse("127.0.0.1");
                server = new TcpListener(localAddr, port);
                server.Start();
                // Buffer for reading data
                Byte[] bytes = new Byte[256];
                String data = null;               
                while (true)
                {
                    TcpClient client = server.AcceptTcpClient();
                    data = null;
                    // Get a stream object for reading and writing
                    NetworkStream stream = client.GetStream();
                    while (client.Connected == true)
                    {
                        if (stream.DataAvailable == true)
                        {
                            // Translate data bytes to a ASCII string.
                            data = System.Text.Encoding.ASCII.GetString(bytes, 0, stream.Read(bytes, 0, bytes.Length));

                            mainWindow.NovoTweet(data);

                            // Process the data sent by the client.
                            data = data.ToUpper();
                        }
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes("");
                        // Send back a response.
                        try
                        {
                            stream.Write(msg, 0, msg.Length);
                        }
                        catch
                        {
                        }
                    }
                    client.Close();
                }
            }
            catch (SocketException e)
            {
            }
            finally
            {
                server.Stop();
            }

        }
    }
}

