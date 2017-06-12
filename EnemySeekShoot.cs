using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySeekShoot : MonoBehaviour {
    public GameObject[] targets;
    public GameObject bulletPrefabs;
    public GameObject missilePrefabs;
    public int missileDistance;

    public Transform bulletSpawnPoint;

    private Vector3 bulletDirection;

    private Quaternion bulletRotation;

    private float lastFireTime = -1;
    private float fireInterval=0.5f;
    // Use this for initialization
    void Start () {
        targets=GameObject.FindGameObjectsWithTag("Player");
        if (bulletSpawnPoint == null)
            bulletSpawnPoint = transform;
    }
	
	// Update is called once per frame
	void Update () {
        
        bulletRotation = Quaternion.LookRotation(transform.forward);
        bulletDirection = bulletRotation * Vector3.forward;

        if (Time.time - lastFireTime > fireInterval)
        {
            foreach (GameObject player in targets)
            {
                BoxCollider myBox = GetComponent<BoxCollider>();
                Vector3 toTarget = player.transform.position - transform.position;
                //在发射范围内发射导弹
                if (toTarget.magnitude < missileDistance)
                {
                    GameObject bulletObj = Instantiate(missilePrefabs, bulletSpawnPoint.position, bulletRotation) as GameObject;
                }
                //基本面对发射Laser子弹
                float relativeDirection = Vector3.Dot(transform.forward, player.transform.forward);
                BoxCollider b = GetComponent<BoxCollider>();
                if (relativeDirection<-0.95f)
                {
                    GameObject bulletObj = Instantiate(bulletPrefabs, bulletSpawnPoint.position+ transform.forward * myBox.size.z, bulletRotation) as GameObject;
                    bulletObj.GetComponent<BulletSphere>().direction = bulletDirection;
                    bulletObj.GetComponent<BulletSphere>().shoterType = 1;//1是enemy
                }
         }
            lastFireTime = Time.time;

        }



	}
}
