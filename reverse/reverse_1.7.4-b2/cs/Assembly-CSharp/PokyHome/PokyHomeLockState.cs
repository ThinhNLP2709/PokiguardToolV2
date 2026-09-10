/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

namespace PokyHome
{
	[DisallowMultipleComponent]
	public class PokyHomeLockState : MonoBehaviour // TypeDefIndex: 2211
	{
		// Fields
		[Tooltip("G\u1ED1c c\u00E2y UI \u0111\u1EC3 qu\u00E9t view. B\u1ECF tr\u1ED1ng = ch\u00EDnh object n\u00E0y.")]
		public Transform root; // 0x20
		private readonly List<PokyHomeModuleView> _views; // 0x28
		private int _level; // 0x30
	
		// Properties
		public int ViewCount { get; } // 0x0000000180783B50-0x0000000180783B70 
		public int Level { get; } // 0x000000018039BF70-0x000000018039BF80 
		public IReadOnlyList<PokyHomeModuleView> Views { get; } // 0x00000001802FF640-0x00000001802FF650 
	
		// Constructors
		public PokyHomeLockState(); // 0x0000000180783AD0-0x0000000180783B50
	
		// Methods
		private void Awake(); // 0x00000001807836A0-0x0000000180783770
		public void Collect(); // 0x00000001807836A0-0x0000000180783770
		public void Apply(int userLevel); // 0x00000001807835A0-0x00000001807836A0
		public PokyHomeModuleView Find(string moduleId); // 0x0000000180783770-0x00000001807838A0
		public void SetNotify(PokyNotifySource src, int count); // 0x00000001807839A0-0x0000000180783AD0
		public bool HasSource(PokyNotifySource src); // 0x00000001807838A0-0x00000001807839A0
	}
}
