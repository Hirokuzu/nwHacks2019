using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class Constants
{
    public const int BoardSize = 100;
}

public class Unit : MonoBehaviour
{
    [SerializeField]
    private UnitData unitData;
    private bool Hover;

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
        Debug.Log(unitData.Name);
        Debug.Log(unitData.HP);
        Debug.Log(unitData.Attack);
        Debug.Log(unitData.Mov);
        Debug.Log(unitData.Special);
        Hover = true;

    }      

    private void OnMouseExit()
    {
        Hover = false;
    }

    UnityEngine.AI.NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                agent.destination = hit.point;
            }
        }
    }


}
