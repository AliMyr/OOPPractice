using UnityEngine;
using Zenject;

public class PlayerController : MonoBehaviour
{
    private IMovable movable;
    private IDamageable damageable;
    private IInputService inputService;
    private Animator animator;

    // Скорость поворота в градусах в секунду
    public float rotationSpeed = 720f;

    [Inject]
    public void Construct(IInputService input)
    {
        inputService = input;
    }

    private void Awake()
    {
        movable = GetComponent<IMovable>();

        damageable = GetComponent<IDamageable>();

        animator = GetComponentInChildren<Animator>();

    }

    private void Update()
    {
        // Получаем направление ввода через DI-сервис
        Vector3 inputDirection = inputService.GetInputDirection();
        Vector3 moveDir = inputDirection.normalized;
        if (inputDirection.sqrMagnitude > 0.01f)
        {
            
            movable.Move(moveDir);

            Quaternion targetRotation = Quaternion.LookRotation(moveDir, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        animator.SetFloat("Speed", moveDir.magnitude, 0.1f, Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.H))
        {
            damageable.TakeDamage(10);
        }
    }
}
