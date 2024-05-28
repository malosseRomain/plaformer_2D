

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D playerRB; // Propri�t� qui tiendra en r�f�ence le rigid body de notre player
    public Animator playerAnim; // Propriete qui tiendra la reference a notre composant animator
    public CapsuleCollider2D playerCollider;
    public LayerMask groundLayer; 
    public Transform groundCheck;
    public float HorizontalSpeed;
    public float VerticalSpeed;
    public float jumpPower; 
    [HideInInspector]
    public bool Climbing;
    public static PlayerController instance;
    
    public int NbSautSup;

    private int SautUtilise;
    private Vector3 velocity = Vector3.zero;
    private SpriteRenderer playerRenderer;
    private bool Grounded;
    private bool Jumping;
    private float groundCheckRadius = 0.2f; 
    private float VerticalMovement;
    private float HorizontalMovement;


    private void Start()
    {
        playerRenderer = GetComponent<SpriteRenderer>();
    }
    
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de PlayerMovement dans la scène");
            return;
        }

        instance = this;
    }


    void Update()
    {

        if (!Climbing)
        {
            //Mouvement horizontal
            HorizontalMovement = Input.GetAxis("Horizontal") * HorizontalSpeed * Time.fixedDeltaTime;
            Vector3 targetVelocity = new Vector2(HorizontalMovement, playerRB.velocity.y);
            playerRB.velocity = Vector3.SmoothDamp(playerRB.velocity, targetVelocity, ref velocity, .05f);

            //Mouvement Vertical
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (Grounded)
                {   
                    playerRB.velocity = new Vector2(playerRB.velocity.x, 0f); // On defini la velocite y a 0 pour etre sur d'avoir la m�e hauteur quelque soit le contexte
                    playerRB.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse); 
                    Grounded = false; 
                    SautUtilise = 1;
                }
                else if (SautUtilise < NbSautSup)
                {
                    playerRB.velocity = new Vector2(playerRB.velocity.x, 0f);
                    playerRB.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse); 
                    SautUtilise += 1;
                }
            }
            Grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

            //On remet le compteur de saut à zéro
            if (Grounded)
            {
                SautUtilise = 0;
            }
        }
        else { //Mouvement Echelle
            VerticalMovement = Input.GetAxis("Vertical") * VerticalSpeed * Time.fixedDeltaTime;
            Vector3 targetVelocity = new Vector2(0, VerticalMovement);
            playerRB.velocity = Vector3.SmoothDamp(playerRB.velocity, targetVelocity, ref velocity, .05f);
        }
 

        Flip(playerRB.velocity.x);

        float characterVelocity = Mathf.Abs(playerRB.velocity.x);
        playerAnim.SetFloat("Speed", characterVelocity);
        playerAnim.SetBool("isClimbing", Climbing);

    }

    void Flip(float _velocity)
    {
        if (_velocity > 0.1f)
        {
            playerRenderer.flipX = false;
        }else if(_velocity < -0.1f)
        {
            playerRenderer.flipX = true;
        }
    }


    public float GetAnimationDuration(string animationName)
    {
        float animTemp = 0.993f;
        AnimationClip[] clips = playerAnim.runtimeAnimatorController.animationClips;

        foreach (AnimationClip clip in clips)
        {
            if (clip.name == animationName)
            {
                float animationDuration = clip.length;
                return animationDuration;
            }
        }
        Debug.Log("L'animation '" + animationName + "' n'a pas été trouvée.");
        return animTemp;
    }
}