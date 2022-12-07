using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    [Header("Enemy")]
    [SerializeField] private int rutine;
    [SerializeField] private float cronometre;
    [SerializeField] private int direction;
    [SerializeField] private Animator anim;
    [SerializeField] private float Speed_walk;
    [SerializeField] private float Speed_run;
    private bool Attacking;
      

    [Header("Seguir enemigo")]
    [SerializeField]private float AlertRange;
    [SerializeField] private LayerMask PlayerLayer;
    private bool Alert;
    private Transform PlayerT;
    private float Distance;

    [Header("Damage")]
    [SerializeField] private int giveDamage;

    [Header("Life Enemy")]
    public int life;
    [SerializeField]private Slider Sliderlife;
    private bool Death = false;
    void Awake()
    {
        anim= GetComponent<Animator>();
        PlayerT = GameObject.FindWithTag("Player").transform;
    }
    void Start()
    {
        
        Sliderlife.maxValue = life;
        Sliderlife.value = Sliderlife.maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        //barra de vida


        //movimiento
        Movementing();
       
    }

    public void ReciveDamage(int Damage)
    {
        life -= Damage;
        Sliderlife.value = life;
        if (life <=0)
        {
            Destroy(gameObject);
        }
    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().ReciveDamage(giveDamage, collision.GetContact(0).normal);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, AlertRange);
    }

    private void Movementing()
    {
        cronometre += 1 * Time.deltaTime;
        if (cronometre >= 4)
        {
            rutine = Random.Range(0, 2);
            cronometre= 0;
        }
        switch (rutine)
        {
            case 0:
                anim.SetBool("Walk",false);
                break;
            case 1:
                direction = Random.Range(0, 2);
                rutine++;
                break;
            case 2:
                switch (direction)
                {
                    case 0:
                        transform.rotation= Quaternion.Euler(0, 0, 0);
                        transform.Translate(Vector3.right * Speed_walk*Time.deltaTime);
                        break;
                    case 1:
                        transform.rotation= Quaternion.Euler(0, 180, 0);
                        transform.Translate(Vector3.right * Speed_walk*Time.deltaTime);
                        break;
                }
                anim.SetBool("Walk",true);
                break;
        }
    }
}
