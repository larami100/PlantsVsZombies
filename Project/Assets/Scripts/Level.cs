using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour {
    [SerializeField] // Class to store UI elements
    LevelUI levelUI;

    [SerializeField] // Positions where the zombies are going to be spawned at the level
    GameObject[] zombieSpawnerPositions;

    bool win, lose; // Variables to control if the player wins or loses
    int plantToUse; // Index of the card selected in the deck
    int suns; // Total of suns available to use in the level
    List<GameObject> zombiesInGame; // List of all the zombies generated in the level

    public void Start(){
        win = false;
        lose = false;
        zombiesInGame = new List<GameObject>();
        plantToUse = 0;
        suns = 250;
        CreateDeck();
        UpdateTotalSuns(0);
        Zombie.SetTotalZombies(DataManager.Instance.zombiesSpawnData.Count);
        StartCoroutine(CreateZombies());
    }

    // Spawn the Zombies based on the information in json file. 
    IEnumerator CreateZombies(){
        foreach (ZombieSpawnData zombie in DataManager.Instance.zombiesSpawnData){
            GameObject zombieGO = Resources.Load("Prefabs/" + zombie.zombie) as GameObject;
            Vector3 zombiePosition = zombieSpawnerPositions[zombie.position].transform.position;
            yield return new WaitForSeconds(zombie.time);
            if (!win && !lose){
                if (zombie.zombie == "BucketHeadZombie")
                    zombiePosition.y += 0.5f;
                GameObject zombieInGame = Instantiate(zombieGO, zombiePosition, zombieGO.transform.rotation);
                zombiesInGame.Add(zombieInGame);
            }
        }
    }

    public void SetWin(){
        levelUI.SetWinLoseText("You Win");
        win = true;
    }

    public void SetLose(){
        levelUI.SetWinLoseText("You Lose");
        DestroyAllZombies();
        lose = true;
    }

    // Destroy all the Zombies if the user loses the game
    private void DestroyAllZombies(){
        foreach(GameObject zombieInGame in zombiesInGame){
            if(zombieInGame != null)
                Destroy(zombieInGame);
        }
    }

    // Spawn a plant in the gameboard based on the mouse selection in the card deck
    public void CreatePlant(int plant, Transform t){
        // Only spawn plants if the user has the enough suns to buy them
        if (DataManager.Instance.plantsToUse[plant].sunPrice > suns) return;
        if (t.childCount != 0) return; // Only spawn a plant if that position in the gameboard does not have one before.
        // Create the Plant in the gameboard
        GameObject g = Instantiate(DataManager.Instance.plantsToUse[plantToUse].gameObject, t.position, gameObject.transform.rotation) as GameObject;
        g.transform.SetParent(t);
        // Decrease total of suns by the cost of the plant spawned.
        UpdateTotalSuns(-DataManager.Instance.plantsToUse[plant].sunPrice);
    }

    // Add Plant cards to the deck
    public void CreateDeck(){
        for (int i = 0; i < DataManager.Instance.plantsToUse.Count; i++){
            // Get card prefab and set sprite, position and button functionality
            GameObject card = Instantiate(levelUI.GetCardPrefab()) as GameObject;
            card.transform.SetParent(levelUI.GetDeck().transform);
            card.transform.position = Vector3.zero;
            card.transform.localScale = Vector3.one;

            Image image = card.GetComponent<Image>();
            image.sprite = DataManager.Instance.plantsToUse[i].sprite;

            Button bot = card.GetComponent<Button>();
            bot.onClick.RemoveAllListeners();
            int tempI = i;
            bot.onClick.AddListener(() => { plantToUse = tempI; });
        }
    }

    // Update total sun text in the UI
    public void UpdateTotalSuns(int sunsAdded){
        suns += sunsAdded;
        levelUI.SetSunText(suns.ToString());
    }

    void Update(){
        // When the user presses the mouse over the gameboard, a Plant is spawned or a Sun could be selected in that mouse position
        if (Input.GetMouseButtonDown(0) && !win && !lose){
            Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(r.origin, r.direction);
            if (hit.collider != null){
                if (hit.collider.CompareTag("Quad")){
                    Transform t = hit.collider.transform;
                    CreatePlant(plantToUse, t);
                }
                else if (hit.collider.CompareTag("Sun")){
                    UpdateTotalSuns(50);
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
}
