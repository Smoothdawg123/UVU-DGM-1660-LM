using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{   
    [Header("Stats")]
    public float moveSpeed;         //movement speed in units per second 
    public float jumpForce;         //force applied upwards

    [Header("Mouselook")]
    public float lookSensitivity;   // Mouse look sensitivit
    public float maxLookX;          // lowest down we can look
    public float minLookX;          // Highest up we can look
    private float rotX;             // Current x rotation of the camera
    private Camera camera;
    private Rigidbody rb;
    private Weapon weapon;
    public int curHp;
    public int maxHp;
    

    void Awake()
    {
        weapon = GetComponent<Weapon>();

    }

    void Start()
    {
        //Get Components
        camera = Camera.main;
        rb = GetComponent<Rigidbody>();

        // Initialize the UI
        GameUI.instance.UpdateHealthBar(curHp, maxHp);
        GameUI.instance.UpdateScoreText(0);
        GameUI.instance.UpdateAmmoText(weapon.curAmmo, weapon.maxAmmo);
    }

    
    //Applies Damage to the Player
    public void TakeDamage(int damage)
    {
      curHp -= damage;

      if(curHp <= 0)
        Die();

      GameUI.instance.UpdateHealthBar(curHp, maxHp);

    
    }
    // If health reaches 0 than run Die()
    void Die()
    {
      GameManager.instance.LoseGame();
    }
    void Move()
    {

        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;

        // rb.velocity = new Vector3 (x, rb.velocity.y, z); - old code
        Vector3 dir = transform.right * x + transform.forward * z;
        dir.y = rb.velocity.y;
        rb.velocity = dir;
    }
    void CamLook()
    {
        float y = Input.GetAxis("Mouse X") * lookSensitivity;
        rotX += Input.GetAxis("Mouse Y") * lookSensitivity;
        
        rotX = Mathf.Clamp(rotX, minLookX, maxLookX);
        camera.transform.localRotation = Quaternion.Euler(-rotX, 0, 0);
        transform.eulerAngles += Vector3.up * y;
    }

    void FixedUpdate()
    {
        if(Input.GetButtonDown("Jump"))
            Jump();
    }
    void Jump()
    {
        Ray ray = new Ray(transform.position, Vector3.down);

        if(Physics.Raycast(ray, 1.1f))
        {
            rb.AddForce (Vector3.up * jumpForce, ForceMode.Impulse);

        }
    }

    public void GiveHealth(int amountToGive)
    {
        curHp = Mathf.Clamp(curHp + amountToGive, 0, maxHp);
        GameUI.instance.UpdateHealthBar(curHp, maxHp);

    }

    public void GiveAmmo(int amountToGive)
    {
        weapon.curAmmo = Mathf.Clamp(weapon.curAmmo + amountToGive, 0, weapon.maxAmmo);
        GameUI.instance.UpdateAmmoText(weapon.curAmmo, weapon.maxAmmo);
    }
    void Update()
    {
        Move();
        CamLook();
        // Fire Button
        if(Input.GetButton("Fire1"))
        {
            if(weapon.CanShoot())
                weapon.Shoot();
        }

        //Freeze game when game is paused
        if(GameManager.instance.gamePaused == true)
            return;
    }
    
}
