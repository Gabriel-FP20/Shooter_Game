using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamikaze : MonoBehaviour
{
    private float speed = 0.5f;
    public GameObject player;

    public int maxHealth;
    public int currentHealth;
    public GameObject healthBar;

    public int damage;

    public  bool destroy;

    public int i;
    public GameObject[] lifes;
    public SpriteRenderer spriteRenderer;

    public GameObject explosion;

    public GameObject enemyShip;
    public GameObject ship;

    public GameObject barPoint;






    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            ship.transform.position = Vector2.MoveTowards(ship.transform.position, player.transform.position, speed * Time.deltaTime);
            Vector3 direction = player.transform.position - ship.transform.position;
            healthBar.transform.position = barPoint.transform.position;
            enemyShip.transform.rotation = Quaternion.Euler(0.0f, 0.0f, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90f);        
        }

        if(currentHealth <= 0)
        {
            speed = 0f;
            healthBar.SetActive(false);
            explosion.SetActive(true);
            StartCoroutine(Explosion());
        }
    }

    private void UpdateHealthBar()
    {
        healthBar.transform.localScale = new Vector3(currentHealth * 100/maxHealth, 8.37f, 1f);
    }

    private void UpdateLifeImage()
    {
        spriteRenderer = lifes[i].GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
        if(i == 3)
        {
            i = i;
        }
        else
        {
            i++;
        }
        spriteRenderer = lifes[i].GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Shoot_Front"))
        {
            currentHealth = currentHealth - damage;
            UpdateHealthBar();
            UpdateLifeImage();
            if(currentHealth <= 0)
            {
                GameController.score++;
            }

        }

        if(collision.CompareTag("Player"))
        {
            healthBar.SetActive(false);
            explosion.SetActive(true);
            speed = 0f;
            StartCoroutine("Explosion");
        }
        
        if(collision.CompareTag("Island"))
        {
            speed = 0f;
        }
    }

    IEnumerator Explosion()
    {
        yield return new WaitForSeconds(2.0f);
        Destroy(gameObject);

    }
}
