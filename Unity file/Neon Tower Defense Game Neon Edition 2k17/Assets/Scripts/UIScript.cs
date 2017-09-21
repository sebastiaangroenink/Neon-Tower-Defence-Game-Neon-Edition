using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class UIScript : MonoBehaviour
{

    public Button sell;
    public List<Button> towerButtons = new List<Button>();

    private void Start()
    {
        sell.gameObject.SetActive(false);
        SetTowers(0);
    }

    public void SetTowers(int i)
    {
        if (i == 0 )
        {

            for (int tower = 0; tower < towerButtons.Count; tower++)
            {
                towerButtons[tower].gameObject.SetActive(false);
            }
        }
        else if(i == 1)
        {

            for (int tower = 0; tower < towerButtons.Count; tower++)
            {
                towerButtons[tower].gameObject.SetActive(true);
            }
        }
    }
}
