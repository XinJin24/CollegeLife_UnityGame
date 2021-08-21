using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    public float speed=5f;
    public float min_y, max_y;
    public float min_x, max_x;



    [SerializeField]private GameObject player_Bullet;
    [SerializeField]private Transform attack_Point;
    public float attack_Timer=0.35f;
    private float current_attack_Timer;
    private bool canAttack;
    public bool canMove=true;
    
    public AudioClip laserAudio;
    public AudioClip Explosion;
    private Animator anim;
    

    void Awake()
    {
        
        
    }


    // Start is called before the first frame update
    void Start()
    {
        
        
        
        current_attack_Timer = attack_Timer;
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        Attack();
    }
    void MovePlayer()
    {
      if (canMove==true)

      {
        if(Input.GetAxisRaw("Vertical")>0f)
        {
            Vector3 temp=transform.position;
            temp.y+=speed* Time.deltaTime;
            if(temp.y>max_y)
            {
                temp.y=max_y;
            }
            transform.position=temp;
        }
        if(Input.GetAxisRaw("Vertical")<0f)
        {
            Vector3 temp=transform.position;
            temp.y -=speed* Time.deltaTime;
            if(temp.y<min_y)
            {
                temp.y=min_y;
            }
            transform.position=temp;
        }
        if(Input.GetAxisRaw("Horizontal")>0f)
        {
            Vector3 temp=transform.position;
            temp.x +=speed* Time.deltaTime;
            if(temp.x>max_x)
            {
                temp.x=max_x;
            }
            transform.position=temp;

        }
        if(Input.GetAxisRaw("Horizontal")<0f)
        {
            Vector3 temp=transform.position;
            temp.x -=speed* Time.deltaTime;
            if(temp.x<min_x)
            {
                temp.x=min_x;
            }
            transform.position=temp;

        }
      }
    }
    void Attack()
    {
        attack_Timer += Time.deltaTime;
        if(attack_Timer>current_attack_Timer)
        {
            canAttack=true;
        }
        if(Input.GetKeyDown(KeyCode.X))
        {
            if(canAttack)
            {
                canAttack=false;
                attack_Timer = 0f;
                Instantiate(player_Bullet, attack_Point.position, Quaternion.identity);
                AudioSource audio=GetComponent<AudioSource>();
                audio.PlayOneShot(laserAudio);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D target)
    {
        

        if(target.tag == "EnemyBullet"||target.tag == "Enemy")
        {
            current_attack_Timer = 1000f;
            AudioSource audio=GetComponent<AudioSource>();
            audio.PlayOneShot(Explosion);
            anim.Play("Destory");
            canMove=false;
            canAttack=false;
            Invoke("DeactivateGameObject", 3f);
            HealthScript.DecrementHealth();
            GetComponent<Collider2D>().enabled = false;
          

            int heal=HealthScript.getHealth();
            if(heal<=0)
            {
                OnGameOver();
            }
            else
            {
               
                Invoke("reLoad",3f);
            }
        }
    }   
    void DeactivateGameObject() {
        gameObject.SetActive(false);
    }

    void PauseGame ()
    {
        Time.timeScale = 0;
    }
    void reLoad()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
    void OnGameOver()
    {
        
        SceneManager.LoadScene ("HighScore");
        
    }
}



