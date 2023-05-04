using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class MainMenu : MonoBehaviourPunCallbacks
{
    public TMPro.TMP_InputField createInput;
    public TMPro.TMP_InputField joinInput;

    public TMPro.TMP_InputField nameInput;

    public void ChangeName()
    {
        PhotonNetwork.NickName = nameInput.text;
    }

    public void CreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;
        PhotonNetwork.CreateRoom(createInput.text.ToUpper(), roomOptions);
    }

    public void JoinRoom()
    {
        Debug.Log("room:" + joinInput.text);
        PhotonNetwork.JoinRoom(joinInput.text.ToUpper());
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }


}
