using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private IMovable movable;
    private IDamageable damageable;

    private void Awake()
    {
        // �������� ���������� ����� ����������, ��� ������������� �������� DIP
        movable = GetComponent<IMovable>();
        if (movable == null)
        {
            Debug.LogError("���������, ����������� IMovable, ����������� �� " + gameObject.name);
        }

        damageable = GetComponent<IDamageable>();
        if (damageable == null)
        {
            Debug.LogError("���������, ����������� IDamageable, ����������� �� " + gameObject.name);
        }
    }

    private void Update()
    {
        // ��������� ����� ��� ��������
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 input = new Vector3(h, 0, v);

        if (input.sqrMagnitude > 0.01f)
        {
            movable.Move(input.normalized);
        }

        // ��� ������������: ����� ������� H, ����� ������� ������ 10 �����
        if (Input.GetKeyDown(KeyCode.H))
        {
            damageable.TakeDamage(10);
        }
    }
}
