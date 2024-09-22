using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterBehaviour : MonoBehaviour
{
    private float mv_speed = 20f;

    private float shoot_speed = 20f;

    private float shoot_delay = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        // Shoot
        if (Input.GetKey(KeyCode.Space))
        {
            if (Time.time - shoot_delay <= 0.1f)
            {
              return;
            }

            shoot_delay = Time.time;

            var bullet = gameObject.transform.Find("Bullet").gameObject;
            var newBullet = GameObject.Instantiate(bullet);

            newBullet.transform.position = gameObject.transform.position;
            newBullet.SetActive(true);
        }

        if (Input.GetKey(KeyCode.LeftShift)) {
            mv_speed = 40f;
        }
        else
        {
            mv_speed = 20f;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
        }

    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            gameObject.transform.Translate(Vector3.up * mv_speed * Time.deltaTime);

            if (gameObject.transform.position.y > 20f)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, 20f, gameObject.transform.position.z);
            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.Translate(Vector3.down * mv_speed * Time.deltaTime);

            if (gameObject.transform.position.y < -20f)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, -20f, gameObject.transform.position.z);
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.Translate(Vector3.left * mv_speed * Time.deltaTime);

            if (gameObject.transform.position.x < -10f)
            {
                gameObject.transform.position = new Vector3(-10f, gameObject.transform.position.y, gameObject.transform.position.z);
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.Translate(Vector3.right * mv_speed * Time.deltaTime);

            if (gameObject.transform.position.x > 10f)
            {
                gameObject.transform.position = new Vector3(10f, gameObject.transform.position.y, gameObject.transform.position.z);
            }
        }
    }
}
