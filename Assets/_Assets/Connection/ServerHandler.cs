using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Net;
using UnityEngine;
using System.Text;
using System;
using System.IO;

public enum ConnectionType
{
    SERVER, 
    CLIENT
}

public class ServerHandler : MonoBehaviour
{
    public String Host = "localhost";
    public Int32 Port = 55000;
    public int codeToSend;
    public bool starOnAwake = false;

    private TcpListener listener = null;
    private TcpClient client = null;
    private NetworkStream ns = null;

    private bool started = false;

    // Start is called before the first frame update
    void Awake()
    {
        started = false;
        if (starOnAwake)
            StartHost();
    }

    // Update is called once per frame
    void Update()
    {
        if (!started)
            return;

        if (client == null)
        {
            if (listener.Pending())
            {
                client = listener.AcceptTcpClient();
                Debug.Log("Connected");
            }
            else
            {
                return;
            }
        }
        else
        {
            ProcessMessage();
        }
    }

    private void ProcessMessage()
    {
        ns = client.GetStream();

        if((ns != null) && (ns.DataAvailable))
        {
            StreamReader reader = new StreamReader(ns);
            string msg = reader.ReadLine();
            Debug.Log(msg);
            SynchronizeManager.RaiseSyncRequest(msg);
        }
    }

    public void SendMessage(int code)
    {
        if (client == null)
            return;

        Byte[] sendBytes = System.Text.Encoding.UTF8.GetBytes(code + "\n");
        Debug.Log("Sending : " + code);
        if(client.Connected)
        {
            client.GetStream().Write(sendBytes, 0, sendBytes.Length);
            Debug.Log("Sent");
        }
    }

    private void OnApplicationQuit()
    {
        if (listener != null)
            listener.Stop();
    }

    public void SetIp(string ip)
    {
        Host = ip;
    }

    public void SetPort(string port)
    {
        Port = int.Parse(port);
    }


    public void StartHost()
    {
        Debug.Log("dns" + Dns.GetHostEntry(Host).AddressList[1]);
        listener = new TcpListener(Dns.GetHostEntry(Host).AddressList[1], Port);
        listener.Start();
        Debug.Log("is listening");

        if (listener.Pending())
        {
            client = listener.AcceptTcpClient();
            Debug.Log("Connected");
        }
        started = true;
    }
}