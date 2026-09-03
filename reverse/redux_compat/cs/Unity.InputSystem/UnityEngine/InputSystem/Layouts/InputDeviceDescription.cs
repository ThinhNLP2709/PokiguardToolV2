/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem.Utilities;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.Layouts
{
	[Serializable]
	public struct InputDeviceDescription : IEquatable<InputDeviceDescription> // TypeDefIndex: 6551
	{
		// Fields
		[SerializeField]
		private string m_InterfaceName; // 0x00
		[SerializeField]
		private string m_DeviceClass; // 0x08
		[SerializeField]
		private string m_Manufacturer; // 0x10
		[SerializeField]
		private string m_Product; // 0x18
		[SerializeField]
		private string m_Serial; // 0x20
		[SerializeField]
		private string m_Version; // 0x28
		[SerializeField]
		private string m_Capabilities; // 0x30
	
		// Properties
		public string interfaceName { get; set; } // 0x00000001808BADD0-0x00000001808BADE0 0x0000000180E02C90-0x0000000180E02CA0
		public string deviceClass { get; set; } // 0x0000000180C5CF90-0x0000000180C5CFA0 0x0000000181B9F360-0x0000000181B9F370
		public string manufacturer { get; set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
		public string product { get; set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001802FAF70-0x00000001802FAF80
		public string serial { get; set; } // 0x00000001802F8630-0x00000001802F8640 0x000000018033E830-0x000000018033E840
		public string version { get; set; } // 0x000000018033D240-0x000000018033D250 0x000000018033E840-0x000000018033E850
		public string capabilities { get; set; } // 0x000000018031E110-0x000000018031E120 0x0000000180378110-0x0000000180378120
		public bool empty { get; } // 0x0000000181CEEB20-0x0000000181CEEBA0 
	
		// Nested types
		private struct DeviceDescriptionJson // TypeDefIndex: 6552
		{
			// Fields
			public string @interface; // 0x00
			public string type; // 0x08
			public string product; // 0x10
			public string serial; // 0x18
			public string version; // 0x20
			public string manufacturer; // 0x28
			public string capabilities; // 0x30
		}
	
		// Methods
		public override string ToString(); // 0x0000000181CEE890-0x0000000181CEEB20
		public bool Equals(InputDeviceDescription other); // 0x0000000181CEE370-0x0000000181CEE470
		public override bool Equals(object obj); // 0x0000000181CEE2C0-0x0000000181CEE370
		public override int GetHashCode(); // 0x0000000181CEE610-0x0000000181CEE780
		public static bool operator ==(InputDeviceDescription left, InputDeviceDescription right); // 0x0000000181CEEBA0-0x0000000181CEEBE0
		public static bool operator !=(InputDeviceDescription left, InputDeviceDescription right); // 0x0000000181CEEBE0-0x0000000181CEEC20
		public string ToJson(); // 0x0000000181CEE780-0x0000000181CEE890
		public static InputDeviceDescription FromJson(string json); // 0x0000000181CEE470-0x0000000181CEE610
		internal static bool ComparePropertyToDeviceDescriptor(string propertyName, JsonParser.JsonString propertyValue, string deviceDescriptor); // 0x0000000181CEE170-0x0000000181CEE2C0
	}
}
