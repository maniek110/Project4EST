using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private float _maxCounter = 2f;
    public float timer = 0f;
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= _maxCounter)
        {
            gameObject.SetActive(false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            //collision.gameObject.GetComponent<AsteroidScript>().Dissable();
        }
        gameObject.SetActive(false);
    }
}
