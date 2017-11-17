using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour {

    public Button sellButon; //variable voor de sellbutton
    public List<Button> towerButtons = new List<Button>(); // list van alle buttons die gekoppeld zijn aan een tower

    private void Start()
    {
        sellButon.gameObject.SetActive(false); //zet sellbutton aan begin van het spel uit
        SetTowers(0); // roep SetTowers aan met een int van 0 
    }

    public void SetTowers(int i) // wordt aangeroepen vanuit andere scripts om buttons aan/uit te zetten.
    {
        if(i == 0) // als i 0 is zet het alle buttons in towerButtons uit DMV for loop.
        {
            for(int tower = 0; tower<towerButtons.Count; tower++)
            {
                towerButtons[tower].gameObject.SetActive(false);
            }
        }
        else if(i == 1) // als i 1 is zet het alle buttons in towerButtons aan DMV for loop. 
        {
            for(int tower = 0; tower < towerButtons.Count; tower++)
            {
                towerButtons[tower].gameObject.SetActive(true);
            }
        }
    }
}
