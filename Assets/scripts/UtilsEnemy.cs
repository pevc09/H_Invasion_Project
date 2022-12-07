using UnityEngine;
using UnityEngine.UI;


public static class UtilsEnemy
{
    public static void MovementEnemy(float i, float l, Vector2 v,Vector2 f, Transform t, SpriteRenderer s)
    {
        v.x = f.x + Mathf.PingPong(Time.time * i, l);

        if (v.x > t.position.x)
        {
            //izquierda
            s.flipX = false;
        }
        else
        {
            //derecha
            s.flipX = true;
        }
        t.position = v;
    }    

    public static void Attack(Transform Control,float Radious,int Attack)
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(Control.position, Radious);
        foreach (Collider2D collision in objects)
        {
            collision.GetComponent<Player>().ReciveDamage(Attack, new Vector2 (10,10));
        }
    }
}
