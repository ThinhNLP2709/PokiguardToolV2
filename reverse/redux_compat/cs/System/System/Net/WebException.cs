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

namespace System.Net
{
	[Serializable]
	public class WebException : InvalidOperationException, ISerializable // TypeDefIndex: 9051
	{
		// Fields
		private WebExceptionStatus m_Status; // 0x90
		private WebResponse m_Response; // 0x98
		[NonSerialized]
		private WebExceptionInternalStatus m_InternalStatus; // 0xA0
	
		// Properties
		public WebExceptionStatus Status { get; } // 0x000000018169CBC0-0x000000018169CBD0 
		public WebResponse Response { get; } // 0x00000001806CCBC0-0x00000001806CCBD0 
	
		// Constructors
		public WebException(); // 0x0000000181BF5E20-0x0000000181BF5E40
		public WebException(string message); // 0x0000000181BF62C0-0x0000000181BF62E0
		public WebException(string message, Exception innerException); // 0x0000000181BF6010-0x0000000181BF6030
		public WebException(string message, WebExceptionStatus status); // 0x0000000181BF5E40-0x0000000181BF5E60
		internal WebException(string message, WebExceptionStatus status, WebExceptionInternalStatus internalStatus, Exception innerException); // 0x0000000181BF5E90-0x0000000181BF5F50
		public WebException(string message, Exception innerException, WebExceptionStatus status, WebResponse response); // 0x0000000181BF6030-0x0000000181BF60F0
		internal WebException(string message, string data, Exception innerException, WebExceptionStatus status, WebResponse response); // 0x0000000181BF60F0-0x0000000181BF61D0
		internal WebException(string message, Exception innerException, WebExceptionStatus status, WebResponse response, WebExceptionInternalStatus internalStatus); // 0x0000000181BF5F50-0x0000000181BF6010
		internal WebException(string message, string data, Exception innerException, WebExceptionStatus status, WebResponse response, WebExceptionInternalStatus internalStatus); // 0x0000000181BF61D0-0x0000000181BF62C0
		protected WebException(SerializationInfo serializationInfo, StreamingContext streamingContext); // 0x0000000181BF5E60-0x0000000181BF5E90
	
		// Methods
		void ISerializable.GetObjectData(SerializationInfo serializationInfo, StreamingContext streamingContext); // 0x0000000181BF5DF0-0x0000000181BF5E20
		public override void GetObjectData(SerializationInfo serializationInfo, StreamingContext streamingContext); // 0x0000000181B56990-0x0000000181B569B0
	}
}
