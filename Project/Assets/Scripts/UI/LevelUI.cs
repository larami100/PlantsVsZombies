using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelUI : MonoBehaviour
{
    [SerializeField] // Card deck GameObject
    GameObject deck;

    [SerializeField] // Card prefab
    GameObject cardPrefab;

    [SerializeField] //Total sun text GameObject
    Text sunText;

    [SerializeField] // Win/Lose message text
    Text winLoseText;

    // Start is called before the first frame update
    void Start(){
        winLoseText.enabled = false;
        winLoseText.text = "";
    }

    public GameObject GetDeck(){
        return deck;
    }

    public GameObject GetCardPrefab(){
        return cardPrefab;
    }

    public void SetSunText(string text){
        sunText.text = text;
    }

    public void SetWinLoseText(string text){
        winLoseText.enabled = true;
        winLoseText.text = text;
    }
}
