using UnityEngine;

public class Movement : MonoBehaviour, IMovable
{
    public float Speed = 5f;

    public void Move(Vector3 direction)
    {
        // ����������� � ������ ������� ��� ���������
        transform.Translate(direction * Speed * Time.deltaTime, Space.World);
    }
}
