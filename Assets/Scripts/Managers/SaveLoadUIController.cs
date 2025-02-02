using UnityEngine;
using UnityEngine.UI;

public class SaveLoadUIController : MonoBehaviour
{
    public SaveManager saveManager;
    public Text highScoreText;

    // ������: ������ �������� ���� ����� ��� ���������� ����
    public void OnSaveButtonClicked()
    {
        // ����� ����� ������� ������, ��������, highScore � playerLevel
        GameData data = new GameData();
        data.highScore = 12345; // ��� �������� ����� ����� �� ������� ������
        data.playerLevel = 5;   // ���� �� ������ ����
        saveManager.SaveGame(data);
    }

    // ������: ������ �������� ���� ����� ��� �������� ����
    public void OnLoadButtonClicked()
    {
        GameData data = saveManager.LoadGame();
        if (highScoreText != null)
        {
            highScoreText.text = "High Score: " + data.highScore;
        }
    }
}
