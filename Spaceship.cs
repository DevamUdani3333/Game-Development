using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    public float speed = 0.1f;
    public GameObject BulletPrefab;
    public Vector3 pos;
    public Transform bulletPointRigth;
    public Transform bulletPointLeft;
    private float fireRate = 0.5f; //fire every half second
    private float nextFire = 0.0f;   //next time we can fire
    private float recoilTime = 0.1f; //recoil time in seconds

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        nextFire = Time.time + fireRate + recoilTime;
    }

    // Update is called once per frame
    void Update()
    {
        MoveSpaceship();
        FireBullet();
    }

    public void FireBullet()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(BulletPrefab, bulletPointRigth.position, Quaternion.identity);
            Instantiate(BulletPrefab, bulletPointLeft.position, Quaternion.identity);
            nextFire = Time.time + fireRate + recoilTime;
        }
    }

    private void MoveSpaceship()
    {
        if(Input.GetKey(KeyCode.RightArrow))
        {
            pos=transform.position + Vector3.right * speed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            pos=transform.position - Vector3.right * speed * Time.deltaTime;
        }
        float xPos = Mathf.Clamp(pos.x, -1.8f, 1.8f);
        pos = new Vector3(xPos, pos.y, pos.z);
        transform.position = pos;
    }
}
