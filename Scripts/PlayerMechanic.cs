using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMechanic : MonoBehaviour
{
    [SerializeField] private GameMechanic _gameMechanic;


    private void Update()
    {
        if (_gameMechanic.playerTurn == true)
        {
            
        }
    }
}
