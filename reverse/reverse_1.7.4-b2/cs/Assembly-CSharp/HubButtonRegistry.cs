/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class HubButtonRegistry // TypeDefIndex: 1557
{
	// Fields
	private readonly Dictionary<string, List<Button>> _byName; // 0x10
	private Button[] _all; // 0x18

	// Properties
	public Button[] All { get; } // 0x00000001803003B0-0x00000001803003C0 
	public int Count { get; } // 0x00000001805F6750-0x00000001805F6770 

	// Constructors
	public HubButtonRegistry(); // 0x00000001805F6600-0x00000001805F6750

	// Methods
	public static HubButtonRegistry Build(); // 0x00000001805F60A0-0x00000001805F63D0
	public Button Find(params string[] namesByPriority); // 0x00000001805F64A0-0x00000001805F6600
	public IReadOnlyList<Button> FindAll(string name); // 0x00000001805F63D0-0x00000001805F64A0
}

