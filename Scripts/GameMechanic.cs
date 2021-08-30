using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameMechanic : MonoBehaviour
{
    [NonSerialized] public int Player;
    [NonSerialized] public int PC;
    [SerializeField] private CreatingField creatingField;
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private CellIndicator cellIndicator;
    

    public bool playerTurn = true;
    private int _numberSprite;
    

    private void Start()
    {
        Player = 0;
        PC = 0;
    }
    
    public void ChangeImage(int numberCell)
    {
        // Image myImage = button.GetComponent<Image>();
        // if (playerTurn)
        // {
        //     switch (Player)
        //     {
        //         case 0: myImage.sprite = sprites[0]; break; 
        //         case 1: myImage.sprite = sprites[1]; break;
        //     }
        //
        // }
        if (creatingField._selectCell[numberCell].GetComponent<CellIndicator>().StatusCell == CellStatus.NONE)
        {
            creatingField._selectCell[numberCell].GetComponent<Image>().sprite = sprites[_numberSprite];
        }

    }

    private void Update()
    {
        _numberSprite = playerTurn == true ? Player : PC;
    }
}



