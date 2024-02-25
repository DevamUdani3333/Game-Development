using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Asteroid : MonoBehaviour
{
    public float speed = 0.5f;
    
    public float rotationSpeed = 30;
    private int count = 10;
    public TextMeshPro countText;
    public Vector3 axis=Vector3.forward;

    private void Start()
    {
        rotationSpeed = Random.Range(-120, 50);
        countText.text = count.ToString();
    }
    
    // Update is called once per frame
    void Update()
    {
        transform.position -= Vector3.up * speed * Time.deltaTime;
        //transform.Rotate(axis, rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        count--;
        countText.text = count.ToString();
        if (count <= 0)

        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider collision)
    {
        Destroy(gameObject);
    }
    
}
