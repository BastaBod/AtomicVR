using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class FalconHere : MonoBehaviour
{
    public string pathToUnityExe;
    public string arguments;

    private Process falconApp;

    // Start is called before the first frame update
    void Start()
    {
        StartUnityApp();
    }

    public void StartUnityApp()
    {
        ProcessStartInfo startInfo = new ProcessStartInfo();
        startInfo.FileName = pathToUnityExe;
        startInfo.Arguments = arguments;

        falconApp = new Process();
        falconApp.StartInfo = startInfo;

        // Démarrer le processus de manière asynchrone
        falconApp.Start();
    }

    private void OnApplicationQuit()
    {
        falconApp.CloseMainWindow();
    }
}
