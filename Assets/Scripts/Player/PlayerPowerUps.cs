using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerUps : MonoBehaviour
{
    private ParticleSystem Emitter;
    private PlayerCollisions collisions;
    private Player playerController;
    private Animator powerAnim;
    private Animation powerAnimClip;
    public GameObject ShieldSprite;
    public AnimationClip FireShield;
    public AnimationClip NormalShield;
    public AnimationClip WaterShield;

    // Main PowerUps
    public bool Fire = false;
    public bool Super = false;
    public bool Speed = false;
    public bool SuperJump = false;
    public bool Invincibility = false;
    float origSpeed;
    //Fire Emitter Settings:

    // Use this for initialization
    void Start()
    {
        collisions = GetComponent<PlayerCollisions>();
        Emitter = ShieldSprite.GetComponent<ParticleSystem>();
        playerController = GetComponent<Player>();
        powerAnim = ShieldSprite.GetComponent<Animator>();
        powerAnimClip = ShieldSprite.GetComponent<Animation>();
        powerAnim.SetBool("Fire", Fire);
        powerAnim.SetBool("Super", Super);
        powerAnim.SetBool("Speed", Speed);
        powerAnim.SetBool("SuperJump", SuperJump);
        origSpeed = playerController.moveSpeed;
        InvokeRepeating("SpawnTrailPart", 1, 0.1f); // replace 0.2f with needed repeatRate
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) && !Speed)
            Speed = true;
        else if (Input.GetKeyDown(KeyCode.S) && Speed)
            Speed = false;


        if (!Super)
        {
            if (Fire)
            {
                powerAnimClip.clip = FireShield;
            }
            else if(Speed)
            {
                playerController.moveSpeed = 12;
            }
            else
            {
                powerAnimClip.clip = null;
                playerController.moveSpeed = origSpeed;
            }
        }

    }
    void SpawnTrailPart()
    {
        if (Speed)
        {
            GameObject trailPart = new GameObject();
            trailPart.name = "AfterImage";
            SpriteRenderer trailPartRenderer = trailPart.AddComponent<SpriteRenderer>();
            trailPartRenderer.flipX = true;
            trailPartRenderer.sprite = GetComponent<SpriteRenderer>().sprite;
            trailPart.transform.position = transform.position;
            trailPart.transform.localScale = transform.localScale; // We forgot about this line!!!

            StartCoroutine(FadeTrailPart(trailPartRenderer));
            Destroy(trailPart, 0.5f); // replace 0.5f with needed lifeTime

        }
    }

    IEnumerator FadeTrailPart(SpriteRenderer trailPartRenderer)
    {
        if (Speed)
        {
            Color color = trailPartRenderer.color;
            color.a -= 0.1f; // replace 0.5f with needed alpha decrement
            trailPartRenderer.color = color;

            yield return new WaitForEndOfFrame();
        }
    }
}
