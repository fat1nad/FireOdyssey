using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject Player;
    private List<GameObject> bullets;
    public GameObject bulletPrefab;
    private Camera mainCamera;
    public AudioClip ShootSound;

    private bool Shoot;
    private bool Pause;

    // Start is called before the first frame update
    void Start()
    {
        Shoot = false;
        Pause = true;
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        
    }


    void Update()
    {
        Vector3 viewPos = mainCamera.WorldToViewportPoint(this.transform.position);
        if (viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1 && viewPos.z > 0)
        {
            // Your object is in the range of the camera, you can apply your behaviour
            Shoot = true;
        }
        else
        {
            Shoot = false;
            Pause = true;
            CancelInvoke();
        }

        if(Shoot && Pause)
        {
            bulletPrefab.SetActive(true);
            //because deactivated at end of level -Z
            Player = GameObject.FindGameObjectWithTag ("Player");
            bullets = new List<GameObject>();
            Pause = false;
            InvokeRepeating("SpawnBullet", 3f, 3f);
        }
           
    }

    private void SpawnBullet()
    {
        this.GetComponent<AudioSource>().PlayOneShot(ShootSound);
        GameObject newBullet = Instantiate(bulletPrefab, transform.position, bulletPrefab.transform.rotation);
        bullets.Add(newBullet);
    }


}
