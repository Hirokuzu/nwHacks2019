using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableArea : MonoBehaviour
{
    [SerializeField]
    private UnitData unitData;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    //sets tiles around unit to lit up 
    public void getMoveableCells(int pos, int mov)
    {
        for (int i = -unitData.Mov; i <= unitData.Mov; i++)
        {
            for (int j = -unitData.Mov; j <= unitData.Mov; j++)
            {
                if (transform.position.x + i < Constants.BoardSize / 2 && transform.position.x + i > -Constants.BoardSize / 2
                    && transform.position.y + i < Constants.BoardSize / 2 && transform.position.y + i > -Constants.BoardSize / 2)
                {
                    if (!(i == 0 && j == 0))
                    {
                        //Vector3Int Pos = Tilemap.WorldtoCell(transform.position);
                        Click = true;
                        //Pos.x += i;
                        //Pos.y += j;
                        //Tilemap.SetTile(Pos, );
                    }
                }
            }
        }
    }
    public void clearMoveableCells() {

    }
}
