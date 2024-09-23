using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private float _current_HP = 100f;

    private float _lastBeHitTime = -1f;

    private IEnumerator _shakeCoroutine = null;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        _shakeCoroutine?.MoveNext();

        if (_lastBeHitTime > 0 && Time.time - _lastBeHitTime <= 0.05f)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
        else
        {
            gameObject.GetComponent<Renderer>().material.color = Color.white;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (null == collision) 
        {
            return;
        }

        if (null == _shakeCoroutine)
        {
            _shakeCoroutine = DoShake();
        }

        _current_HP -= 10f;
        _lastBeHitTime = Time.time;

        

        if (_current_HP <= 0)
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator DoShake()
    {
        var currPosXYZ = gameObject.transform.position;
        var currPosX = currPosXYZ.x;
        var lX = currPosX - 0.5f;
        var rX = currPosX + 0.5f;

        // 往左抖
        while (gameObject.transform.position.x > lX)
        {
            gameObject.transform.position += Vector3.left * (Time.deltaTime * 10f);
            yield return 1;
        }

        // 往右抖
        while (gameObject.transform.position.x < rX)
        {
            gameObject.transform.position += Vector3.right * (Time.deltaTime * 10f);
            yield return 1;
        }

        // 回到原位
        while (gameObject.transform.position.x > currPosX)
        {
            gameObject.transform.position += Vector3.left * (Time.deltaTime * 10f);
            yield return 1;
        }

        gameObject.transform.position = currPosXYZ;

        _shakeCoroutine = null;
    }
}
