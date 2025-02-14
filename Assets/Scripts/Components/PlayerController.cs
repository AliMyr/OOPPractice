using UnityEngine;
using Zenject;

public class PlayerController : MonoBehaviour
{
    private IMovable movable;
    private IDamageable damageable;
    private IInputService inputService;

    // —корость поворота в градусах в секунду
    public float rotationSpeed = 720f;

    [Inject]
    public void Construct(IInputService input)
    {
        inputService = input;
    }

    private void Awake()
    {
        movable = GetComponent<IMovable>();
        if (movable == null)
            Debug.LogError("IMovable отсутствует на " + gameObject.name);

        damageable = GetComponent<IDamageable>();
        if (damageable == null)
            Debug.LogError("IDamageable отсутствует на " + gameObject.name);
    }

    private void Update()
    {
        // ѕолучаем направление ввода через DI-сервис
        Vector3 inputDirection = inputService.GetInputDirection();

        if (inputDirection.sqrMagnitude > 0.01f)
        {
            // Ќормализуем направление движени€
            Vector3 moveDir = inputDirection.normalized;

            // ƒвигаем персонажа
            movable.Move(moveDir);

            // ¬ычисл€ем целевой поворот на основе направлени€ движени€
            Quaternion targetRotation = Quaternion.LookRotation(moveDir, Vector3.up);
            // ѕлавно поворачиваем текущую ориентацию в сторону целевого поворота
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        // ѕример: нажали клавишу H дл€ нанесени€ урона (тестовый вызов)
        if (Input.GetKeyDown(KeyCode.H))
        {
            damageable.TakeDamage(10);
        }
    }
}
