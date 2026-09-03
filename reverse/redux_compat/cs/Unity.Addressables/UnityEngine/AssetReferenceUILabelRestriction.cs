/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

// Image 25: Unity.Addressables.dll - Assembly: Unity.Addressables, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14023-14125

namespace UnityEngine
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
	public sealed class AssetReferenceUILabelRestriction : AssetReferenceUIRestriction // TypeDefIndex: 14027
	{
		// Fields
		public string[] m_AllowedLabels; // 0x10
		public string m_CachedToString; // 0x18
	
		// Constructors
		public AssetReferenceUILabelRestriction(params string[] allowedLabels); // 0x00000001802E7420-0x00000001802E7460
	
		// Methods
		public override bool ValidateAsset(Object obj); // 0x00000001802E7990-0x00000001802E79A0
		public override bool ValidateAsset(string path); // 0x00000001802E7990-0x00000001802E79A0
		public override string ToString(); // 0x0000000181C73D10-0x0000000181C73E20
	}
}
