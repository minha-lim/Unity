using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageEditTile : MonoBehaviour
{
    StageLevelManager.StageCell cell;

    public void SetCell(StageLevelManager.StageCell cell)
    {
        this.cell = cell;
    }

    public void EditType(StageLevelManager.StageCellType type, GameObject typeObj)
    {
        if(transform.childCount() > 0)
        {
            Destroy(transform.GetChild(0));
        }
        cell.type = type;
        GameObject obj = Instantiate(typeObj, transform);
    }
}
