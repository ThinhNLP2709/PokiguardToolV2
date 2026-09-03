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

namespace System.Runtime.Remoting.Messaging
{
	[ComVisible(true)]
	public class RemotingSurrogateSelector : ISurrogateSelector // TypeDefIndex: 3002
	{
		// Fields
		private static Type s_cachedTypeObjRef; // 0x00
		private static ObjRefSurrogate _objRefSurrogate; // 0x08
		private static RemotingSurrogate _objRemotingSurrogate; // 0x10
		private ISurrogateSelector _next; // 0x10
	
		// Constructors
		public RemotingSurrogateSelector(); // 0x00000001802E5CB0-0x00000001802E5CC0
		static RemotingSurrogateSelector(); // 0x00000001814E9FB0-0x00000001814EA0D0
	
		// Methods
		public virtual ISerializationSurrogate GetSurrogate(Type type, StreamingContext context, out ISurrogateSelector ssout); // 0x00000001814E9E30-0x00000001814E9FB0
	}
}
