using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using System.IO;

// Normal C# class to load data from file and store it in memory.
public sealed class DataManager
{
    public List<Plant> plantsToUse { get; private set; } // List of the plants in the deck
    public List<ZombieSpawnData> zombiesSpawnData { get; private set; } // List of the zombies spawned in the level

    // Singleton pattern to ensure that only one instance of DataManager will be stored in memory
    private static readonly DataManager instance = new DataManager();
    static DataManager(){}
    private DataManager(){}
    public static DataManager Instance{
        get{
            return instance;
        }
    }

    // Read and store in memory the json file which has the information of the zombies spawned each level (time, position and kind)
    // and the cards that are going to be displayed on the deck
    public void LoadLevelData(int level, string levelsFile){
        plantsToUse = new List<Plant>();
        zombiesSpawnData = new List<ZombieSpawnData>();
        // json data is stored in Assets/Resources directory
        string filePath = Path.Combine(Application.dataPath + "/Resources/", levelsFile);
        string jsonString = File.ReadAllText(filePath);
        JSONNode data = JSON.Parse(jsonString);
        // Information of the level is in the record Level_ + number of the level
        JSONNode levelRecord = data["Level_" + level];
        foreach (JSONNode record in levelRecord){
            foreach (JSONNode zombieSpawner in record["ZombieSpawner"]){
                ZombieSpawnData zombieSpawnData = new ZombieSpawnData(zombieSpawner["zombie"].Value, zombieSpawner["time"].AsInt, zombieSpawner["position"].AsInt);
                zombiesSpawnData.Add(zombieSpawnData);
            }
            foreach (JSONNode plantsInDeck in record["PlantsInDeck"]){
                GameObject plantGO = Resources.Load("Prefabs/" + plantsInDeck["plant"].Value) as GameObject;
                plantsToUse.Add(plantGO.GetComponent<Plant>());
            }
        }
    }
}
