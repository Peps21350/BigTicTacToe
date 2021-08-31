using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;


public class CreatingField : MonoBehaviour
{
    [SerializeField] private Button imageField;
    [SerializeField] private GameObject gameParent;
    [NonSerialized] public Button[] SelectCell;
    [SerializeField] private GameMechanic gameMechanic;
    [SerializeField] private GridLayoutGroup gridLayout;
    [NonSerialized] public int CellsCount;
    private const float _ScaleGrid = 10f;

    
    public  void CreateField(int mapSize)
    {
        CellsCount = mapSize * mapSize;
        SelectCell = new Button[CellsCount];

        gridLayout.enabled = true;
        gridLayout.constraintCount = mapSize;
        gridLayout.transform.localScale = Vector3.one  / mapSize * _ScaleGrid;
        
        GameMechanic.SizeSide = mapSize;
        gameMechanic.SetMarkedCell();

        for (int i = 0; i < CellsCount; i++)
        {
            SelectCell[i] = Instantiate(imageField, gameParent.transform);
            SelectCell[i].GetComponent<CellIndicator>().numberCell = i;
            int indexCache = i;
            SelectCell[i].onClick.AddListener(() => gameMechanic.ChangeImage(indexCache));
        }

        StartCoroutine(WaitFor1Frame());
        
        IEnumerator WaitFor1Frame()
        {
            yield return new WaitForEndOfFrame();
            gridLayout.enabled = false;
        }
    }
    
    
}