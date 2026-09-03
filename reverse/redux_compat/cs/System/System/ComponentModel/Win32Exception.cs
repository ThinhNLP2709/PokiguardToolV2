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

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.ComponentModel
{
	[Serializable]
	public class Win32Exception : ExternalException, ISerializable // TypeDefIndex: 8925
	{
		// Fields
		private readonly int nativeErrorCode; // 0x90
	
		// Properties
		public int NativeErrorCode { get; } // 0x000000018169CBC0-0x000000018169CBD0 
	
		// Constructors
		public Win32Exception(); // 0x0000000181BDDB70-0x0000000181BDDBD0
		public Win32Exception(int error); // 0x0000000181BDDC90-0x0000000181BDDCD0
		public Win32Exception(int error, string message); // 0x0000000181BDDC60-0x0000000181BDDC90
		protected Win32Exception(SerializationInfo info, StreamingContext context); // 0x0000000181BDDBD0-0x0000000181BDDC60
	
		// Methods
		public override void GetObjectData(SerializationInfo info, StreamingContext context); // 0x0000000181BDDAA0-0x0000000181BDDB70
		internal static string GetErrorMessage(int error); // 0x0000000181BDCFD0-0x0000000181BDDAA0
	}
}
