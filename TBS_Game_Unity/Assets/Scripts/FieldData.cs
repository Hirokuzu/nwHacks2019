using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldData : ScriptableObject
{
	[SerializeField]
	string type;
	[SerializeField]
	int defence;
	[SerializeField]
	int avoid;
	[SerializeField]
	bool traversable;

	public string Type { get => type; set => type = value; }
	public int Defence { get => defence; set => defence = value; }
	public int Avoid { get => avoid; set => avoid = value; }
	public bool Traversable { get => traversable; set => traversable = value; }
}
