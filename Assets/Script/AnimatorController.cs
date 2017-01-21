using UnityEngine;
using System.Collections;

public class AnimatorController : MonoBehaviour
{
    private Animator anim;
    public GameObject animSbatti, animHappy, animSurprised;

    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("isSurprised", true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(CollisionPlayerCO());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(CollisionPlayerCO());
    }
    
    public IEnumerator CollisionPlayerCO()
    {
        animHappy.SetActive(false);
        animSbatti.SetActive(true);
        anim.SetBool("isTouched", true);


        yield return new WaitForSeconds(1f);

        animSbatti.SetActive(false);
        anim.SetBool("isTouched", false);
        animHappy.SetActive(true);
    }
}
