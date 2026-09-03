/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Net
{
	[Serializable]
	public abstract class WebResponse : MarshalByRefObject, ISerializable, IDisposable // TypeDefIndex: 9062
	{
		// Fields
		private bool m_IsFromCache; // 0x18
	
		// Properties
		public virtual bool IsFromCache { get; } // 0x0000000180F9E350-0x0000000180F9E360 
		public virtual Uri ResponseUri { get; } // 0x0000000181BFA650-0x0000000181BFA7E0 
		public virtual WebHeaderCollection Headers { get; } // 0x0000000181BFA620-0x0000000181BFA650 
	
		// Constructors
		protected WebResponse(); // 0x00000001802E5CB0-0x00000001802E5CC0
		protected WebResponse(SerializationInfo serializationInfo, StreamingContext streamingContext); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		void ISerializable.GetObjectData(SerializationInfo serializationInfo, StreamingContext streamingContext); // 0x0000000181B0FAD0-0x0000000181B0FB00
		protected virtual void GetObjectData(SerializationInfo serializationInfo, StreamingContext streamingContext); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual void Close(); // 0x00000001802E76C0-0x00000001802E76D0
		public void Dispose(); // 0x0000000181BFA580-0x0000000181BFA5F0
		protected virtual void Dispose(bool disposing); // 0x0000000181BFA550-0x0000000181BFA580
		public virtual Stream GetResponseStream(); // 0x0000000181BFA5F0-0x0000000181BFA620
	}
}
