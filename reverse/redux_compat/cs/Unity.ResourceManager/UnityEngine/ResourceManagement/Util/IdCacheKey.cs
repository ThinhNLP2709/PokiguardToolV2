/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

// Image 21: Unity.ResourceManager.dll - Assembly: Unity.ResourceManager, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13663-13805

namespace UnityEngine.ResourceManagement.Util
{
	internal sealed class IdCacheKey : IOperationCacheKey // TypeDefIndex: 13707
	{
		// Fields
		public string ID; // 0x10
		public Type locationType; // 0x18
	
		// Constructors
		public IdCacheKey(string id); // 0x000000018204AB90-0x000000018204AC00
		public IdCacheKey(Type locType, string id); // 0x00000001814CFB00-0x00000001814CFB50
	
		// Methods
		private bool Equals(IdCacheKey other); // 0x000000018204A9D0-0x000000018204AA50
		public override int GetHashCode(); // 0x000000018204AB20-0x000000018204AB90
		public override bool Equals(object obj); // 0x000000018204AA50-0x000000018204AB20
		public bool Equals(IOperationCacheKey other); // 0x000000018204A900-0x000000018204A9D0
	}
}
