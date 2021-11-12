using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Audio;

public class BulletComputer : MonoBehaviour
{
    private Rigidbody2D rb2d;
    [SerializeField] private GameObject splashSprite;
    // Start is called before the first frame update

    public AudioSource splashAudio; // Water Splash
    public AudioSource inKillZoneAudio; // Explosion
    public AudioSource hitComputer; // Bullet hit metal
    
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    Quaternion rot;
    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(new Vector3(rb2d.velocity.x, rb2d.velocity.y, transform.position.z)); // This causes the object to rotate to point at wherever the object is heading (Currently causing unneccesary rotation)
        rot.eulerAngles = new Vector3(0, 0, transform.rotation.z * 100);
        transform.rotation = rot;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Destroy(other.gameObject, 0.2f);
            //Do game over
            Destroy(gameObject);
        }


        if (other.tag == "Killzone")
        {
            Destroy(gameObject);
        }

        if (other.tag == "Water")
        {
            GameObject splash = Instantiate(splashSprite, transform.position, Quaternion.identity);
            Destroy(splash, 0.15f);
            Destroy(gameObject);
        }
    }

}
