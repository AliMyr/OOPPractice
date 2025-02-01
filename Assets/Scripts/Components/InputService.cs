using UnityEngine;

public class InputService : MonoBehaviour, IInputService
{
    public Vector3 GetInputDirection()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        return new Vector3(h, 0, v);
    }
}
