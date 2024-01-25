using Unity.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movement : MonoBehaviour
{

    public float movespeed = 20f;
    public float PCsidespeed = 150f;
    private float Mobilesidespeed = 0.002f;
    public float jump = 150f;
    private bool isjumping = false;
    private Rigidbody rb;
    public static bool dead;
    public static bool answered=false;
    private Animator anim;
    public GameObject bg;
    ParticleSystem p;
    int i = 0;
    public AudioSource audiosource;
    public AudioClip movesound;
    public AudioClip deadsound;
    public AudioClip correctsound;



    private void Start()
    {
        
        dead = false;
        anim = gameObject.GetComponent<Animator>();
       
        p = gameObject.GetComponentInChildren<ParticleSystem>();
        p.Stop();
        rb = gameObject.GetComponent<Rigidbody>();
      
        
    }

    private void startinggame()
    {
        anim.SetBool("run", true);
        Destroy(bg, 1f);i++;
    }
    public void restart()
    {
        SceneManager.LoadScene("SampleScene");
    }
    private void Update()
    {
        HandleSwipeInput();
        if (dead == true)
        {
            anim.SetBool("dead", true);
            Invoke(nameof(restart), 2f);
           
        }
        if (GameManager.startgame && i==0)
        {
            Invoke(nameof(startinggame), 1f);
            
        }
      
        if ((Input.GetKeyDown(KeyCode.LeftArrow))&& transform.position.x > boundries.leftlimit && dead ==false && GameManager.startgame)
        {
            Debug.Log("<-");
            transform.Translate(Vector3.left * PCsidespeed * Time.deltaTime);
            audiosource.PlayOneShot(movesound);
        }
        if ((Input.GetKeyDown(KeyCode.RightArrow)) && transform.position.x < boundries.rightlimit && dead == false && GameManager.startgame)
        {
            Debug.Log("->");
            transform.Translate(Vector3.left * PCsidespeed * -1 * Time.deltaTime); audiosource.PlayOneShot(movesound);

        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && isjumping ==false && dead == false && GameManager.startgame)
        {
            Debug.Log("^");
            rb.AddForce(Vector3.up * jump);
            anim.SetBool("jump",true);
            isjumping = true;
            audiosource.PlayOneShot(movesound);
        }
       
        if (Input.GetKeyDown(KeyCode.DownArrow) && isjumping == false && dead == false && GameManager.startgame)
        {
            Debug.Log("v");
            rb.AddForce(Vector3.down * jump);
            transform.rotation = Quaternion.Euler(-90, transform.rotation.y, transform.rotation.z);
            anim.SetBool("sliding", true);
            p.Play();
            Invoke(nameof(standagain), 1f); audiosource.PlayOneShot(movesound);

        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && isjumping == true && dead == false && GameManager.startgame)
        {
            Debug.Log("v");
            rb.AddForce(Vector3.down * jump);
            anim.SetBool("jump", false); audiosource.PlayOneShot(movesound);

        }
        isGrounded();

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("enemy"))
        {
            dead = true; audiosource.PlayOneShot(deadsound);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            dead = true; audiosource.PlayOneShot(deadsound);
        }
        else if (other.CompareTag("correctanswer"))
        {
           answered = true;
            Scoring.points += 5; audiosource.PlayOneShot(correctsound);
        }
    }
    public void  standagain()
    {
        transform.rotation = Quaternion.Euler(0, transform.rotation.y, transform.rotation.z);
        anim.SetBool("sliding", false);
        p.Stop();
    }
  
   
    private void isGrounded()
    {
        if(transform.position.y <= -0.499)
        {
            isjumping = false;
            anim.SetBool("jump", false);
        }
        else
        {
            isjumping = true;
        }
    }
    private Touch touch;
    void HandleSwipeInput()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Moved)
            {
                if(transform.position.x < boundries.rightlimit && transform.position.x > boundries.leftlimit && dead == false && GameManager.startgame && pausebutton.ispaused ==false) 
                { transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * Mobilesidespeed, transform.position.y, transform.position.z); }
                
            }
            if(touch.phase == TouchPhase.Stationary)
            {
                anim.SetBool("hit", true);
            }
        }
    }

  
}
