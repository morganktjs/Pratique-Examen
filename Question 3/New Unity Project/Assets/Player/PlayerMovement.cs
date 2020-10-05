using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rbd2;
    public int speedPlayer = 5;
    public GameObject bulletPrefab;

    void Start()
    {
        rbd2 = GetComponent<Rigidbody2D>(); 
    }

    void Update()
    {
        if (Input.GetAxis("Vertical") != 0)
        {
            rbd2.MovePosition(new Vector2(rbd2.position.x , Mathf.Clamp(rbd2.position.y + speedPlayer * Time.deltaTime * Input.GetAxis("Vertical"), -12, 12)));
        }
        if (Input.GetAxis("Jump") != 0)
        {
            ShootBullet();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ennemie")
        {
            Die();
        }
    }
    private void Die()
    {
        Destroy(gameObject);
    }
    private void ShootBullet()
    {
        Instantiate(bulletPrefab, transform.position + transform.forward, transform.rotation);
    }

}
