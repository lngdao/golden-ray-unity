using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Enemy : MonoBehaviour
{
    PlayerController[] players;
    PlayerController nearestPlayer;
    public float speed;
    Score score;

    private void Start()
    {
        players = FindObjectsOfType<PlayerController>();
        score = FindObjectOfType<Score>();
    }

    private void Update()
    {
        if (players.Length == 1 || players == null)
        {
            if (PhotonNetwork.IsMasterClient && PhotonNetwork.IsConnected)
            {
                PhotonNetwork.Destroy(this.gameObject);
            }
            return;
        }

        float distanceOne = Vector2.Distance(transform.position, players[0].transform.position);
        float distanceTwo = Vector2.Distance(transform.position, players[1].transform.position);


        if (distanceOne < distanceTwo)
        {
            nearestPlayer = players[0];
        } else
        {
            nearestPlayer = players[1] != null ? players[1] : players[0];
        }

        if (nearestPlayer != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, nearestPlayer.transform.position, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ray")
        {
            if (PhotonNetwork.IsMasterClient && PhotonNetwork.IsConnected)
            {
                score.AddScore();
                PhotonNetwork.Destroy(this.gameObject);
            } 
        }
    }
}
