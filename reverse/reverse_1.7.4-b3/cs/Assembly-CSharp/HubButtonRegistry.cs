/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class HubButtonRegistry // TypeDefIndex: 1940
{
	// Fields
	private readonly Dictionary<string, List<Button>> _byName; // 0x10
	private Button[] _all; // 0x18

	// Properties
	public Button[] All { get; } // 0x000000018028EDE0-0x000000018028EDF0 

	// Constructors
	public HubButtonRegistry(); // 0x000000018093CF60-0x000000018093D190

	// Methods
	public static HubButtonRegistry Build(); // 0x000000018093C930-0x000000018093CC40
	public Button Find(params string[] namesByPriority); // 0x000000018093CC40-0x000000018093CE80
	public IReadOnlyList<Button> FindAll(string name); // 0x000000018093CE80-0x000000018093CF60
}

