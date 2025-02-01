using UnityEngine;

public class Movement : MonoBehaviour, IMovable
{
    public float Speed = 5f;

    public void Move(Vector3 direction)
    {
        // Перемещение с учётом времени для плавности
        transform.Translate(direction * Speed * Time.deltaTime, Space.World);
    }
}
