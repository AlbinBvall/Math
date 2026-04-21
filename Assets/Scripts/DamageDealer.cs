using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int baseDamage = 10;
    [SerializeField] int damagePerTick = 1;
    [SerializeField] int healthLostPerTick = 1;
    [SerializeField] float attackDuratrion = 1f;
    [SerializeField] float timeBetweenTick = 1f;
    [SerializeField] float initialCharge = 0.75f;
   
    int damage = 10;
    bool attacking = false;
    bool hasCharegedAttack = false;


    GameObject player;
    Health healthScript;
    BoxCollider2D boxCollider;
    InputAction attack;
    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        player = GameObject.Find("Player");
        healthScript = player.GetComponent<Health>();
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
        attack = InputSystem.actions.FindAction("Attack");
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        initialCharge = Mathf.Clamp(initialCharge, 0.0001f, float.MaxValue);
        timeBetweenTick = Mathf.Clamp(timeBetweenTick, 0.0001f, float.MaxValue);
    }
    private void Start()
    {
        boxCollider.enabled = false;
        spriteRenderer.enabled = false;
        damage = baseDamage;
        StartCoroutine(StopAttacking());
        StartCoroutine(TicksBeforeCalcDamage());
    }

    private void FixedUpdate()
    {
        ResetDamage();
        Debug.Log("Health: " + healthScript.health);
        Debug.Log("Damage: " + damage);
    }
    public int GetDamage()
    {
        return damage;
    }

    private IEnumerator TicksBeforeCalcDamage()
    {
        if (!hasCharegedAttack && attack.IsPressed() && healthScript.health > 1 && !boxCollider.enabled)
        {
            attacking = true;
            yield return new WaitForSeconds(initialCharge);
            Debug.Log("attack ready");
            hasCharegedAttack = true;
        }
        else if (hasCharegedAttack)
        {
            yield return new WaitForSeconds(timeBetweenTick);
            Debug.Log("Next Tick");
        }
        else
        {
            yield return new WaitForFixedUpdate();
        }
            CalculateDamage();
        StartCoroutine(TicksBeforeCalcDamage());
    }
    
   

   private void CalculateDamage()
    {
       if (attack.IsPressed() && healthScript.health > 1 && !boxCollider.enabled)
        {
            healthScript.health -= healthLostPerTick;
            damage += damagePerTick;
            attacking = true;
        }
    }

    private IEnumerator StopAttacking()
    {
        yield return new WaitForFixedUpdate();
        if (attacking && !attack.IsPressed())
        {
            boxCollider.enabled = true;
            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(attackDuratrion);
            Debug.Log("Attack Stopped");
            attacking = false;
            hasCharegedAttack = false;
        }
        StartCoroutine(StopAttacking());
    }

    private void ResetDamage()
    {
        if (!attacking)
        {
            boxCollider.enabled = false;
            spriteRenderer.enabled = false;
            damage = baseDamage;
            StopAllCoroutines();
            StartCoroutine(TicksBeforeCalcDamage());
            StartCoroutine(StopAttacking());
        }
    }
}
