using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongerEnemyMovement : MonoBehaviour {

    private const float SCREEN_UPPER_BOUND = 6.25f;
    private const float SCREEN_LOWER_BOUND = -6.25f;

    private float speed;

    [SerializeField]
    private float minVelocity = 1;
    [SerializeField]
    private float maxVelocity = 3;
    [SerializeField]
    private GameObject explosion;
    [SerializeField]
    private int lifePoints = 2;

    // Use this for initialization
    void Start()
    {
        Reset();

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if (transform.position.y <= SCREEN_LOWER_BOUND)
        {
            Reset();
        }

    }

    void SetStartPosition()
    {
        float startX = Random.Range(-6.75f, 6.75f);

        transform.position = new Vector3(startX, SCREEN_UPPER_BOUND, 0);
    }

    private void Reset()
    {
        speed = Random.Range(minVelocity, maxVelocity);
        SetStartPosition();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        lifePoints--;

        if(lifePoints!=0)
        {
            Destroy(collision.gameObject);
        }

        if (lifePoints == 0)
        {
            lifePoints = 2;
            var pos = transform.position;
            Destroy(collision.gameObject);
            Reset();
            Instantiate(explosion, pos, Quaternion.identity);
        }
    }
}
