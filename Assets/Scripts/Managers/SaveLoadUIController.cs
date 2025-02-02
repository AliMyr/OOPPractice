using UnityEngine;
using UnityEngine.UI;

public class SaveLoadUIController : MonoBehaviour
{
    public SaveManager saveManager;
    public Text highScoreText;

    // Пример: кнопка вызывает этот метод для сохранения игры
    public void OnSaveButtonClicked()
    {
        // Здесь можно собрать данные, например, highScore и playerLevel
        GameData data = new GameData();
        data.highScore = 12345; // Это значение нужно брать из игровой логики
        data.playerLevel = 5;   // Тоже из логики игры
        saveManager.SaveGame(data);
    }

    // Пример: кнопка вызывает этот метод для загрузки игры
    public void OnLoadButtonClicked()
    {
        GameData data = saveManager.LoadGame();
        if (highScoreText != null)
        {
            highScoreText.text = "High Score: " + data.highScore;
        }
    }
}
