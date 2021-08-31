using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class MechanicsArtificialIntelligence : MonoBehaviour
{
    [SerializeField] private GameMechanic gameMechanic;
    [SerializeField] private CreatingField creatingField;
    private const int _MINCountLapsCycle = 10;


    public void ChangeImageByPC()
    {
        if (gameMechanic.playerTurn == false)
        {
            for (int i = 0; i < _MINCountLapsCycle * creatingField.CellsCount; i++)
            {
                int randomPosition = Random.Range(0, creatingField.CellsCount);
                if (creatingField.SelectCell[randomPosition].GetComponent<CellIndicator>().statusCell ==
                    CellStatus.None)
                {
                    gameMechanic.ChangeImage(randomPosition);
                    //_gameMechanic.playerTurn = true;
                    break;
                }
            }
        }
    }

    private void Update()
    {
        ChangeImageByPC();
    }
       
}
