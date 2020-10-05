using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemie : MonoBehaviour, Damageable
{
    private Rigidbody2D myRigidBody;
    public int ennemieSpeed = 1;
    public AudioMusic audioMusic;
    public ParticleSystem deathParticle;
    protected SoundPlayer soundPlayer;
    void Start()
    {
        soundPlayer = GameObject.FindGameObjectWithTag("SoundPlayer").GetComponent<SoundPlayer>();
        myRigidBody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Vector3 position = transform.position;
        position += Vector3.left * Time.deltaTime * ennemieSpeed;
        myRigidBody.MovePosition(position);
    }
    private void Die()
    {
        soundPlayer.PlayMusic(audioMusic);
        Instantiate(deathParticle, myRigidBody.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    public void TakeDamage(int damage)
    {
        Die();
    }
}
