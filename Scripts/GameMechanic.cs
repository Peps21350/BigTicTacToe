using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using static Unity.Mathematics.math;

public class GameMechanic : MonoBehaviour
{
    [NonSerialized] public int Player;
    [NonSerialized] public int PC;
    [SerializeField] private CreatingField creatingField;
    [SerializeField] private Sprite[] spritesObjects;
    [SerializeField] private GameObject rawImageForGame;
    [SerializeField] private GameUI gameUI;
    private bool _gameOver = false;
    
    public bool playerTurn = true;
    [NonSerialized] public int NumberSprite;
    [NonSerialized] public static int SizeSide;

    public CellStatus[,] MarkedCellMass;
    private CellStatus _whoMarkedCell;

    private bool _playerWin = false;
    private bool _pcWin = false;
    [NonSerialized] public bool _isDraw = false;
    
    private int _stateWinPC = 0;
    private int _stateWinPlayer = 0;
    private int _draw = 0;

    private void Start()
    {
        Player = 1;
        PC = 1;
    }

    
    public void SetMarkedCell()
    {
        MarkedCellMass = new CellStatus[SizeSide, SizeSide];
        
        for (int i = 0; i < SizeSide; i++)
        {
            for (int j = 0; j < SizeSide; j++)
            {
                MarkedCellMass[i, j] = CellStatus.None;
            }
        }
    }



    public void ChangeImage(int numberCell)
    {
        int firstIndex = 0;
        int secondIndex = 0;
        

        if (creatingField.SelectCell[numberCell].GetComponent<CellIndicator>().statusCell == CellStatus.None)
        {
            NumberSprite = playerTurn == true ? Player : PC;
            _whoMarkedCell = NumberSprite == Player && Player == 1 ? CellStatus.O : CellStatus.X;
            creatingField.SelectCell[numberCell].GetComponent<Image>().sprite = spritesObjects[NumberSprite];
            creatingField.SelectCell[numberCell].GetComponent<CellIndicator>().statusCell =
                NumberSprite == 1 ? CellStatus.O : CellStatus.X;
            creatingField.SelectCell[numberCell].GetComponent<Button>().interactable = false;
            playerTurn = NumberSprite != Player;

            firstIndex = numberCell / SizeSide;
            secondIndex = numberCell % SizeSide;

            MarkedCellMass[firstIndex,secondIndex] = creatingField.SelectCell[numberCell].GetComponent<CellIndicator>().statusCell;
           
            CheckWin();
        }
    }



    private void CheckArea(int index1, int index2)
    {
        if (MarkedCellMass[index1,index2] == _whoMarkedCell  &&  NumberSprite == PC)
        {
            _stateWinPC += 1;
            _draw += 1;
        }
        if (MarkedCellMass[index1,index2] == _whoMarkedCell && NumberSprite == Player)
        {
            _stateWinPlayer += 1;
            _draw += 1;
        }
        if (_stateWinPC == SizeSide)
        {
            Debug.Log("Pc win");
            gameUI.OpenGUI(false);
            rawImageForGame.SetActive(true);
            _gameOver = true;
        }
        if (_stateWinPlayer == SizeSide)
        {
            Debug.Log("Player win");
            gameUI.OpenGUI(true);
            rawImageForGame.SetActive(true);
            _gameOver = true;
        }
        if (_draw == SizeSide * SizeSide)
        {
            Debug.Log("Draw");
            rawImageForGame.SetActive(true);
            _isDraw = true;
            gameUI.OpenGUI(false);
            _gameOver = true;
        }
    }
    

    private void CheckWin()
    {
        if (_gameOver != true)
        {
            for (int i = 0; i < SizeSide; i++)
            {
                for (int j = 0; j < SizeSide; j++)
                {
                    CheckArea(i,j);
                }
                _stateWinPlayer = 0;
                _stateWinPC = 0;
            }

            _draw = 0;
            
            for (int i = 0; i < SizeSide; i++)
            {
                for (int j = 0; j < SizeSide; j++)
                {
                    CheckArea(j,i);
                }
                _stateWinPlayer = 0;
                _stateWinPC = 0;
            }
            
            _draw = 0;
        

            for (int i = 0; i < SizeSide; i++)
            {
                CheckArea(i,i);
            }
            _stateWinPlayer = 0;
            _stateWinPC = 0;
        
        
            for (int i = 0; i < SizeSide; i++)
            {
                CheckArea(i,SizeSide - i- 1);
                
            }
            _stateWinPlayer = 0;
            _stateWinPC = 0;
            
        }

    }
    
}



