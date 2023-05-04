using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameOver : MonoBehaviour
{
    public TMPro.TextMeshProUGUI scoreDisplay;
    public GameObject restartButton;
    public GameObject waitingText;

    PhotonView view;

    void Start()
    {
        view = GetComponent<PhotonView>();
        scoreDisplay.text = FindObjectOfType<Score>().score.ToString();

        if (!PhotonNetwork.IsMasterClient)
        {
            restartButton.SetActive(false);
            waitingText.SetActive(true);
        } else
        {
            restartButton.SetActive(true);
            waitingText.SetActive(false);
        }
    }

    public void OnClickRestart()
    {
        view.RPC("RestartRPC", RpcTarget.All);
    }

    [PunRPC]
    void RestartRPC()
    {
        PhotonNetwork.LoadLevel("Game");
    }
}
