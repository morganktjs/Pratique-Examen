using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemie : MonoBehaviour, Damageable
{
    private Rigidbody2D myRigidBody;
    public int ennemieSpeed = 1;
    public ParticleSystem deathParticle;
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        //myRigidBody.MovePosition(Vector2.left * ennemieSpeed);
        Vector3 position = transform.position;
        position += Vector3.left * Time.deltaTime * ennemieSpeed;
        myRigidBody.MovePosition(position);
    }
    private void Die()
    {
        Instantiate(deathParticle, myRigidBody.transform);
        Destroy(gameObject);
    }
    public void TakeDamage(int damage)
    {
        Die();
    }
}
