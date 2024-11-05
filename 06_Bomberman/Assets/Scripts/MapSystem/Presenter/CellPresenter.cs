using MapSystem.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellPresenter : MonoBehaviour
{
    //CellPresenters need to have their own CellType, to select the correct prefab.
    [SerializeField]
    private CellType _cellType;

    public CellType CellType => _cellType;

    public CellModel CellModel { get; private set; }

    public virtual void SetModel(CellModel model)
    {
        CellModel = model;
        
    }

}
