using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetroyWorm : MonoBehaviour
{
    Transform target; //hitta spelaren
    GameManager manager; //keep score

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("player").transform;
        manager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = target.position - transform.position;
        direction.Normalize();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("worm"))
        {
            Destroy(collision.gameObject);
            manager.AddPoint2(); // h�nvisa till Game manager script, skapa en AddPoint function

        }

    }
}