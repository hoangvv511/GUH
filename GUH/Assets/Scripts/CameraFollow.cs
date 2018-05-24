﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public float smoothTimeX, smoothTimeY;
    public Vector2 vectocity;

    public GameObject player;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(this.transform.position.x, player.transform.position.x, ref vectocity.x, smoothTimeX);
        float posY = Mathf.SmoothDamp(this.transform.position.y, player.transform.position.y, ref vectocity.y, smoothTimeY);
        transform.position = new Vector3(posX, posY, transform.position.z);
    }
}