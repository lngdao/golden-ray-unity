using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Health : MonoBehaviour
{
    public int health = 10;
    public TMPro.TextMeshProUGUI healthDisplay;

    PhotonView view;

    public GameObject gameOver;

    private void Start()
    {
        view = GetComponent<PhotonView>();
    }

    public void TakeDamege()
    {
        view.RPC("TakeDamageRPC", RpcTarget.All);
    }

    [PunRPC]
    void TakeDamageRPC()
    {
        if (health > 0)
        {
            health--;
        }

        if (health <= 0)
        {
            gameOver.SetActive(true);
        }

        healthDisplay.text = health.ToString();
    }
}
