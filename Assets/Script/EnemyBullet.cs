using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Vector3 playerPosition;
    //private Camera mainCamera;
    private Vector3 direction;
    
    
    void Start()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        //mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        direction = (this.transform.position - playerPosition).normalized;
    }


    // Update is called once per frame
    void Update()
    {
        float step = 5f * Time.deltaTime;

        this.transform.position += -direction * step;

        /* if (transform.position.x < -1045 || transform.position.x > 1050 )
         {
             Destroy(this.gameObject);
         }
         if (transform.position.y < -816 || transform.position.y > 1559 )
         {
             Destroy(this.gameObject);
         }*/
        //Vector3 viewPos = mainCamera.WorldToViewportPoint(this.transform.position);
        //if (viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1 && viewPos.z > 0)
        //{

        //}
        //else{
        //    Destroy(this.gameObject);
        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerDeath>().Killed();
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
