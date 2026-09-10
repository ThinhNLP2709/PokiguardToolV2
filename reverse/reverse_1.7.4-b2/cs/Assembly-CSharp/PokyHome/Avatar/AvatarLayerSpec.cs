/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

namespace PokyHome.Avatar
{
	public sealed class AvatarLayerSpec // TypeDefIndex: 2467
	{
		// Fields
		private readonly AvatarLayerPair[] _pairs; // 0x10
		[CompilerGenerated]
		private string _Key_k__BackingField; // 0x18
		[CompilerGenerated]
		private bool _HasAvatarSet_k__BackingField; // 0x20
	
		// Properties
		public string Key { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803003B0-0x00000001803003C0 0x0000000180317080-0x0000000180317090
		public int Count { get; } // 0x000000018080F8B0-0x000000018080F8D0 
		public AvatarLayerPair this[int i] { get => default; } // 0x000000018080F8D0-0x000000018080F910 
		public bool HasAvatarSet { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001807CDB60-0x00000001807CDB70 0x000000018080F910-0x000000018080F920
	
		// Constructors
		private AvatarLayerSpec(AvatarLayerPair[] pairs, string key, bool hasSet); // 0x000000018080F840-0x000000018080F8B0
	
		// Methods
		public bool TryGetIcon(int slot, out long iconId); // 0x000000018080F1A0-0x000000018080F210
		public static bool TryParse(string layers, out AvatarLayerSpec spec); // 0x000000018080F210-0x000000018080F840
		private static int CompareBySlot(AvatarLayerPair a, AvatarLayerPair b); // 0x00000001807B4C30-0x00000001807B4C50
		public static string PathOf(long iconId); // 0x000000018080F0A0-0x000000018080F1A0
		public List<string> BuildDrawPaths(bool includeBackground); // 0x000000018080EED0-0x000000018080F0A0
		public override string ToString(); // 0x00000001803003B0-0x00000001803003C0
	}
}
