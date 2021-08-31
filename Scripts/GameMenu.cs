using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : MonoBehaviour
{
    [SerializeField] private GameObject choiceSide;
    [SerializeField] private GameObject choiceTypeGame;
    [SerializeField] private GameObject menu;
    [SerializeField] private GameMechanic gameMechanic;
    [SerializeField] private CreatingField creatingField;

    
    public void StartGame()
    {
        menu.SetActive(false);
        choiceSide.SetActive(true);
    }

    public void ZeroSelection()
    {
        gameMechanic.PC = 2;
        menu.SetActive(false);
        choiceSide.SetActive(false);
        choiceTypeGame.SetActive(true);
    }
    
    public void CrossSelection()
    {
        gameMechanic.Player = 2;
        menu.SetActive(false);
        choiceSide.SetActive(false);
        choiceTypeGame.SetActive(true);
    }


    public void TypeGame3x3()
    {
        choiceTypeGame.SetActive(false);
        creatingField.CreateField(3);
    }
    
    public void TypeGame6x6()
    {
        choiceTypeGame.SetActive(false);
        creatingField.CreateField(6);
    }
    public void TypeGame9x9()
    {
        choiceTypeGame.SetActive(false);
        creatingField.CreateField(9);
    }
    
    public void TypeGame15x15()
    {
        choiceTypeGame.SetActive(false);
        creatingField.CreateField(15);
    }

}
