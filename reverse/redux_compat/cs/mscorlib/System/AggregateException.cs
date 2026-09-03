/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System
{
	[Serializable]
	[DebuggerDisplay("Count = {InnerExceptionCount}")]
	public class AggregateException : Exception // TypeDefIndex: 2205
	{
		// Fields
		private ReadOnlyCollection<Exception> m_innerExceptions; // 0x90
	
		// Properties
		public ReadOnlyCollection<Exception> InnerExceptions { get; } // 0x00000001806CCBA0-0x00000001806CCBB0 
		public override string Message { get; } // 0x000000018155C430-0x000000018155C5E0 
	
		// Constructors
		public AggregateException(); // 0x000000018155C340-0x000000018155C430
		public AggregateException(IEnumerable<Exception> innerExceptions); // 0x000000018155BB80-0x000000018155BC60
		public AggregateException(params Exception[] innerExceptions); // 0x000000018155C2F0-0x000000018155C340
		public AggregateException(string message, IEnumerable<Exception> innerExceptions); // 0x000000018155BD30-0x000000018155BDF0
		public AggregateException(string message, params Exception[] innerExceptions); // 0x000000018155BC60-0x000000018155BC70
		private AggregateException(string message, IList<Exception> innerExceptions); // 0x000000018155BDF0-0x000000018155C060
		internal AggregateException(IEnumerable<ExceptionDispatchInfo> innerExceptionInfos); // 0x000000018155C060-0x000000018155C140
		internal AggregateException(string message, IEnumerable<ExceptionDispatchInfo> innerExceptionInfos); // 0x000000018155BC70-0x000000018155BD30
		private AggregateException(string message, IList<ExceptionDispatchInfo> innerExceptionInfos); // 0x000000018155B8E0-0x000000018155BB80
		protected AggregateException(SerializationInfo info, StreamingContext context); // 0x000000018155C140-0x000000018155C2F0
	
		// Methods
		public override void GetObjectData(SerializationInfo info, StreamingContext context); // 0x000000018155B5C0-0x000000018155B6E0
		public AggregateException Flatten(); // 0x000000018155B350-0x000000018155B5C0
		public override string ToString(); // 0x000000018155B6E0-0x000000018155B8E0
	}
}
