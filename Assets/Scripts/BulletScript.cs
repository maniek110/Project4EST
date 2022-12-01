using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private float _maxCounter = 2f;
    public float ExplosionRange;
    
    private float Timer = 0f;

    void Update()
    {
        Timer += Time.deltaTime;
        if (Timer >= _maxCounter)
        {
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag == "Enemy");
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyScript>().DealDamage(1);
        }
        gameObject.SetActive(false);
    }
    public void Explode()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, ExplosionRange);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.tag == "Enemy")
            {
                hitCollider.gameObject.GetComponent<EnemyScript>().DealDamage(1);
            }
        }
        gameObject.SetActive(false);

    }
}
