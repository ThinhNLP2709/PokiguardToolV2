/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml
{
	public abstract class XmlResolver // TypeDefIndex: 6897
	{
		// Constructors
		protected XmlResolver(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public abstract object GetEntity(Uri absoluteUri, string role, Type ofObjectToReturn);
		public virtual Uri ResolveUri(Uri baseUri, string relativeUri); // 0x0000000181AA66F0-0x0000000181AA68E0
		public virtual bool SupportsType(Uri absoluteUri, Type type); // 0x0000000181AA68E0-0x0000000181AA69E0
		public virtual Task<object> GetEntityAsync(Uri absoluteUri, string role, Type ofObjectToReturn); // 0x0000000181AA66B0-0x0000000181AA66F0
	}
}
