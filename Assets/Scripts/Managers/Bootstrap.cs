using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    private void Start()
    {
        // �����������, � ������ ���� PlayerProgression
        PlayerProgression progression = GetComponent<PlayerProgression>();
        AbilityUpgradeManager upgradeManager = FindObjectOfType<AbilityUpgradeManager>();
        if (upgradeManager != null && progression != null)
        {
            upgradeManager.Initialize(progression);
        }

        GameStateManager gsm = FindObjectOfType<GameStateManager>();
        if (gsm != null)
        {
            gsm.ChangeState(new PlayingState());
        }
        else
        {
            Debug.LogError("GameStateManager �� ������!");
        }
    }
}
