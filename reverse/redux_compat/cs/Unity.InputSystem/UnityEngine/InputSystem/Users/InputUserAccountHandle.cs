/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.Users
{
	public struct InputUserAccountHandle : IEquatable<UnityEngine.InputSystem.Users.InputUserAccountHandle> // TypeDefIndex: 6293
	{
		// Fields
		private string m_ApiName; // 0x00
		private ulong m_Handle; // 0x08
	
		// Properties
		public string apiName { get; } // 0x00000001808BADD0-0x00000001808BADE0 
		public ulong handle { get; } // 0x0000000180C5CF90-0x0000000180C5CFA0 
	
		// Constructors
		public InputUserAccountHandle(string apiName, ulong handle); // 0x0000000181DB59B0-0x0000000181DB5A50
	
		// Methods
		public override string ToString(); // 0x0000000181DB5900-0x0000000181DB59B0
		public bool Equals(InputUserAccountHandle other); // 0x0000000181DB5730-0x0000000181DB57B0
		public override bool Equals(object obj); // 0x0000000181DB57B0-0x0000000181DB58A0
		public static bool operator ==(InputUserAccountHandle left, InputUserAccountHandle right); // 0x0000000181DB5A50-0x0000000181DB5AD0
		public static bool operator !=(InputUserAccountHandle left, InputUserAccountHandle right); // 0x0000000181DB5AD0-0x0000000181DB5B60
		public override int GetHashCode(); // 0x0000000181DB58A0-0x0000000181DB5900
	}
}
