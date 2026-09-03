/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[RequiredByNativeCode]
	public class ResourceRequest : AsyncOperation // TypeDefIndex: 7698
	{
		// Fields
		internal string m_Path; // 0x20
		internal Type m_Type; // 0x28
	
		// Properties
		public Object asset { get; } // 0x00000001816197C0-0x00000001816197E0 
	
		// Nested types
		internal static class BindingsMarshaller // TypeDefIndex: 7699
		{
			// Methods
			public static ResourceRequest ConvertToManaged(IntPtr ptr); // 0x00000001821E4820-0x00000001821E48A0
		}
	
		// Constructors
		protected ResourceRequest(IntPtr ptr); // 0x00000001821E1DC0-0x00000001821E1E20
	
		// Methods
		protected virtual Object GetResult(); // 0x00000001821F8070-0x00000001821F8080
	}
}
