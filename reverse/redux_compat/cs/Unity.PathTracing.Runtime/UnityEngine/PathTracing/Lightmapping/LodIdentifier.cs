/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 20: Unity.PathTracing.Runtime.dll - Assembly: Unity.PathTracing.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13540-13662

namespace UnityEngine.PathTracing.Lightmapping
{
	internal struct LodIdentifier // TypeDefIndex: 13623
	{
		// Fields
		public int LodGroup; // 0x00
		public byte LodMask; // 0x04
		private int LodContributorLevel; // 0x08
		public static readonly LodIdentifier Invalid; // 0x00
	
		// Constructors
		public LodIdentifier(int lodGroup, byte lodMask, int lodContributorLevel); // 0x0000000181E11330-0x0000000181E11340
		static LodIdentifier(); // 0x0000000181E112D0-0x0000000181E11330
	
		// Methods
		public override int GetHashCode(); // 0x0000000181E11230-0x0000000181E11290
		public override bool Equals(object obj); // 0x0000000181E11190-0x0000000181E11230
		public bool IsValid(); // 0x0000000181E112B0-0x0000000181E112C0
		public bool IsContributor(); // 0x0000000181E11290-0x0000000181E112B0
		public byte MinLodLevelMask(); // 0x0000000181E112C0-0x0000000181E112D0
	}
}
