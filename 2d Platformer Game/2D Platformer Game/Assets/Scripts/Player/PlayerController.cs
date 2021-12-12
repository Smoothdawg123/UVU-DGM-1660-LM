using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//References I used to help learn and make these sripts.
//Brackeys on Youtube https://www.youtube.com/channel/UCYbK_tjZ2OrIZFBvU6CCMiA
//Coding in flow on Youtube https://www.youtube.com/channel/UC_Fh8kvtkVPkeihBs42jGcA
//Pandemonium Games on Youtbe https://www.youtube.com/channel/UCpkMj5b5kl2_YApDvgUCVQQ

public class PlayerController : MonoBehaviour
{
  public float speed;
  public float jumpPower;
  private Rigidbody2D body;
  private Animator anim;
  private BoxCollider2D boxCollider;
  public LayerMask groundLayer;
  public LayerMask wallLayer;
  private float wallJumpCooldown;
  private float horizontalInput;

  [Header("Sounds")]
    public AudioClip jumpSound;


    
  private void Awake()
   {   //Grab reference for rigidbody and animator from object
       body = GetComponent<Rigidbody2D>();
       anim = GetComponent<Animator>();
      boxCollider = GetComponent<BoxCollider2D>();
   }
 
    void Update()
    {
      horizontalInput = Input.GetAxis("Horizontal");

    // Flip player when moving left or right
      if (horizontalInput > 0.01f)
        transform.localScale = Vector3.one;
      else if (horizontalInput < -0.01f)
        transform.localScale = new Vector3(-1, 1, 1);
    
      //Set animator parameters
      anim.SetBool("Run", horizontalInput != 0);
      anim.SetBool("grounded", isGrounded());
      //Wall Jump Logic

   if (wallJumpCooldown > 0.2f)
    {
       body.velocity = new Vector2(horizontalInput * speed, body.velocity.y); 

       if (onWall() && !isGrounded())
       {
         body.gravityScale = 0;
         body.velocity = Vector2.zero;
       }
       else
        body.gravityScale = 3;

        if(Input.GetKey(KeyCode.Space))
        {
          Jump();
          if(Input.GetKeyDown(KeyCode.Space) && isGrounded())
            SoundManager.instance.PlaySound(jumpSound);
        }
         
     }
    else
      wallJumpCooldown += Time.deltaTime;
    }
    private void Jump()
    {
      if(isGrounded())
      {
        //Animation for jump and jump power
        body.velocity = new Vector2(body.velocity.x, jumpPower);
        anim.SetTrigger("jump");
      }
      else if(onWall() && !isGrounded())
      {
        if(horizontalInput == 0)
        {
         
          body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10, 0);
          transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else
          body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 6);

          wallJumpCooldown = 0;
      }
    }
   private bool isGrounded()
   {
     RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
     return raycastHit.collider != null;
   }
  //Wall Jumping and staying on wall
  private bool onWall()
 {
   RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
    return raycastHit.collider != null;
 }
  public bool canAttack()
  {
    return horizontalInput == 0 && isGrounded() && !onWall();
  }

}
