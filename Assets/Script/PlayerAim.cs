using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    // For general shooting
    public Joystick shootJoystick;
    public GameObject bullet;
    public float bulletForce;
    
    // For line rendering
    public float range;

    // For general shooting
    float jH;
    float jV;
    Vector3 angle;
    bool aimed;

    public AudioClip FireBallSFX;
    
    // For line rendering
    LineRenderer aimLine;

    void Start()
    {
        aimLine = GetComponent<LineRenderer>();
        aimLine.useWorldSpace = true;
    }

    void Update()
    {
        jH = shootJoystick.Horizontal;
        jV = shootJoystick.Vertical;

        if ((jH >= 0.5f) || (jV >= 0.5f) || (jH <= -0.5f) || (jV <= -0.5f))
        {
            angle = new Vector3(0, 0, ((Mathf.Atan2(jV, jH) * Mathf.Rad2Deg) + 90f));
            transform.localEulerAngles = angle;

            aimLine.SetPosition(0, transform.position + (transform.up.normalized));
            aimLine.SetPosition(1, transform.position + (transform.up.normalized * range));
            //Debug.DrawRay(transform.position, transform.up * range, Color.yellow);  // only for debugging

            aimed = true;
            aimLine.enabled = true;
        }
        else
        {
            if (aimed)
            {
                Shoot();
            }
        }
    }

    void Shoot()
    {        
        this.GetComponentInParent<AudioSource>().PlayOneShot(FireBallSFX);
        GameObject bulletCopy = Instantiate(bullet, transform.position + (transform.up.normalized), transform.rotation);
        Rigidbody2D brb = bulletCopy.GetComponent<Rigidbody2D>();
        brb.velocity = transform.up * bulletForce;

        aimed = false;
        aimLine.enabled = false;
    }
}
