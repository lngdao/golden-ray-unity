using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public TMPro.TextMeshProUGUI pingDisplay;
    public TMPro.TextMeshProUGUI roomDisplay;

    void Update()
    {
        DisplayStats();
    }

    private void DisplayStats()
    {
        pingDisplay.text = "Ping: " + PhotonNetwork.GetPing().ToString();
        roomDisplay.text = "Room: " + PhotonNetwork.CurrentRoom.Name;
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }
}
