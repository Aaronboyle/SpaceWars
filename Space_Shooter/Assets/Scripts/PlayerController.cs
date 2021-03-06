﻿
using System.Collections;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float tilt;
    public Boundary boundary;
    private float playerHealth;
    //private bool playerIsDead;

    public float PlayerHealth
    {
        get => playerHealth;
        set => playerHealth = value;
    }

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;

    public Transform playerShip;

    private float nextFire;

    public void Start()
    {
        playerHealth = 100.0f;
        //playerIsDead = false;
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            GetComponent<AudioSource>().Play();
        }

        //if (playerHealth < 0)
            //playerIsDead = true;
    }

    public float PlayerIsHit()
    {
        playerHealth -= 20;
        return playerHealth;
    }

    public float PlayerRegenHealth() //Add health back to player
    {
        playerHealth += 10;
        return playerHealth;
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        GetComponent<Rigidbody>().velocity = movement * speed;

        GetComponent<Rigidbody>().position = new Vector3
            (Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax), 
            0.0f, 
            Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax));
    }
}
