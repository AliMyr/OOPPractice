using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private IMovable movable;
    private IDamageable damageable;

    private void Awake()
    {
        // Получаем компоненты через интерфейсы, что соответствует принципу DIP
        movable = GetComponent<IMovable>();
        if (movable == null)
        {
            Debug.LogError("Компонент, реализующий IMovable, отсутствует на " + gameObject.name);
        }

        damageable = GetComponent<IDamageable>();
        if (damageable == null)
        {
            Debug.LogError("Компонент, реализующий IDamageable, отсутствует на " + gameObject.name);
        }
    }

    private void Update()
    {
        // Обработка ввода для движения
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 input = new Vector3(h, 0, v);

        if (input.sqrMagnitude > 0.01f)
        {
            movable.Move(input.normalized);
        }

        // Для демонстрации: нажми клавишу H, чтобы нанести игроку 10 урона
        if (Input.GetKeyDown(KeyCode.H))
        {
            damageable.TakeDamage(10);
        }
    }
}
