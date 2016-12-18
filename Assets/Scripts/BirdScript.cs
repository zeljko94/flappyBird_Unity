using UnityEngine;
using System.Collections;

public class BirdScript : MonoBehaviour {
    public Vector2 speed = new Vector2(10, 10);
    public float jumpRate = 0.5f;

    private float jumpCooldown;
    private Vector2 movement;
    private Rigidbody2D rigidBody;

    private int score = 0;

    public static bool isEnabled = true;
    bool jeLiStisnutSpace = false;

    void Start()
    {
        gameObject.tag = "Player";
        jumpCooldown = 0f;
    }

    void Update()
    {
        if (!isEnabled) enabled = isEnabled;

        if (jumpCooldown > 0)
        {
            jumpCooldown -= Time.deltaTime;
        }

        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jeLiStisnutSpace = true;
        }

        if(Input.GetKeyUp("space"))
        {
            jeLiStisnutSpace = false;
        }

        if(jeLiStisnutSpace)
        {
            if (CanJump() && gameObject.transform.position.y <= 4.5f)
            {
                movement = new Vector2(movement.x, speed.y * 1.0f);
                jumpCooldown = jumpRate;
                GetComponent<Animation>().Play();
            }
            else
            {
                jeLiStisnutSpace = false;
            }
        }
        else
        {
            movement = new Vector2(movement.x, speed.y * -0.3f);
            GetComponent<Animation>().Stop();
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    void FixedUpdate()
    {
        if (rigidBody == null)
        {
            rigidBody = GetComponent<Rigidbody2D>();
        }
        rigidBody.velocity = movement;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Floor")
            MainLoopScript.isGameOver = true;
        if (coll.gameObject.tag == "Pipe")
            MainLoopScript.isGameOver = true;
        if (coll.gameObject.tag == "Bod")
        {
            score += 10;
            ScoreTextScript.setScoreTxt(score);

            Destroy(coll.gameObject);
            SpawnPipes.bodRazmaci.Remove(coll.gameObject);
        }
    }

    bool CanJump()
    {
        return jumpCooldown <= 0f;
    }
}
