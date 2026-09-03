/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Net
{
	public class Authorization // TypeDefIndex: 9030
	{
		// Fields
		private string m_Message; // 0x10
		private bool m_Complete; // 0x18
		internal string ModuleAuthenticationType; // 0x20
	
		// Properties
		public string Message { get; } // 0x0000000180377550-0x0000000180377560 
		public bool Complete { get; } // 0x0000000180F9E350-0x0000000180F9E360 
	
		// Constructors
		public Authorization(string token); // 0x0000000181BDE7E0-0x0000000181BDE860
		public Authorization(string token, bool finished); // 0x0000000181BDE860-0x0000000181BDE8F0
	}
}
