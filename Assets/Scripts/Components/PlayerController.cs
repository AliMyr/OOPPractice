using UnityEngine;
using Zenject;

public class PlayerController : MonoBehaviour
{
    private IMovable movable;
    private IDamageable damageable;
    private IInputService inputService;

    [Inject]
    public void Construct(IInputService input)
    {
        inputService = input;
    }

    private void Awake()
    {
        movable = GetComponent<IMovable>();
        if (movable == null)
            Debug.LogError("IMovable ����������� �� " + gameObject.name);

        damageable = GetComponent<IDamageable>();
        if (damageable == null)
            Debug.LogError("IDamageable ����������� �� " + gameObject.name);
    }

    private void Update()
    {
        // �������� ����������� ����� ����� DI-������
        Vector3 inputDirection = inputService.GetInputDirection();
        if (inputDirection.sqrMagnitude > 0.01f)
        {
            movable.Move(inputDirection.normalized);
        }

        // ������: ������ ������� ��� ��������� ����� (��� �����)
        if (Input.GetKeyDown(KeyCode.H))
        {
            damageable.TakeDamage(10);
        }
    }
}
