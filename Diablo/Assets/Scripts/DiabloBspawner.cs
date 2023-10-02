using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiabloBspawner : MonoBehaviour
{
    enum SpawnerType { Straight, Spin }


    [Header("Bullet Attributes")]
    public GameObject bullet;
    public float bulletLife = 1f;
    public float speed = 1f;


    [Header("Spawner Attributes")]
    [SerializeField] private SpawnerType spawnerType;
    [SerializeField] private float firingRate = 1f;


    private GameObject spawnedBullet;
    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (spawnerType == SpawnerType.Spin) transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y + 1f, 0f);
        if (timer >= firingRate)
        {
            Fire();
            timer = 0;
        }


    }

    private void Fire()
    {
        if (bullet)
        {
            spawnedBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            spawnedBullet.GetComponent<BulletsDiablo>().speed = speed;
            spawnedBullet.GetComponent<BulletsDiablo>().bulletLife = bulletLife;
            spawnedBullet.transform.rotation = transform.rotation;
        }
    }

}
