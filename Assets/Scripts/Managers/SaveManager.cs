using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private string filePath;

    private void Awake()
    {
        // ��������� ���� ��� ���������� �����
        filePath = Path.Combine(Application.persistentDataPath, "saveData.json");
        Debug.Log("Save file path: " + filePath);
    }

    // ����� ��� ���������� ������ ����
    public void SaveGame(GameData data)
    {
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(filePath, json);
        Debug.Log("���� ���������: " + json);
    }

    // ����� ��� �������� ������ ����
    public GameData LoadGame()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            GameData data = JsonUtility.FromJson<GameData>(json);
            Debug.Log("���� ���������: " + json);
            return data;
        }
        else
        {
            Debug.LogWarning("���� ���������� �� ������, ���������� ����� ������");
            return new GameData();
        }
    }
}
