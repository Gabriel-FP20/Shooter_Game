using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    public Weapon weapon;

    Vector2 moveDirection;
    Vector2 mousePosition;

    public int maxHealth;
    public int currentHealth;
    public GameObject healthBar;
    public int damage;


    public int i;
    public GameObject[] lifes;
    public SpriteRenderer spriteRenderer;

    public GameObject explosion;

    public bool canShootFront = true;
    public bool canShootSide = true;

    public PanelController defeatPanel;

    public PlayerMove movement;



    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if(currentHealth == 0)
        {
            movement.Stop();
            movement.Death();
            explosion.SetActive(true);
            healthBar.SetActive(false);
            StartCoroutine(Explosion());
        }


        if(Input.GetMouseButtonDown(0)&&canShootFront)
        {
            weapon.FireFront();
            canShootFront = false;
            StartCoroutine(ShootFrontDelay());
        }

        if(Input.GetMouseButtonDown(1)&&canShootSide)
        {
            weapon.FireRight();
            weapon.FireLeft();
            canShootSide = false;
            StartCoroutine(ShootSideDelay());
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

        if(collision.CompareTag("Enemy"))
        {
            currentHealth = currentHealth - damage;
            UpdateHealthBar();
            UpdateLifeImage();

        }
        if(collision.CompareTag("Board"))
        {
            movement.Stop();


        }
        if(collision.CompareTag("Island"))
        {
            movement.Stop();


        }

    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Board"))
        {
            movement.Movement();


        }
        if(collision.CompareTag("Island"))
        {
            movement.Movement();

        }

    }
    

    
    IEnumerator Explosion()
    {
        yield return new WaitForSeconds(2.0f);
        defeatPanel.DefeatPanel();
        Destroy(gameObject);

    }

    IEnumerator ShootFrontDelay()
    {
     yield return new WaitForSeconds(0.5f);
     canShootFront = true;
    }

    IEnumerator ShootSideDelay()
    {
     yield return new WaitForSeconds(2);
     canShootSide = true;
    }
}
