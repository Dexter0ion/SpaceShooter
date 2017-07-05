using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class ShootBullet : MonoBehaviour {

    public GameObject bulletPrefabs;

    public GameObject missilePrefabs;

    public Transform bulletSpawnPoint;

    private Vector3 bulletDirection;

    private Quaternion bulletRotation;

    private float lastFireTime = -1;
    public float fireInterval;

	// Use this for initialization
	void Start () {
        if (bulletSpawnPoint == null)
            bulletSpawnPoint = transform;	
	}
	
	// Update is called once per frame
	void Update () {

        bulletRotation = Quaternion.LookRotation(transform.forward);
        bulletDirection = bulletRotation * Vector3.forward;

        if(Time.time-lastFireTime>fireInterval)
        {
                Shoot();
                lastFireTime = Time.time;
            
        }


	}

    void Shoot()
    {
        bool m_fire1 = CrossPlatformInputManager.GetButton("Fire1");
        bool m_fire2 = CrossPlatformInputManager.GetButton("Fire2");
        BoxCollider myBox = GetComponent<BoxCollider>();
        if (Input.GetKey(KeyCode.J)||Input.GetKey(KeyCode.Joystick1Button0)||m_fire1==true)
        {
            
            GameObject bulletObj = Instantiate(bulletPrefabs, bulletSpawnPoint.position+transform.forward*myBox.size.z, bulletRotation) as GameObject;
            bulletObj.GetComponent<BulletSphere>().direction = bulletDirection;
            bulletObj.GetComponent<BulletSphere>().shoterType = 0;
        }

        if(Input.GetKey(KeyCode.K)|| Input.GetKey(KeyCode.Joystick1Button3)||m_fire2==true)
        {
            GameObject bulletObj = Instantiate(missilePrefabs, bulletSpawnPoint.position, bulletRotation) as GameObject;

        }
    }
}
