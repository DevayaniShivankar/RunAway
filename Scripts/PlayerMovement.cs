using System.Collections;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public bool alive = true;
    public float speed = 5;
    [SerializeField] Rigidbody rb;

    public static PlayerMovement inst;

    float horizontalInput;
    [SerializeField] float horizontalMultiplier = 2;
    public float speedIncreasePerPoint = 0.1f;

    [SerializeField] GameObject groundSpawner;
    public Transform startpoint;
    
    private Touch touch;

    private void FixedUpdate()
    {
        if (!alive) return;

        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        //Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + forwardMove);

        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                //transform.position = new vector3(transform.position.x + touch.deltaposition.x * speed,
                //    transform.position.y,
                //    transform.position.z + touch.deltaposition.z * speed);
                Vector3 horizontalMove = transform.right * touch.deltaPosition.x * speed * Time.fixedDeltaTime * horizontalMultiplier;
                rb.MovePosition(rb.position + horizontalMove);
            }
        }
    }

    void Awake()
    {
        inst = this;
    }

 
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if (transform.position.y < -5)
        {
            Die();
        }
    }

    public void Die()
    {
        alive = false;
        // Restart the game
        UIManager.instance.DieScreen();
        groundSpawner.GetComponent<GroundSpawner>().enabled = false;
        //Invoke("Restart", 1);
        //SceneManager.LoadScene("Die Menu", LoadSceneMode.Additive);
    }

    //void Restart()
    //{
    //    UIManager.instance.GameScreen();
   //     SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    //}

    public void ResetPosi()
    {
        transform.position = startpoint.position;
    }
}
