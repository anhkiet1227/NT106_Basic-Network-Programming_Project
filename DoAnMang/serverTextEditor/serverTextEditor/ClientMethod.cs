using demoLibrary;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;

namespace serverTextEditor
{
    public class ClientMethod
    {
        public Socket socketGetSet { get; private set; }
        public NetworkStream streamGetSet { get; private set; }
        public BinaryReader readerGetSet { get; private set; }
        public BinaryWriter writerGetSet { get; private set; }

        private Thread thread;
        public ClientMethod(Socket socket)
        {
            socketGetSet = socket;
            streamGetSet = new NetworkStream(socketGetSet, true);
            readerGetSet = new BinaryReader(streamGetSet, Encoding.UTF32);
            writerGetSet = new BinaryWriter(streamGetSet, Encoding.UTF32);
        }

        private void SetupSocketMethod()
        {
            Server.ServerSocketMethod(this);
        }

        public void Start()
        {
            thread = new Thread(new ThreadStart(SetupSocketMethod));
            thread.Start();
        }
        public void Stop()
        {
            socketGetSet.Close();
            if (thread.IsAlive == true)
            {
                thread.Abort();
            }
        }
        public void SetupSendDataFunction(editorClass data)
        {
            MemoryStream memoryStream = new MemoryStream();
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(memoryStream, data);
            byte[] buffer = memoryStream.GetBuffer();

            writerGetSet.Write(buffer.Length);
            writerGetSet.Write(buffer);
            writerGetSet.Flush();
        }
        public void SendData(ClientMethod dataFromClient, string text)
        {
            if (socketGetSet.Connected == false)
            {
                return;
            }
            editorDataClass data = new editorDataClass(text);
            SetupSendDataFunction(data);
        }
    }
}
