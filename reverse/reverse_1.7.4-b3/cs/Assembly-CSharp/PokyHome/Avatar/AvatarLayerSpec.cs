/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

namespace PokyHome.Avatar
{
	public sealed class AvatarLayerSpec // TypeDefIndex: 2914
	{
		// Fields
		private readonly AvatarLayerPair[] _pairs; // 0x10
		[CompilerGenerated]
		private string _Key_k__BackingField; // 0x18
		[CompilerGenerated]
		private bool _HasAvatarSet_k__BackingField; // 0x20
	
		// Properties
		public string Key { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018028EDE0-0x000000018028EDF0 0x00000001802B4F80-0x00000001802B4FE0
		public int Count { get; } // 0x0000000180D43BD0-0x0000000180D43BF0 
		public AvatarLayerPair this[int i] { get => default; } // 0x0000000180D43BF0-0x0000000180D43C30 
		public bool HasAvatarSet { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180CC9490-0x0000000180CC94A0 0x0000000180D43C30-0x0000000180D43C40
	
		// Constructors
		private AvatarLayerSpec(AvatarLayerPair[] pairs, string key, bool hasSet); // 0x0000000180D43C40-0x0000000180D43D00
	
		// Methods
		public bool TryGetIcon(int slot, out long iconId); // 0x0000000180D43D00-0x0000000180D43D70
		public static bool TryParse(string layers, out AvatarLayerSpec spec); // 0x0000000180D43D70-0x0000000180D44610
		private static int CompareBySlot(AvatarLayerPair a, AvatarLayerPair b); // 0x0000000180C73680-0x0000000180C736A0
		public static string PathOf(long iconId); // 0x0000000180D44610-0x0000000180D447C0
		public List<string> BuildDrawPaths(bool includeBackground); // 0x0000000180D447C0-0x0000000180D449B0
		public override string ToString(); // 0x000000018028EDE0-0x000000018028EDF0
	}
}
