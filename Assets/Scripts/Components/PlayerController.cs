using UnityEngine;
using Zenject;

public class PlayerController : MonoBehaviour
{
    private IMovable movable;
    private IDamageable damageable;
    private IInputService inputService;

    // �������� �������� � �������� � �������
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
            // ����������� ����������� ��������
            Vector3 moveDir = inputDirection.normalized;

            // ������� ���������
            movable.Move(moveDir);

            // ��������� ������� ������� �� ������ ����������� ��������
            Quaternion targetRotation = Quaternion.LookRotation(moveDir, Vector3.up);
            // ������ ������������ ������� ���������� � ������� �������� ��������
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        // ������: ������ ������� H ��� ��������� ����� (�������� �����)
        if (Input.GetKeyDown(KeyCode.H))
        {
            damageable.TakeDamage(10);
        }
    }
}
