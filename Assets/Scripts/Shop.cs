using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [Header("Character")]
    public CharData[] karakter;

    [Header("UI")]
    [SerializeField] private GameObject selectButton;
    [SerializeField] private GameObject buyButton;
    [SerializeField] private Text priceText;
    [SerializeField] private Text GoldText;

    private int currentChar = 0;

    private void Start() {
        Time.timeScale = 1;
        currentChar = 0;
        GoldText.text = DataManager.coinValue.ToString();

        for(int i = 0; i < karakter.Length; i++){
            if(DataManager.unlockedChar.Contains(i))
                karakter[i].Unlock = true;
        }
    }

    public void SelectChar(){
        DataManager.selectedChar = currentChar;
        selectButton.SetActive(false);
    }

    public void NextChar(){
        karakter[currentChar].charPrefab.SetActive(false);
        currentChar = (currentChar + 1) % karakter.Length;
        karakter[currentChar].charPrefab.SetActive(true);
        checkChar();
    }

    public void PreviousChar(){
        karakter[currentChar].charPrefab.SetActive(false);
        currentChar--;
        if(currentChar < 0){
            currentChar += karakter.Length;
        }
        karakter[currentChar].charPrefab.SetActive(true);
        checkChar();
    }

    public void buyChar(){
        if(DataManager.coinValue >= karakter[currentChar].price){
            DataManager.coinValue -= karakter[currentChar].price;

            karakter[currentChar].Unlock = true;
            buyButton.SetActive(false);
            selectButton.SetActive(true);
            GoldText.text = DataManager.coinValue.ToString();

            DataManager.unlockedChar.Add(currentChar);
        }
    }

    private void checkChar(){
        if(currentChar == DataManager.selectedChar){
            selectButton.SetActive(false);
            buyButton.SetActive(false);
        }
        else{
            if(!karakter[currentChar].Unlock){
                selectButton.SetActive(false);
                priceText.text = karakter[currentChar].price.ToString();
                buyButton.SetActive(true);
            }
            else
                selectButton.SetActive(true);
        }
    }

    [System.Serializable]
    public class CharData
    {
        public string charName;
        public GameObject charPrefab;
        public float price;
        public bool Unlock;
    }

}
