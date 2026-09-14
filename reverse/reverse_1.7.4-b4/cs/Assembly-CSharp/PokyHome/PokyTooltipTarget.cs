/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

namespace PokyHome
{
	[DisallowMultipleComponent]
	public class PokyTooltipTarget : MonoBehaviour // TypeDefIndex: 2723
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
		[NonSerialized]
		public Action customShow; // 0x48
	
		// Constructors
		public PokyTooltipTarget(); // 0x000000018028A560-0x000000018028A5B0
	
		// Methods
		public static PokyTooltipTarget Attach(GameObject go, string title, string body, Sprite icon, List<RewardDisplayHelper.Entry> rewards); // 0x0000000180C6AC00-0x0000000180C6B0E0
		public void Show(); // 0x0000000180C6B0E0-0x0000000180C6B200
	}
}
