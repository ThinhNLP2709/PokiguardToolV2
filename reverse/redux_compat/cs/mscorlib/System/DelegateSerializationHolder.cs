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
	internal class DelegateSerializationHolder : ISerializable, IObjectReference // TypeDefIndex: 2456
	{
		// Fields
		private Delegate _delegate; // 0x10
	
		// Nested types
		[Serializable]
		private class DelegateEntry // TypeDefIndex: 2457
		{
			// Fields
			private string type; // 0x10
			private string assembly; // 0x18
			private object target; // 0x20
			private string targetTypeAssembly; // 0x28
			private string targetTypeName; // 0x30
			private string methodName; // 0x38
			public DelegateEntry delegateEntry; // 0x40
	
			// Constructors
			public DelegateEntry(Delegate del, string targetLabel); // 0x000000018164DC70-0x000000018164DE70
	
			// Methods
			public Delegate DeserializeDelegate(SerializationInfo info, int index); // 0x000000018164D8F0-0x000000018164DC70
		}
	
		// Constructors
		private DelegateSerializationHolder(SerializationInfo info, StreamingContext ctx); // 0x000000018164E0E0-0x000000018164E320
	
		// Methods
		public static void GetDelegateData(Delegate instance, SerializationInfo info, StreamingContext ctx); // 0x000000018164DE70-0x000000018164E0A0
		public void GetObjectData(SerializationInfo info, StreamingContext context); // 0x000000018164E0A0-0x000000018164E0E0
		public object GetRealObject(StreamingContext context); // 0x0000000180377550-0x0000000180377560
	}
}
