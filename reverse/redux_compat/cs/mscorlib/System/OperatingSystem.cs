/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System
{
	[Serializable]
	public sealed class OperatingSystem : ISerializable, ICloneable // TypeDefIndex: 2388
	{
		// Fields
		private readonly Version _version; // 0x10
		private readonly PlatformID _platform; // 0x18
		private readonly string _servicePack; // 0x20
		private string _versionString; // 0x28
	
		// Properties
		public PlatformID Platform { get; } // 0x0000000180B23260-0x0000000180B23270 
		public string VersionString { get; } // 0x0000000181616D30-0x0000000181616F10 
	
		// Constructors
		public OperatingSystem(PlatformID platform, Version version); // 0x0000000181616BA0-0x0000000181616BC0
		internal OperatingSystem(PlatformID platform, Version version, string servicePack); // 0x0000000181616BC0-0x0000000181616D30
	
		// Methods
		public void GetObjectData(SerializationInfo info, StreamingContext context); // 0x0000000181616B50-0x0000000181616B90
		public object Clone(); // 0x0000000181616AD0-0x0000000181616B50
		public override string ToString(); // 0x0000000181616B90-0x0000000181616BA0
	}
}
