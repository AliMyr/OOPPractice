using System.Collections;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    [Header("Dash Settings")]
    public float dashSpeed = 20f;
    public float dashDuration = 0.2f;
    public float dashCooldown = 1f;
    public KeyCode dashKey = KeyCode.LeftShift;

    // ��������� ������� ��� �����
    public float dashStaminaCost = 20f;

    private bool canDash = true;
    private Stamina stamina;

    private void Awake()
    {
        stamina = GetComponent<Stamina>();
        if (stamina == null)
            Debug.LogError("PlayerDash: ������� �� ������� �� " + gameObject.name);
    }

    private void Update()
    {
        if (Input.GetKeyDown(dashKey) && canDash)
        {
            // ������� ������� ������� ��� �����
            if (stamina.ConsumeStamina(dashStaminaCost))
                StartCoroutine(Dash());
            else
                Debug.Log("������������ ������� ��� �����!");
        }
    }

    private IEnumerator Dash()
    {
        canDash = false;
        float endTime = Time.time + dashDuration;
        Vector3 dashDirection = transform.forward;

        while (Time.time < endTime)
        {
            transform.position += dashDirection * dashSpeed * Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
}
