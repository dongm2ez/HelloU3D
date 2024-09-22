using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    private const float MV_SPEED = 64f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(Vector3.up * MV_SPEED * Time.deltaTime);

        if (gameObject.transform.position.y > 30f)
        {
            Destroy(gameObject);
        }

        if (gameObject.transform.position.y < -30f)
        {
            Destroy(gameObject);
        }

        if (gameObject.transform.position.x < -30f)
        {
            Destroy(gameObject);
        }

        if (gameObject.transform.position.x > 30f)
        {
            Destroy(gameObject);
        }
    }
}
