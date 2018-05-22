using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itembox : MonoBehaviour {
    public Sprite Active;
    public Sprite inActive;
    public GameObject item;
    private SpriteRenderer renderer;
    private bool active = true;
 
	// Use this for initialization
	void Start () {
        renderer = GetComponentInParent<SpriteRenderer>();
        renderer.sprite = Active;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (active)
        { 
            if (collision.gameObject.tag == "Player")
            {
                renderer.sprite = inActive;
                SpawnItem(new Vector2(transform.position.x, transform.position.y + 2));
                active = false;
            }
        }
    }
    void SpawnItem(Vector2 position)
    {
        Instantiate(item, position, transform.rotation);
    }
    
}
