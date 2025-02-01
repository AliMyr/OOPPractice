using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private IMovable movable;
    private IDamageable damageable; // Наш враг тоже может получать урон
    public Transform target;       // Цель (игрок), к которой будем двигаться
    public float attackRange = 1.5f;
    public int attackDamage = 10;
    public float attackCooldown = 1.0f;
    private float attackTimer = 0f;

    private void Awake()
    {
        movable = GetComponent<IMovable>();
        if (movable == null)
        {
            Debug.LogError("Enemy " + gameObject.name + " не имеет компонента, реализующего IMovable!");
        }

        damageable = GetComponent<IDamageable>();
        if (damageable == null)
        {
            Debug.LogError("Enemy " + gameObject.name + " не имеет компонента, реализующего IDamageable!");
        }
    }

    private void Update()
    {
        // Если цель не задана, пробуем найти игрока по тегу "Player"
        if (target == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
            {
                target = playerObj.transform;
            }
            else
            {
                return; // Ничего не делаем, если игрока нет
            }
        }

        // Двигаемся в сторону игрока
        Vector3 direction = (target.position - transform.position).normalized;
        movable.Move(direction);

        // Пытаемся атаковать, если находимся в пределах атаки
        attackTimer += Time.deltaTime;
        if (Vector3.Distance(transform.position, target.position) <= attackRange && attackTimer >= attackCooldown)
        {
            // Получаем интерфейс у игрока для нанесения урона
            IDamageable targetDamageable = target.GetComponent<IDamageable>();
            if (targetDamageable != null)
            {
                targetDamageable.TakeDamage(attackDamage);
                attackTimer = 0f;
            }
        }
    }
}
