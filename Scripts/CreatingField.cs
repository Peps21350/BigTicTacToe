using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static Unity.Mathematics.math;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;

public class CreatingField : MonoBehaviour
{

    [SerializeField] private Button imagesFields;
    [SerializeField] private GameObject _gameParent;
    [NonSerialized] public Button[] _selectCell;
    [SerializeField] private GameMechanic _gameMechanic;
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private CellIndicator _cellIndicator;
    [SerializeField] private GridLayoutGroup _gridLayout;
    
    public  void CreateField(int mapSize)
    {
        int cellsCount = mapSize * mapSize;
        _selectCell = new Button[cellsCount];

        _gridLayout.enabled = true;
        _gridLayout.constraintCount = mapSize;
        _gridLayout.transform.localScale = Vector3.one * 1.0f / mapSize * 10;

        for (int i = 0; i < cellsCount; i++)
        {
            _selectCell[i] = Instantiate(imagesFields, _gameParent.transform);
            _selectCell[i].GetComponent<CellIndicator>().numberCell = i;
            int index_cache = i;
            _selectCell[i].onClick.AddListener(() => _gameMechanic.ChangeImage(index_cache));
        }

        StartCoroutine(waitFor1Frame());

        IEnumerator waitFor1Frame()
        {
            yield return new WaitForEndOfFrame();
            _gridLayout.enabled = false;
        }
    }
    
    

}