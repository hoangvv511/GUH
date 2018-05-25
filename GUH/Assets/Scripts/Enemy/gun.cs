using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour {

    [SerializeField]
    private GameObject bullet;

    private Animator anim;

    public float time = 2f;

    private SpriteRenderer spriteR;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        StartCoroutine(Attack());
        spriteR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(spriteR.sprite.name == "Gun5")
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            StartCoroutine(Attack());
        }
        Debug.Log(spriteR.sprite.name);
    }

    IEnumerator Attack()
    {
        anim.SetBool("Gun", false);
        yield return new WaitForSeconds(time);
        anim.SetBool("Gun", true);
    }
}
