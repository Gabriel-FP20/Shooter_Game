using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);

        }
        if(collision.CompareTag("Board"))
        {
            Destroy(gameObject);
        }
        if(collision.CompareTag("Island"))
        {
            Destroy(gameObject);
        }
        if(collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }

    }
}
