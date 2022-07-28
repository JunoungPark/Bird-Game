using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    Touch touch;
    SpriteRenderer sprite;
    public float speed = 10.0f;
    private Rigidbody2D rigid;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");

        if (Input.touchCount > 0)
        {
            x = Input.touches[0].deltaPosition.x;
            y = Input.touches[0].deltaPosition.y;
        }
        if(Input.GetAxis("Mouse X") > 0)
        {
            sprite.flipX = false;
        }
        else if(Input.GetAxis("Mouse X") < 0)
        {
            sprite.flipX = true;
        }
        transform.Translate(x * speed * Time.deltaTime, y * speed * Time.deltaTime, transform.position.z);
        //Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        //
        //if (pos.x < 0f) pos.x = 0.1f;
        //if (pos.x > 1f) pos.x = 0.9f;
        //if (pos.y < 0f) pos.y = 0.25f;
        //if (pos.y > 1f) pos.y = 0.95f;
        //transform.position = Camera.main.ViewportToScreenPoint(pos);
    }
    public void Jump()
    {
        sprite = GetComponent<SpriteRenderer>();
        rigid.AddForce(new Vector2(0, 100));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AdManager.instance.ShowAd();
    }
}
