using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICellGridDrawable
{
    public List<Vector2Int> GetChangedCells();
    public void AddChangedCell(Vector2Int pos);
    public void ClearChangedCells();
}