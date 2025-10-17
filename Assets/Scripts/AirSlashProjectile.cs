using System;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class AirSlashProjectile : MonoBehaviour
{
    private bool hit;
    private float direction;
    private float projectileSpeed = 12;
    private float lifeTime;

    private Animator anim;
    private BoxCollider2D boxCollider;


    void Start()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }


    void Update()
    {
        if (hit) return;
        float movementSpeed = projectileSpeed * Time.deltaTime * direction;
        transform.Translate(movementSpeed, 0, 0);

        lifeTime += Time.deltaTime;
        if (lifeTime > 3)
        {
            gameObject.SetActive(false);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        boxCollider.enabled = false;
        anim.SetTrigger("fade");
    }

    public void SetDirection(float _direction)
    {
        lifeTime = 0;
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;

        float localScaleX = transform.localScale.x;
        if (Mathf.Sign(localScaleX) != _direction)
        {
            localScaleX = -localScaleX;
        }

        transform.localScale = new Vector3(localScaleX, transform.localScale.y,
        transform.localScale.z);
    }
    
    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
