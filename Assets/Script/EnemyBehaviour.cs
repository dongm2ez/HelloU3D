using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private float _current_HP = 100f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (null == collision) { return; }

        Debug.Log("Collision detected: " + collision.gameObject.tag);

        if (collision.gameObject.tag == "Bullet")
        {
            _current_HP -= 10f;
            Destroy(collision.gameObject);
        }

        if (_current_HP <= 0)
        {
            Destroy(gameObject);
        }
    }


}
