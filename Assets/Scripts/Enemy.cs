using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public GameObject healthBar;

    public int damage;

    public int i;
    public GameObject[] lifes;
    public SpriteRenderer spriteRenderer;

    public GameObject explosion;

    public EnemyMoveTest enemy;

    public GameObject ship;

    public EnemyAttack attack;




    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if(currentHealth <= 0)
        {   
            enemy.Stop();
            attack.StopShoot();
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
            // i = i;
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

        if(collision.CompareTag("Island"))
        {

            enemy.speed = 0f;

        }


        if(collision.gameObject.tag == "Shoot_Front")
        {
            

            currentHealth = currentHealth - damage;
            UpdateHealthBar();
            UpdateLifeImage();
            if(currentHealth <= 0)
            {
                GameController.score++;
            }
                
        }
    }


    IEnumerator Explosion()
    {
        yield return new WaitForSeconds(2.0f);
        Destroy(ship.gameObject);

    }
    

}

