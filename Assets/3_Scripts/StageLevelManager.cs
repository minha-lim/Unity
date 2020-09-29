using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageLevelManager : MonoBehaviour
{
    public enum StageCellType
    {
        None,
        Wall,
        ItemBox,
        Goal,
        Player
    }
    public struct StageCell
    {
        public int x;
        public int y;
        public StageCellType type;
    }
    public struct StageInfo
    {
        public int id;
        public int size;
        public StageCell[] cells;
        public StageCell(int x, int y, StageCellType type)
        {
            this.x=x;
            this.y=y;
            this.type = type;
        }
    }

    List<StageEditTile> stageTiles;
    public GameObject editTilePrefab;
    public GameObject wallPrefab;
    public GameObject itemBoxPrefab;
    public GameObject goalPrefab;
    public GameObject playerPrefab;

    public int stageId =0;
    public int stageSize = 10;

    public void CreateNewStage()
    {
        for(int x=0; x<stageSize; x++)
        {
            for(int y=0; y<stageSize; y++)
            {
                StageCell cell = new StageCell(x, y, StageCellType.None);

                GameObject editTile = instantiate(editTilePrefab, transform);
                editTile.name = "tile(" + x + "," + y + ")";
                SetTilePosition(editTile,x,y);

                stageTiles.Add(editTile.GetComponent<StageEditTile>());
            }
        }
    }

    public void CleanUpStage()
    {
        int tileCount = stageTiles.Count;
        for(int i=0; i <tileCount; i++)
        {
            GameObject tileObj = stageTiles[0].GameObject;
            stageTiles.RemoveAt(0);

            DestroyImmediate(tileObj);
        }
    }
    void SetTilePosition(GameObject tile, int x, int z)
    {
        Vector3 newPos = new Vector3(x, 0f, -z);
        Vector3 correction = new Vector3((stageSize * 0.5f), 0f, -(stageSize * 0.5f));
        tile.transform.localPosition = newPos - correction - new Vector3(-0.5f, 0f, 0.5f);
    }
}
