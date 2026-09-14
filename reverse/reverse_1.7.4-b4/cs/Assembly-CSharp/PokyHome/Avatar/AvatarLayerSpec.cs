/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

namespace PokyHome.Avatar
{
	public sealed class AvatarLayerSpec // TypeDefIndex: 2921
	{
		// Fields
		private readonly AvatarLayerPair[] _pairs; // 0x10
		[CompilerGenerated]
		private string _Key_k__BackingField; // 0x18
		[CompilerGenerated]
		private bool _HasAvatarSet_k__BackingField; // 0x20
	
		// Properties
		public string Key { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018028EDE0-0x000000018028EDF0 0x00000001802B4F80-0x00000001802B4FE0
		public int Count { get; } // 0x0000000180D51940-0x0000000180D51960 
		public AvatarLayerPair this[int i] { get => default; } // 0x0000000180D51960-0x0000000180D519A0 
		public bool HasAvatarSet { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180CD6CD0-0x0000000180CD6CE0 0x0000000180D519A0-0x0000000180D519B0
	
		// Constructors
		private AvatarLayerSpec(AvatarLayerPair[] pairs, string key, bool hasSet); // 0x0000000180D519B0-0x0000000180D51A70
	
		// Methods
		public bool TryGetIcon(int slot, out long iconId); // 0x0000000180D51A70-0x0000000180D51AE0
		public static bool TryParse(string layers, out AvatarLayerSpec spec); // 0x0000000180D51AE0-0x0000000180D52380
		private static int CompareBySlot(AvatarLayerPair a, AvatarLayerPair b); // 0x0000000180CA6D30-0x0000000180CA6D50
		public static string PathOf(long iconId); // 0x0000000180D52380-0x0000000180D52530
		public List<string> BuildDrawPaths(bool includeBackground); // 0x0000000180D52530-0x0000000180D52720
		public override string ToString(); // 0x000000018028EDE0-0x000000018028EDF0
	}
}
