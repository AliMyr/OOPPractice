using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    private void Start()
    {
        GameStateManager gsm = FindObjectOfType<GameStateManager>();
        if (gsm != null)
        {
            gsm.ChangeState(new PlayingState());
        }
        else
        {
            Debug.LogError("GameStateManager не найден!");
        }
    }
}
