using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CellIndicator : MonoBehaviour
{
    public CellStatus StatusCell;
    public int numberCell = 0;
    [SerializeField] private Sprite[] _sprites;


    private void ChangeStatusButton()
    {
        // if (gameObject.GetComponent<Image>().sprite == _sprites[0])
        // {
        //     StatusButton = 0;
        // }
        //
        // if (gameObject.GetComponent<Image>().sprite == _sprites[1])
        // {
        //     StatusButton = 1;
        // }
    }


    private void Update()
    {
        ChangeStatusButton();
    }
}

public enum CellStatus
{
    NONE = 0,
    
    X = 1,
    O = 2
}
