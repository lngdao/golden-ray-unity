using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class RoomItem : MonoBehaviour
{
    public TMPro.TextMeshProUGUI roomName;
    public TMPro.TextMeshProUGUI roomPlayerNumber;
    MainMenu mainMenu;

    private void Start()
    {
        mainMenu = FindObjectOfType<MainMenu>();
    }

    public void SetRoomName(string _roomName)
    {
        roomName.text = _roomName;
    }

    public void SetRoomPlayerNumber(string _roomPlayerNumber)
    {
        roomPlayerNumber.text = _roomPlayerNumber;
    }

    public void OnClickItem()
    {
        mainMenu.JoinRoom(roomName.text);
    }
}
