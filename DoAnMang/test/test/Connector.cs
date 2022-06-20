using demoLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test
{
    public partial class Connector
    {
        private MainForm form;
        private TcpClient tcpClient;
        private NetworkStream stream;
        private BinaryWriter writer;
        private BinaryReader reader;
        private Thread thread;

        public bool IsHandleCreated { get; private set; }

        

        public void SetupSendDataFunction(editorClass data)
        {
            MemoryStream memoryStream = new MemoryStream();
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(memoryStream, data);
            byte[] buffer = memoryStream.GetBuffer();

            writer.Write(buffer.Length);
            writer.Write(buffer);
            writer.Flush();
        }
        public void SendData(string text)
        {
            if (tcpClient.Connected == false)
            {
                return;
            }
            editorDataClass data = new editorDataClass(text);
            SetupSendDataFunction(data);
        }
        private delegate void AppendTextDelegate(string str);
        private void outputText(string text)
        {
            Variable.pubRtf1 = text;
        }
        private void processSeverRespone()
        {
            try
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                int numberInputByte;
                //while ((numberInputByte = reader.ReadInt32()) != 0)
                while(true)
                {
                    numberInputByte = reader.ReadInt32();
                    byte[] bytes = reader.ReadBytes(numberInputByte);
                    MemoryStream memoryStream = new MemoryStream(bytes);
                    editorClass packet = binaryFormatter.Deserialize(memoryStream) as editorClass;

                    switch (packet.type)
                    {
                        case editorType.DATA:
                            string message = ((editorDataClass)packet).data;
                            outputText(message);
                            break;
                    }
                }
            }
            catch (Exception exc)
            {
                outputText("Caution: " + exc.Message);
            }
        }
        public bool makeConnect(MainForm cform, string hostname, int port, string nickname)
        {
            try
            {

                form = cform;
                tcpClient = new TcpClient();
                tcpClient.Connect(hostname, port);
                stream = tcpClient.GetStream();
                writer = new BinaryWriter(stream, Encoding.UTF8);
                reader = new BinaryReader(stream, Encoding.UTF8);
                thread = new Thread(new ThreadStart(processSeverRespone));
                thread.Start();
            }
            catch (Exception exc)
            {
                outputText("Exception: " + exc.Message);
                return false;
            }
            return true;
        }
        public void makeDisconnect()
        {
            try
            {
                reader.Close();
                writer.Close();
                tcpClient.Close();
                thread.Abort();
            }
            catch (Exception exc)
            {
                outputText("Caution: " + exc.Message);
            }
            outputText("Disconnect");
        }
    }
}
