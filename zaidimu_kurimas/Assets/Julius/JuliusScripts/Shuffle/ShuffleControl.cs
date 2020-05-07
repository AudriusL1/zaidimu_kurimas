using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShuffleControl : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    public float StopAfter = 11.5f;
    private float delay = 2f; 

    public static bool StartGame = false;
    private bool zoomed = false;
    public GameObject playButton;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StopAfter -= Time.deltaTime;

        if(StopAfter<= 0)
        {
            animator.SetBool("stop", true);
            StartGame = true;
            

            delay -= Time.deltaTime;
            if (delay <= 0)
            {
                playButton.SetActive(true);
                if (!zoomed)
                {
                    this.gameObject.transform.localScale += new Vector3(0.2f, 0.2f, 0);
                    zoomed = true;
                }


            }
        }
    }
}
