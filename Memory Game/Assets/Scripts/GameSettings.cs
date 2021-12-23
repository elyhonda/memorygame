using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{

    private int settings;
    private const int settingsNuber = 2;

    public enum EPairNumber
    {
        NotSet = 0,
        e10Pairs = 10,
        e15Pairs = 15,
        e20Pairs = 20,
    }

    public enum EPuzzleCategories{
        NotSet, Fruits, Vegetables
    }

    public struct Settings{

        public EPairNumber PairsNumber;
        public EPuzzleCategories PuzzleCategory;

    }

    private Settings gameSettings;

    public static GameSettings Instance;

    void Awake(){
        if(Instance == null){
            DontDestroyOnLoad(this);
            Instance = this;
        }else {
            Destroy(this);
        }
    }    

    // Start is called before the first frame update
    void Start()
    {
        gameSettings = new Settings();
        ResetGameSettings();
    }

    public void SetPairNumber(EPairNumber Number){
        if (gameSettings.PairsNumber == EPairNumber.NotSet)
            settings++;
        
        gameSettings.PairsNumber= Number;
    }

    public void SetPuzzleCategories(EPuzzleCategories cat){
        if (gameSettings.PuzzleCategory == EPuzzleCategories.NotSet)
            settings++;

        gameSettings.PuzzleCategory = cat;

    }

    public EPairNumber GetPairNumber(){
        return gameSettings.PairsNumber;
    }

    public EPuzzleCategories GetPuzzleCategories(){
        return gameSettings.PuzzleCategory;
    }

    public void ResetGameSettings(){
        settings = 0;
        gameSettings.PuzzleCategory = EPuzzleCategories.NotSet;
        gameSettings.PairsNumber = EPairNumber.NotSet;
    }

    public bool AllSettingsReady(){
        return settings == settingsNuber;
    }

}
