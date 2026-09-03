/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

namespace PokyHome
{
	[DisallowMultipleComponent]
	public class PokyTooltipTarget : MonoBehaviour // TypeDefIndex: 1954
	{
		// Fields
		public string title; // 0x20
		[TextArea]
		public string body; // 0x28
		public Sprite icon; // 0x30
		[NonSerialized]
		public List<RewardDisplayHelper.Entry> rewards; // 0x38
		[NonSerialized]
		public Action<int> rewardClick; // 0x40
	
		// Constructors
		public PokyTooltipTarget(); // 0x00000001802E7A70-0x00000001802E7BC0
	
		// Methods
		public static PokyTooltipTarget Attach(GameObject go, string title, string body, Sprite icon, List<RewardDisplayHelper.Entry> rewards); // 0x00000001806671E0-0x0000000180667410
		public void Show(); // 0x0000000180667410-0x00000001806674E0
	}
}
