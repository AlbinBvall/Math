using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;

    InputAction shooting;

    [SerializeField] float bulletSpeed = 15;

    
    void Start()
    {
        shooting = InputSystem.actions.FindAction("Attack");
    }

    void Update()
    {
        Attack();
    }

    void Attack()
    {
        if (shooting.IsPressed())
        {
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

            Rigidbody2D projectileRB = projectile.GetComponent<Rigidbody2D>();

            projectileRB.linearVelocityX = bulletSpeed;
        }
    }
}
