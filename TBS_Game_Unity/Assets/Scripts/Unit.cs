using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[System.Serializable]
public class UnitClickEvent : UnityEvent<Vector3Int, int>
{

}

public class Unit : MonoBehaviour
{
    [SerializeField]
    private UnitData unitData;
    [SerializeField]
    private bool Hover;
    [SerializeField]
    private UnitClickEvent unitClickEvent;
    //display health, attack, special
    private void OnGUI()
    {
        if (Hover)
        {
            GUI.Label(new Rect(10, 10, 100, 20), "HP: "+ unitData.HP.ToString());
            GUI.Label(new Rect(10, 30, 100, 20), "Attack: " + unitData.Attack.ToString());
            GUI.Label(new Rect(10, 50, 100, 20), "Special: " + unitData.Special.ToString());
        }
    }
    private void OnMouseOver()
    {
        //Debug.Log(unitData.Name);
        //Debug.Log(unitData.HP);
        //Debug.Log(unitData.Attack);
        //Debug.Log(unitData.Mov);
        //Debug.Log(unitData.Special);
        Hover = true;
        GridLayout gridLayout = transform.GetComponentInParent<GridLayout>();
        Vector3Int cellPosition = gridLayout.WorldToCell(transform.position);
        MoveableArea.getMoveableCells(cellPosition, unitData.Mov);

    }      

    private void OnMouseExit()
    {
        Hover = false;
    }
    

}
