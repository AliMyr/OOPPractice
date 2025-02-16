using UnityEngine;

public class Stamina : MonoBehaviour
{
    [Header("Stamina Settings")]
    public float maxStamina = 100f;
    [Tooltip("—корость регенерации стамины (единиц в секунду)")]
    public float regenRate = 10f;

    [HideInInspector]
    public float currentStamina;

    private void Awake()
    {
        currentStamina = maxStamina;
    }

    private void Update()
    {
        Regenerate();
    }

    private void Regenerate()
    {
        if (currentStamina < maxStamina)
        {
            currentStamina += regenRate * Time.deltaTime;
            currentStamina = Mathf.Min(currentStamina, maxStamina);
        }
    }

    /// <summary>
    /// ѕытаетс€ расходовать указанное количество стамины.
    /// ¬озвращает true, если достаточно стамины, и расходует еЄ, иначе false.
    /// </summary>
    public bool ConsumeStamina(float amount)
    {
        if (currentStamina >= amount)
        {
            currentStamina -= amount;
            return true;
        }
        return false;
    }
}
