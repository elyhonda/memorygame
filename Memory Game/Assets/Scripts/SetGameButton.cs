using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetGameButton : MonoBehaviour
{

    public enum EButtonType{
        NotSet, 
        PairsNumberBtn,
        PuzzleCategoryBtn,
    };

    [SerializeField] public EButtonType ButtonType = EButtonType.NotSet;
    [HideInInspector] public GameSettings.EPairNumber PairsNumber = GameSettings.EPairNumber.NotSet;
    [HideInInspector] public GameSettings.EPuzzleCategories PuzzleCategories = GameSettings.EPuzzleCategories.NotSet;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetGameOption(string GameSceneName){
        var comp = gameObject.GetComponent<SetGameButton>();
        switch (comp.ButtonType)
        {
            case SetGameButton.EButtonType.PairsNumberBtn:
                GameSettings.Instance.SetPairNumber(comp.PairsNumber);
                break;
            case EButtonType.PuzzleCategoryBtn:
                GameSettings.Instance.SetPuzzleCategories(comp.PuzzleCategories);
                break;    
        }
        if(GameSettings.Instance.AllSettingsReady()){
            SceneManager.LoadScene(GameSceneName);
        }
    }

}
