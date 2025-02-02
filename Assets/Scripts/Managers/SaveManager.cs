using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private string filePath;

    private void Awake()
    {
        // Формируем путь для сохранения файла
        filePath = Path.Combine(Application.persistentDataPath, "saveData.json");
        Debug.Log("Save file path: " + filePath);
    }

    // Метод для сохранения данных игры
    public void SaveGame(GameData data)
    {
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(filePath, json);
        Debug.Log("Игра сохранена: " + json);
    }

    // Метод для загрузки данных игры
    public GameData LoadGame()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            GameData data = JsonUtility.FromJson<GameData>(json);
            Debug.Log("Игра загружена: " + json);
            return data;
        }
        else
        {
            Debug.LogWarning("Файл сохранения не найден, возвращаем новые данные");
            return new GameData();
        }
    }
}
