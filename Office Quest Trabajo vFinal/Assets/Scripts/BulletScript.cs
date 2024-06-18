using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float Speed;
    private Rigidbody2D Rigidbody2D;
    private Vector2 Direction;
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D.velocity = Direction * Speed;
    }
    public void SetDirection(Vector2 direction)
    {
        Direction = direction;
    }
    public void DestroyBullet()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        nuevo jonh = collision.GetComponent<nuevo>();
        LoboScript grunt = collision.GetComponent<LoboScript>();
        //if (jonh != null)
        //{
        //    jonh.Hit();
        //}
        if (grunt != null)
        {
            grunt.Hit();
        }
        DestroyBullet();

    }

}