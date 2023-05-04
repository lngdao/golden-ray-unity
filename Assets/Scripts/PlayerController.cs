using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviour
{
    public float speed;
    PhotonView view;
    Animator anim;
    Health healthScript;

    LineRenderer rend;

    public TMPro.TextMeshProUGUI nameDisplay;

    private void Start()
    {
        view = GetComponent<PhotonView>();
        anim = GetComponent<Animator>();
        healthScript = FindObjectOfType<Health>();
        rend = FindObjectOfType<LineRenderer>();

        if (view != null && view.IsMine)
        {
            nameDisplay.text = PhotonNetwork.NickName;
        } else
        {
            //nameDisplay.text = "Toi dai dot " + Random.Range(1, 1000).ToString();
            nameDisplay.text = view.Owner.NickName;
        }
    }

    private void Update()
    {
        if (view.IsMine)
        {
            Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            Vector2 moveAmount = moveInput.normalized * speed * Time.deltaTime;
            transform.position += (Vector3)moveAmount;

            if (moveInput == Vector2.zero)
            {
                anim.SetBool("isRunning", false);
            } else
            {
                anim.SetBool("isRunning", true);
            }

            rend.SetPosition(0, transform.position);
        } else
        {
            rend.SetPosition(1, transform.position);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (view != null && view.IsMine)
        {
            if (collision.tag == "Enemy")
            {
                healthScript.TakeDamege();
            }
        }
    }
}
