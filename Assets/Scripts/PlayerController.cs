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
    [SerializeField] float remainingJumps;
    [SerializeField] float jumpCooldownTime;
    private float holdTime = 0.0f;
    private bool isHolding = false;
    private bool isOnGround;
    private bool canJump;

    [Header("Gizmo")]
    [SerializeField] private float detectorRadius;    
    [SerializeField] private Transform detectorCenter;
    [SerializeField] private LayerMask detectorLayer;
    

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();  
        canJump = true;
    }

    void Update()
    {        
        if (Input.GetMouseButtonDown(0))
        {
            isHolding = true;
            holdTime = 0.0f;
        }        

        if (Input.GetMouseButton(0) && isHolding)
        {
            holdTime += Time.deltaTime;
            Debug.Log("Time Pressing Button: " + holdTime);
        }

        if (Input.GetMouseButtonUp(0) && canJump && isOnGround && isHolding && remainingJumps > 0)
        {
            StartCoroutine(Jump());  
            canJump = false;   
            remainingJumps --;
            Debug.Log("Remaining Jumps: " + remainingJumps);
        }
    }

    void FixedUpdate()
    {
        isOnGround = Physics2D.OverlapCircle(detectorCenter.transform.position, detectorRadius, detectorLayer);    
    }
    
    IEnumerator Jump()
    {   
        if (!canJump) yield break;

        canJump = false;
        isHolding = false;

        float t = Mathf.Clamp01(holdTime / maxHoldTtime);
        float jumpForce = Mathf.Lerp(minJumpForce, maxJumpForce, t); 
        
        Debug.Log("Jumo force: " + jumpForce);      

        Vector2  clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);        
        //Vector2 jumpDirection = (clickPosition - (Vector2)transform.position).normalized;
        Vector2 jumpDirection = (clickPosition - playerRb.position).normalized;

        playerRb.velocity = Vector2.zero; 
        playerRb.AddForce(jumpDirection * jumpForce, ForceMode2D.Impulse);

        isOnGround = false;
        yield return new WaitForSeconds(jumpCooldownTime);

        canJump = true;
    }
    private void OnDrawGizmos() {
        Gizmos.color = Color.yellow;    
        Gizmos.DrawWireSphere(detectorCenter.transform.position, detectorRadius);
    }
}