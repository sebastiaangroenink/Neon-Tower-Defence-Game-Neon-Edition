using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class UIScript : MonoBehaviour
{

    public Button sell;
    public List<Button> towers = new List<Button>();

    private CanvasGroup visibility;

    private void Start()
    {
        visibility = GetComponent<CanvasGroup>();

        sell.gameObject.SetActive(false);
        for (int tower = 0; tower < towers.Count; tower++)
        {
            towers[tower].gameObject.SetActive(false);
        }
    }
}
