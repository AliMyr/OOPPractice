using UnityEngine;

public interface IInputService
{
    // Возвращает вектор направления ввода (например, от клавиатуры)
    Vector3 GetInputDirection();
}
