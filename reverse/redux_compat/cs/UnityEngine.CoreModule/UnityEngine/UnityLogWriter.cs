/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Text;
using UnityEngine;
using UnityEngine.Bindings;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[NativeHeader("Runtime/Export/Logging/UnityLogWriter.bindings.h")]
	internal class UnityLogWriter : TextWriter // TypeDefIndex: 7654
	{
		// Properties
		public override Encoding Encoding { get; } // 0x00000001821DF350-0x00000001821DF360 
	
		// Constructors
		public UnityLogWriter(); // 0x00000001821DF300-0x00000001821DF350
	
		// Methods
		public static void WriteStringToUnityLog(string s); // 0x00000001821DF260-0x00000001821DF270
		[FreeFunction(IsThreadSafe = true)]
		private static void WriteStringToUnityLogImpl(string s); // 0x00000001821DF120-0x00000001821DF260
		public static void Init(); // 0x00000001821DF000-0x00000001821DF0E0
		public override void Write(char value); // 0x00000001821DF290-0x00000001821DF2D0
		public override void Write(string s); // 0x00000001821DF270-0x00000001821DF290
		public override void Write(char[] buffer, int index, int count); // 0x00000001821DF2D0-0x00000001821DF300
		private static void WriteStringToUnityLogImpl_Injected(ref ManagedSpanWrapper s); // 0x00000001821DF0E0-0x00000001821DF120
	}
}
