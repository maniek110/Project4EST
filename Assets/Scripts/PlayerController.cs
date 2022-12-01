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

    private int currentHealth=0;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = InitHealth;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.right * Time.deltaTime * Input.GetAxisRaw("Horizontal") * PlayerSpeed);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Strza³");
            GameObject bullet = GameObject.Instantiate(BulletPrefab);
            bullet.transform.position = ShootPos.position;
            bullet.GetComponent<Rigidbody>().velocity = ShootPos.forward * Time.deltaTime * BulletSpeed;
        }
    }
}
