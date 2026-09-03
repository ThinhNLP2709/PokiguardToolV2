/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

// Image 10: Microsoft.Web.WebView2.Core.dll - Assembly: Microsoft.Web.WebView2.Core, Version=1.0.4191.47, Culture=neutral, PublicKeyToken=2a8ab48044d2601e - Types 10441-11179

namespace Microsoft.Web.WebView2.Core
{
	internal class JSHandlerWrapper // TypeDefIndex: 10809
	{
		// Fields
		private object _JSHandler; // 0x10
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 10810
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Func<ParameterInfo, int, Type> __9__3_0; // 0x08
	
			// Constructors
			static __c(); // 0x00000001813FDD60-0x00000001813FDDD0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal Type _CreateDelegate_b__3_0(ParameterInfo p, int i); // 0x00000001813FDD30-0x00000001813FDD60
		}
	
		// Constructors
		public JSHandlerWrapper(object JSHandler); // 0x00000001803855F0-0x0000000180385630
	
		// Methods
		internal static extern void VariantClear(IntPtr variant); // 0x00000001813FD750-0x00000001813FD7E0
		public void Invoke(params object[] args); // 0x00000001813FD2A0-0x00000001813FD750
		public Delegate CreateDelegate(EventInfo eventInfo); // 0x00000001813FCAC0-0x00000001813FD2A0
	}
}
