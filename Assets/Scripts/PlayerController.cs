using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("Jump")]  
    private Rigidbody2D playerRb;
    [SerializeField] float minJumpForce;
    [SerializeField] float maxJumpForce;
    [SerializeField] float maxHoldTtime;    
    public int remainingJumps;
    [SerializeField] float jumpCooldownTime;
    private float holdTime = 0.0f;
    private bool isHolding = false;
    public bool isOnGround;
    public bool canJump;

    [Header("Gizmo")]
    [SerializeField] private Vector2 detectorBox = new Vector2(1.0f, 0.1f);    
    [SerializeField] private Transform detectorPosition;
    [SerializeField] private LayerMask groundLayer;

    [Header("Audio")]
    [SerializeField] private PlayerSoundController playerSoundController;

    private GameManager gameManager;
    

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        gameManager.jumpsCounter = remainingJumps;

        playerRb = GetComponent<Rigidbody2D>();  
        canJump = true;
    }

    void Update()
    {        
        if (Input.GetMouseButtonDown(1))
        {
            isHolding = true;
            holdTime = 0.0f;
        }        

        if (Input.GetMouseButton(1) && isHolding)
        {
            holdTime += Time.deltaTime;
        }

        if (Input.GetMouseButtonUp(1) && canJump && isOnGround && isHolding && remainingJumps > 0)
        {
            playerSoundController.PlayJumpSound();
            StartCoroutine(Jump());  
            canJump = false;  
            remainingJumps--;
            gameManager.UpdateJumps(remainingJumps);
        }             

        if(remainingJumps < 1)
        {
            StartCoroutine(gameManager.RestarLevel("No Jumps"));
            Debug.Log("Game Over! No Remaining Juimps");
        }   
    }

    void FixedUpdate()
    {
        isOnGround = Physics2D.OverlapBox(detectorPosition.position, detectorBox, 0, groundLayer);           
    }
    
    IEnumerator Jump()
    {   
        if (!canJump) yield break;

        canJump = false;
        isHolding = false;

        float t = Mathf.Clamp01(holdTime / maxHoldTtime);
        float jumpForce = Mathf.Lerp(minJumpForce, maxJumpForce, t); 

        Vector2 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 jumpDirection = (clickPosition - playerRb.position).normalized;

        ResetPhysics(); 
        //playerRb.AddForce(jumpDirection * jumpForce, ForceMode2D.Impulse);
        playerRb.velocity = jumpDirection * jumpForce;

        isOnGround = false;
        yield return new WaitForSeconds(jumpCooldownTime);

        canJump = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Goal"))
        {
            // NextLevel();
            Debug.Log("Next Level");
        }

        if(other.gameObject.CompareTag("Obstacle"))
        {
            canJump = false;
            playerSoundController.PlayDeadSound(gameObject);
            StartCoroutine(gameManager.RestarLevel(other.gameObject.tag));
            Debug.Log("Game Over!");
        }
        
        if(other.gameObject.CompareTag("PowerJump"))
        {
            playerSoundController.PlayReloadSound();
            remainingJumps ++;
            other.gameObject.SetActive(false);  
            Debug.Log("One Jumo Added");
        }
    }

    void ResetPhysics()
    {
        playerRb.velocity = Vector2.zero;
        playerRb.angularVelocity = 0;

    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(detectorPosition.position, detectorBox);
        
    }
}