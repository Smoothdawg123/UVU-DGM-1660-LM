using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [Header ("Health")]
    public float startingHealth;
    public float currentHealth {get; private set; }
    private Animator anim;
    private bool dead;

    [Header("iFrames")]
    public float iFramesDuration;
    public int numberOfFlashes;
    private SpriteRenderer spriteRend;

    [Header("Components")]
    public Behaviour[] components;
    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
            StartCoroutine(Invulnerability());
        }
        else
        {
            if (!dead)
            {
                anim.SetTrigger("die");
                SceneManager.LoadScene("WinScreen");
            }
        }
        
    }
    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

    private IEnumerator Invulnerability()
    {
        Physics2D.IgnoreLayerCollision(10, 11, true);
        //invulnerability duration
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1,0,0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));

        }
         Physics2D.IgnoreLayerCollision(10, 11, false);

    }

   private void Deactivate()
   {
       gameObject.SetActive(false);
   }
}