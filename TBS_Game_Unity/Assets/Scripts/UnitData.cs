using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Unit", menuName = "Unit", order = 51)]
public class UnitData : ScriptableObject
{
    [SerializeField]
    private string name;
    [SerializeField]
    private int hp;
    [SerializeField]
    private int attack;
    [SerializeField]
    private int mov;
    [SerializeField]
    private string special;

    public string Name
    {
        get
        {
            return name;
        }
    }

    public int HP
    {
        get
        {
            return hp;
        }
    }

    public int Attack
    {
        get
        {
            return attack;
        }
    }

    public int Mov
    {
        get
        {
            return mov;
        }
    }

    public string Special
    {
        get
        {
            return special;
        }
    }

}
