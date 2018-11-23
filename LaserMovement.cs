using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMovement : MonoBehaviour {

    [SerializeField]
    private float speed = 7;
	void Start () {
		
	}
	void Update ()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        if(transform.position.y > 6f)
        {
            Destroy(gameObject);
        }
	}
 
}
