/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

[Serializable]
public class PetShardDTO // TypeDefIndex: 1132
{
	// Fields
	public long petId; // 0x10
	public string petName; // 0x18
	public string elementType; // 0x20
	public int quantity; // 0x28
	public int star; // 0x2C
	public int nextCost; // 0x30
	public bool owned; // 0x34
	public bool canExchange; // 0x35

	// Properties
	public bool CanUpgradeNow { get; } // 0x0000000180697EA0-0x0000000180697EC0 

	// Constructors
	public PetShardDTO(); // 0x000000018028A320-0x000000018028A330

	// Methods
	public bool CanExchangeWith(int exchangeCost); // 0x0000000180697EC0-0x0000000180697EE0
}

