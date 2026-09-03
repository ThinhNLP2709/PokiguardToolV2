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

namespace System.Reflection
{
	[Serializable]
	[ComVisible(true)]
	public class StrongNameKeyPair : ISerializable, IDeserializationCallback // TypeDefIndex: 3363
	{
		// Fields
		private byte[] _publicKey; // 0x10
		private string _keyPairContainer; // 0x18
		private bool _keyPairExported; // 0x20
		private byte[] _keyPairArray; // 0x28
	
		// Constructors
		protected StrongNameKeyPair(SerializationInfo info, StreamingContext context); // 0x000000018153E460-0x000000018153E670
	
		// Methods
		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context); // 0x000000018153E330-0x000000018153E460
		void IDeserializationCallback.OnDeserialization(object sender); // 0x00000001802E76C0-0x00000001802E76D0
	}
}
