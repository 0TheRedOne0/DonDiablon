using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsDon : MonoBehaviour
{

    public float bulletLife = 1f;  // Defines how long before the bullet is destroyed
    public float rotation = 0f;
    public float speed = 1f;


    private Vector3 spawnPoint;
    private float timer = 0f;




    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = new Vector3(transform.position.x, 0f, transform.position.z);

    }

    // Update is called once per frame
    void Update()
    {


        if (timer > bulletLife) Destroy(this.gameObject);
        timer += Time.deltaTime;
        transform.position = Movement(timer);

    }



    private Vector3 Movement(float timer)
    {
        // Moves right according to the bullet's rotation
        float x = timer * speed * transform.right.x;
        float z = timer * speed * transform.right.z;
        float y = timer * speed * transform.right.y;
        return new Vector3(x + spawnPoint.x, 0f, z + spawnPoint.z);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Diablo"|| collision.gameObject.tag == "Obstacle")
        {
            Destroy(this.gameObject);

        }
    }
}
