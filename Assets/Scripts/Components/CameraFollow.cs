using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Ссылка на объект, за которым будет следовать камера (игрок)
    public Transform target;
    // Смещение камеры относительно цели (например, чтобы камера была позади и чуть выше)
    public Vector3 offset = new Vector3(0f, 5f, -10f);
    // Коэффициент сглаживания движения камеры
    public float smoothSpeed = 0.125f;

    // Используем LateUpdate, чтобы камера двигалась после всех обновлений игрока
    void LateUpdate()
    {
        if (target == null)
        {
            //Debug.LogWarning("CameraFollow: target не назначен!");
            return;
        }

        // Вычисляем желаемую позицию камеры
        Vector3 desiredPosition = target.position + offset;
        // Плавно интерполируем между текущей позицией и желаемой позицией
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Если нужно, чтобы камера всегда смотрела на игрока
        transform.LookAt(target);
    }
}
