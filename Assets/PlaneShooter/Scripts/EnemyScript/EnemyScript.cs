using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EnemyScript : MonoBehaviour
{
    public float speed=7f;
    public float rotate_Speed=50f;

    public bool canShoot;
    public bool canRotate;
    public bool canMove=true;
    public bool isBoss;

    public float bound_X=-11f;
    public Transform attack_Point;
    public Transform attack_Point1;
    public Transform attack_Point2;
    public Transform attack_Point3;
    public float chasingSpeed=3f;
    [SerializeField]
    CharacterController _controller;
    Transform target;
    GameObject Player;
    public GameObject bulletPrefab;

    private Animator anim;
    public AudioClip laserAudio;
    public AudioClip Explosion;

    public HealthBarBehaviour Healthbar;
    
    public float MaxHealth=5;
    public float currentHealth=5;




    void Awake()
    {
        anim=GetComponent<Animator>();
        
    }

    void Start()
    {
        
        Player = GameObject.FindWithTag("Player"); 
        target = Player.transform;
        if(canRotate)
        {
            if(Random.Range(0, 2) >0)
            {
                rotate_Speed = Random.Range(rotate_Speed, rotate_Speed + 20f);
                rotate_Speed *= -1f;
            }
            
        }
        if(canShoot&&isBoss)
        {
            Invoke("bossStartShooting", Random.Range(1f, 3f));
        }
        else if(canShoot)
        {
            Invoke("StartShooting", Random.Range(1f, 3f));
        }   
    }

    void Update()
    {
        Move();
        RotateEnemy();
    }
    void Move()
    {

        if(canMove&&isBoss)    
        {
            Vector2 temp=transform.position;
            temp.x -= speed*Time.deltaTime;
            if(temp.x <= 5.5f)
            {
                temp.x=5.5f;
            }
            transform.position=temp;  
            Vector2 direction = target.position;
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, target.position.y), chasingSpeed * Time.deltaTime);

          

        }
        else
        {
            Vector3 temp=transform.position;
            temp.x -= speed*Time.deltaTime;
            transform.position=temp;

            if(temp.x < bound_X)
            {
                gameObject.SetActive(false);
            }
        }
    }

    void RotateEnemy()
    {
        if(canRotate)
        {
            transform.Rotate(new Vector3(0f, 0f, rotate_Speed* Time.deltaTime), Space.World);
        }
    }
    void StartShooting()
    {
        GameObject bullet=Instantiate(bulletPrefab, attack_Point.position, Quaternion.identity);
        bullet.GetComponent<BulletScript>().is_EnemyBullet=true;
        AudioSource audio=GetComponent<AudioSource>();
        audio.PlayOneShot(laserAudio);

        if(canShoot)
        {
            Invoke("StartShooting", Random.Range(1f, 3f));
        }
    }

    void bossStartShooting()
    {
        GameObject bullet=Instantiate(bulletPrefab, attack_Point.position, Quaternion.identity);
        GameObject bullet1=Instantiate(bulletPrefab, attack_Point1.position, Quaternion.identity);
        GameObject bullet2=Instantiate(bulletPrefab, attack_Point2.position, Quaternion.identity);
        GameObject bullet3=Instantiate(bulletPrefab, attack_Point3.position, Quaternion.identity);
        bullet.GetComponent<BulletScript>().is_EnemyBullet=true;
        bullet1.GetComponent<BulletScript>().is_EnemyBullet=true;
        bullet2.GetComponent<BulletScript>().is_EnemyBullet=true;
        bullet3.GetComponent<BulletScript>().is_EnemyBullet=true;
        AudioSource audio=GetComponent<AudioSource>();
        audio.PlayOneShot(laserAudio);

        if(canShoot)
        {
            Invoke("bossStartShooting", Random.Range(1f, 2f));
        }
    }

    void OnTriggerEnter2D(Collider2D target)
    {

        if(target.tag == "PlayerBullet")
        {
            
            if(isBoss)
            {
                if(currentHealth>0)
                {
                    currentHealth=currentHealth-1;
                    //Debug.Log(currentHealth+"    "+MaxHealth);
                    Healthbar.setHealth(currentHealth, MaxHealth);
                }
                
                if(currentHealth<=0)
                {
                    GetComponent<Collider2D>().enabled = false;
                    canMove=false;
                    canShoot=false;
                    CancelInvoke("bossStartShooting");
                    TurnOffGameObject();
                    anim.Play("Destory");
                    AudioSource audio=GetComponent<AudioSource>();
                    audio.PlayOneShot(Explosion);
                    ScoreScript.IncrementScore(10);
                    SceneManager.LoadScene ("HighScore");

                }
            }
            else
            {
                GetComponent<Collider2D>().enabled = false;
                canShoot=false;
                CancelInvoke("StartShooting");
                Invoke("TurnOffGameObject", 1f);
                anim.Play("Destory");
                AudioSource audio=GetComponent<AudioSource>();
                audio.PlayOneShot(Explosion);
                ScoreScript.IncrementScore();
            }
        }
    }
    void TurnOffGameObject()
    {
        gameObject.SetActive(false);
    }



}
