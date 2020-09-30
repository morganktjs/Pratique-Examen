using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMovement : MonoBehaviour
{
    public int planeSpeed = 2;
    public int rotationLRSpeed = 10;
    public GameObject helice;
    public GameObject deathParticle;
    Vector3 positionParticle;
    void Start()
    {
        deathParticle.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        positionParticle = gameObject.transform.position;
        positionParticle.z += 2f;
        if (Input.GetAxis("Jump") != 0)
        {
            helice.transform.Rotate(Vector3.left * Input.GetAxis("Jump"));
            transform.Translate(Vector3.up * planeSpeed * Time.deltaTime);
            deathParticle.SetActive(true);
            deathParticle.transform.position = positionParticle;
        }
        if (Input.GetAxis("Jump") == 0)
        {
            deathParticle.SetActive(false);
        }
        if (Input.GetAxis("Vertical") != 0)
        {
            transform.Rotate(Vector3.left * Time.deltaTime * rotationLRSpeed * Input.GetAxis("Vertical"));
        }
        if (Input.GetAxis("Horizontal") != 0)
        {
            transform.Rotate(Vector3.up * Time.deltaTime * rotationLRSpeed * Input.GetAxis("Horizontal"));
        }
    }
}
