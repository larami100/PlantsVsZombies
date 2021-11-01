using UnityEngine;

public class GameManager : MonoBehaviour{

    [SerializeField]
    string levelsFile = "levels.json"; // File where the cards in deck and position and kind of Zombies of each level are assigned

    int level;

    // Singleton pattern to ensure that only one instance of GameManager will be stored in memory
    private static readonly GameManager instance = new GameManager();
    static GameManager() { }
    private GameManager() { }
    public static GameManager Instance{
        get{
            return instance;
        }
    }

    // Set level number and load data for that level
    void Awake() {
        level = 1;
        DataManager.Instance.LoadLevelData(level, levelsFile);
    }
}
