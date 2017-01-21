using UnityEngine;
using System.Collections;

public class Barrier : MonoBehaviour {

    public int life = 100;
    public int danno = 20;
    public float alphaDamage = 0.2f;

    SpriteRenderer spRend;

    void Start ()
    {
        spRend = transform.GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Pareti" && (life - danno) >= danno)
        {

            
            Color col = spRend.color;
            col.a -= alphaDamage; 
            life -= 20;
            spRend.color = col;

        }
        else
        {
            this.transform.parent.GetComponent<CircleCollider2D>().enabled = true;
            Destroy(this.gameObject);
        }
    }

}
