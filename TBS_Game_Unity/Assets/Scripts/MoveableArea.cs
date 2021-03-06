﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MoveableArea : MonoBehaviour
{
    [SerializeField]
    private UnitData unitData;
    public Tilemap tilemap;
    [SerializeField]
    private static Tile Green;
    [SerializeField]
    private Tile Red;

    static class Constants
    {
        public const int BoardSize = 100;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    //sets tiles around unit to lit up 
    public void getMoveableCells()
    {
        GridLayout gridLayout = transform.GetComponentInParent<GridLayout>();
        Vector3Int pos = gridLayout.WorldToCell(transform.position);
        int mov = unitData.Mov;
        for (int i = -mov; i <= mov; i++)
        {
            for (int j = -mov; j <= mov; j++)
            {
                if (pos.x + i < Constants.BoardSize / 2 && pos.x + i > -Constants.BoardSize / 2
                    && pos.y + i < Constants.BoardSize / 2 && pos.y + i > -Constants.BoardSize / 2)
                {
                    if (!(i == 0 && j == 0))
                    {
                        //pos = gridLayout.WorldToCell(transform.position);
                        pos.x += i;
                        pos.y += j;
                        //Tilemap.SetTile(pos, Green);
                    }
                }
            }
        }
    }
    public void clearMoveableCells() {

    }
}
