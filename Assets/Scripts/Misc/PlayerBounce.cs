using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounce : MonoBehaviour {
    public Vector2 springForce;
    private Animator anim;
    public bool PlayerHit = false;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        anim.SetBool("PlayerHit", PlayerHit);
    }

    // Update is called once per frame
    void Update () {
		
	}
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerHit = true;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(springForce);
        }
        PlayerHit = false;
    }
}
