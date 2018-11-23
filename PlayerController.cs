using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float speed = 5;
    [SerializeField]
    private GameObject laser;
    [SerializeField]
    private float coolDownTime = 1;

    private float nextFireTime;

    [SerializeField]
    private GameObject explosion;

    void Start () {
        Vector3 pos = new Vector3(0, -3.75f, 0);
        transform.position = pos;
       
    }
	
	// Update is called once per frame
	void Update ()
    {
        HandlePlayerMovement();

        HandleSceneBounds();

        HandleFire();
    }

    private void HandleFire()
    {
        if( (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && Time.time > nextFireTime)
        {
            var laserPos = new Vector3(transform.position.x, transform.position.y + 1.6f, transform.position.z);
            Instantiate(laser, laserPos, Quaternion.identity);
            nextFireTime = Time.time + coolDownTime;
        }
    }

    private void HandleSceneBounds()
    {
        Vector3 newPos = transform.position;
        if (transform.position.y > 0)
        {
            newPos = new Vector3(transform.position.x, 0, transform.position.z);

        }
        else if (transform.position.y < -3.75)
        {
            newPos = new Vector3(transform.position.x, -3.75f, transform.position.z);
        }

        transform.position = newPos;

        if (transform.position.x > 9.75)
        {
            newPos = new Vector3(-9.75f, newPos.y, newPos.z);
        }
        else if (transform.position.x < -9.75)
        {
            newPos = new Vector3(9.75f, newPos.y, newPos.z);
        }

        transform.position = newPos;
    }

    private void HandlePlayerMovement()
    {
        float directionX = Input.GetAxisRaw("Horizontal");
        if (Mathf.Abs(directionX) < 0)
        {
            directionX = 0;
        }

        float directionY = Input.GetAxisRaw("Vertical");
        if (Mathf.Abs(directionY) < 0)
        {
            directionY = 0;

        }

        transform.Translate(Vector3.right * speed * Time.deltaTime * directionX);
        transform.Translate(Vector3.up * speed * Time.deltaTime * directionY);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var pos = transform.position;
        Destroy(collision.gameObject);
        Destroy(gameObject);
        Instantiate(explosion, pos, Quaternion.identity);

    }

}
