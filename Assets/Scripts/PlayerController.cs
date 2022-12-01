using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float PlayerSpeed = 5f;
    public int InitHealth = 3;
    public Transform ShootPos;
    public GameObject BulletPrefab;
    public float BulletSpeed = 15f;
    public float SpecialBulletDelay = 5f;

    [SerializeField] private int level=1;
    private int currentHealth = 0;
    private float specialBulletTimer = 0f;

    private Action explodeAction;
    

    private List<GameObject> bulletList=new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = InitHealth;
    }

    // Update is called once per frame
    void Update()
    {
        specialBulletTimer += Time.deltaTime;
        transform.Translate(transform.right * Time.deltaTime * Input.GetAxisRaw("Horizontal") * PlayerSpeed);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Strza³");
            GameObject bullet = GetBullet();
            bullet.transform.position = ShootPos.position;
            bullet.GetComponent<Rigidbody>().velocity = Vector3.zero;
            bullet.GetComponent<Rigidbody>().AddForce(ShootPos.forward * BulletSpeed,ForceMode.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            if (specialBulletTimer >= SpecialBulletDelay)
            {
                specialBulletTimer = 0f;
                GameObject bullet = GameObject.Instantiate(BulletPrefab);
                bullet.transform.position = ShootPos.position;
                bullet.GetComponent<Rigidbody>().velocity = ShootPos.forward * Time.deltaTime * BulletSpeed;
                explodeAction += bullet.GetComponent<BulletScript>().Explode;
            }
            else
            {
                explodeAction.Invoke();
            }

        }

    }

    private GameObject GetBullet()
    {
        if (bulletList.Count == 0)
        {
            GameObject bullet = GameObject.Instantiate(BulletPrefab);
            bulletList.Add(bullet);
            return bullet;
        }
        else
        {
            GameObject bullet = null;
            foreach (GameObject gameObject in bulletList)
            {
                if (gameObject.active == false)
                {
                    bullet = gameObject;
                }
            }
            if (bullet != null)
            {
                bullet.SetActive(true);
                return bullet;
            }

            bullet = GameObject.Instantiate(BulletPrefab);
            bulletList.Add(bullet);
            return bullet;
        }
    }
    public void DealDamage(int _damage)
    {
        currentHealth -= _damage;
    }


}
