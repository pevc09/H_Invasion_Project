using UnityEditor.U2D.Path.GUIFramework;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class OverH : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float _speed;
    [Header("Life")]
    [SerializeField] private Slider OSliderL;
    private int ChangeFormLife = 2;
    [SerializeField] private int LifeFirstForm = 200;
    [SerializeField] private int LifeSecondForm = 300;

    [Header("MecanicaBoss")]
    private Animator anim;
    [HideInInspector]public Rigidbody2D rb;
    private Transform playerT;
    private bool LookRight = true;

    [Header("Attack First Form")]
    //[SerializeField]private Transform controlAtack;
    [SerializeField]private float RadiousAttack;
    [SerializeField] private float shootCooldown;
    [SerializeField] private float Break_Distance;
    [SerializeField] private float Back_Distance;


    /*[SerializeField] private int FirstAttack = 9;
    [SerializeField] private GameObject Bullet;
    [SerializeField] private Transform LookOut;*/


    [Header("Attack Second Form")]
    [SerializeField] private int SecondAttack = 13;
    [SerializeField] private int EspecialAttack = 23;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerT = GameObject.FindGameObjectWithTag("Player").transform;
        anim= GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        OSliderL.maxValue = LifeFirstForm;
        OSliderL.value = OSliderL.maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        //float Distance
         //RadiousAttack = Vector2.Distance(transform.position,playerT.position);
        //anim.SetFloat("DistancePlayer", RadiousAttack);
        Attack();
        LookPlayer();
    }

    public void ReciveDamage(int Damage)
    {
        if (ChangeFormLife == 2)
        {
            LifeFirstForm -= Damage;
            OSliderL.value = LifeFirstForm;
            if (LifeFirstForm <= 0)
            {
                ChangeFormLife -= 1;
                OSliderL.maxValue = LifeSecondForm;
            }
        }else if (ChangeFormLife == 1)
        {
            LifeSecondForm -= Damage;
            OSliderL.value = LifeSecondForm;
            if (LifeSecondForm <= 0)
            {
                Destroy(gameObject);
                OSliderL.gameObject.SetActive(false);
            }
        }

    }

    public void LookPlayer()
    {
        if ((playerT.position.x > transform.position.x && !LookRight)||(playerT.position.x< transform.position.x && LookRight))
        {
            LookRight = !LookRight;
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180,0);
        }
    }

    private void Attack()
    {
        shootCooldown += Time.deltaTime;
        if (Vector2.Distance(transform.position,playerT.position)> Break_Distance)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerT.position, _speed * Time.deltaTime);
        }
        if (Vector2.Distance(transform.position,playerT.position)< Back_Distance)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerT.position, -_speed * Time.deltaTime);
        }
         if (Vector2.Distance(transform.position,playerT.position)< Break_Distance&&Vector2.Distance(transform.position,playerT.position)> Back_Distance)
         {
            transform.position = transform.position;
         }

         /*if (ChangeFormLife == 2)
         {
             Collider2D[] objects = Physics2D.OverlapCircleAll(LookOut.position, RadiousAttack);
             foreach (Collider2D collision in objects)
             {
                 Instantiate(Bullet, LookOut.position, LookOut.rotation);
                 /*if (shootCooldown == 2)
                 {
                     Instantiate(Bullet, LookOut.position, LookOut.rotation);
                     shootCooldown = 0;
                     //collision.GetComponent<Player>().ReciveDamage(FirstAttack, new Vector2(10, 10));
                 }

             }
         }
         else if (ChangeFormLife == 1)
         {
             UtilsEnemy.Attack(LookOut, RadiousAttack, SecondAttack);
         }*/
        /*
        if (Vector2.Distance(transform.position, playerT.position) < RadiousAttack)
         {
             if (ChangeFormLife == 2)
             {
                 if (shootCooldown >= 2)
                 {
                     Instantiate(Bullet, LookOut.position, LookOut.rotation);
                     shootCooldown= 0;
                 }                
             }
         }*/

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, RadiousAttack);
    }
}
