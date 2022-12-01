using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private float _movementSpeed = 5;


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * _movementSpeed);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "EndLine")
        {
            gameObject.SetActive(false);
        }
    }
    public void DealDamage(int _damage)
    {
        _health -= _damage;
        if (_health <= 0)
        {
            gameObject.SetActive(false);
        }
    }


}
