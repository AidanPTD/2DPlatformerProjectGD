using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour {
    public bool HasGems = false;

    // Key or no Key?
    public bool HasYellowKey = false;
    public bool HasGreenKey = false;
    public bool HasRedKey = false;
    public bool HasBlueKey = false;
    public bool CanOpenDoor = false;

    // Other
    private PlayerPowerUps powerUps;
    private Rigidbody2D rb;
    private Player player;
    public Vector2 BounceForce;
    // Use this for initialization
    void Start () {
        powerUps = GetComponent<PlayerPowerUps>();
        player = GetComponent<Player>();
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter2D(Collision2D collider)
    {

        if (collider.gameObject.tag == "Fire")
        {
            Debug.Log("Fire Activated");
            powerUps.Fire = true;
            Destroy(collider.gameObject);
        }
        else if(collider.gameObject.tag == "Coin")
        {
            player.Coins += 1;
            Destroy(collider.gameObject);
        }
        else if(collider.gameObject.tag == "Spring")
        {
            rb.AddForce(BounceForce);
        }
    }
}
