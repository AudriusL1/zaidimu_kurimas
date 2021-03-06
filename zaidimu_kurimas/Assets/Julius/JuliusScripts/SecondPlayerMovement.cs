﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondPlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public BombControl BombContr;
    public GameObject Explosion;
    SpriteRenderer render;
    public Animator animator;

    public float runSpeed = 40f;

    float horizontalMove = 1f;
    bool jump = false;
    public bool hasBomb = false;
    public bool shoudbedestoryed = false;
    private bool hasExploded = false;

    void Start(){
        render = GetComponent<SpriteRenderer>();
    }
    
    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal2") * runSpeed;
        animator.SetFloat("speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump2"))
        {
            jump = true;

        }

        if (hasBomb)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            render.material.SetColor("_Color", Color.red);
        }
        else
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            render.material.SetColor("_Color", Color.white);
        }

        if (shoudbedestoryed && !hasExploded)
        {

            GameObject a = Instantiate(Explosion) as GameObject;
            a.transform.position = gameObject.transform.position;
            Destroy(gameObject);
            hasExploded = true;

            Destroy(a, 0.35f); Destroy(gameObject);

        }

        //  Debug.Log(gameObject.tag);
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player1" && hasBomb)
        {
            BombContr.ChangeTags(2, 1);
        }

        if (col.gameObject.tag == "Player3" && hasBomb)
        {
            BombContr.ChangeTags(2, 3);
        }

        if (col.gameObject.tag == "Player4" && hasBomb)
        {
            BombContr.ChangeTags(2, 4);
        }

        if (col.gameObject.tag == "Shield" && hasBomb)
        {
            BombContr.ChangeTags(2, 3);
            Destroy(col.gameObject);
        }

    }


}
