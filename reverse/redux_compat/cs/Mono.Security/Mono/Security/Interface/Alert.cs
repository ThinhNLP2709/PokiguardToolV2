/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 22: Mono.Security.dll - Assembly: Mono.Security, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0738eb9f132ed756 - Types 13806-13909

namespace Mono.Security.Interface
{
	public class Alert // TypeDefIndex: 13863
	{
		// Fields
		private AlertLevel level; // 0x10
		private AlertDescription description; // 0x11
	
		// Properties
		public AlertLevel Level { get; } // 0x00000001805625D0-0x00000001805625E0 
		public AlertDescription Description { get; } // 0x0000000180E38E10-0x0000000180E38E20 
	
		// Constructors
		public Alert(AlertDescription description); // 0x0000000181418F50-0x0000000181418FF0
	
		// Methods
		private void inferAlertLevel(); // 0x0000000181418FF0-0x0000000181419070
		public override string ToString(); // 0x0000000181418EB0-0x0000000181418F50
	}
}
