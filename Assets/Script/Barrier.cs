using UnityEngine;
using System.Collections;

public class Barrier : MonoBehaviour {

    public int life = 100;
    public int danno = 20;
    public float alphaDamage = 0.2f;

    SpriteRenderer spRend;
    SpriteRenderer spRend1;
    SpriteRenderer spRend2;

    void Start ()
    {
        spRend = transform.GetComponent<SpriteRenderer>();
        spRend1 = transform.parent.transform.GetChild(1).GetComponent<SpriteRenderer>();
        spRend2 = transform.parent.transform.GetChild(2).GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Pareti" && (life - danno) >= danno)
        {
            
            Color col = spRend.color;
            col.a -= alphaDamage; 
            life -= 20;
            spRend.color = col;

            Color col1 = spRend1.color;
            col1.a -= alphaDamage;
            
            spRend1.color = col1;

            Color col2 = spRend2.color;
            col2.a -= alphaDamage;
            
            spRend2.color = col2;

        }
        else if (coll.gameObject.tag == "Pareti" && (life - danno) < danno)
        {
            this.transform.parent.GetComponent<CircleCollider2D>().enabled = true;
            Destroy(this.transform.parent.transform.GetChild(0).gameObject);
            Destroy(this.transform.parent.transform.GetChild(1).gameObject);
            Destroy(this.transform.parent.transform.GetChild(2).gameObject);
        }
    }

}
