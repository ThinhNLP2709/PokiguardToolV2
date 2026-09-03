/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
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
	[ComVisible(true)]
	public class Exception : ISerializable // TypeDefIndex: 2425
	{
		// Fields
		[OptionalField]
		private static object s_EDILock; // 0x00
		private string _className; // 0x10
		internal string _message; // 0x18
		private IDictionary _data; // 0x20
		private Exception _innerException; // 0x28
		private string _helpURL; // 0x30
		private object _stackTrace; // 0x38
		private string _stackTraceString; // 0x40
		private string _remoteStackTraceString; // 0x48
		private int _remoteStackIndex; // 0x50
		private object _dynamicMethods; // 0x58
		internal int _HResult; // 0x60
		private string _source; // 0x68
		[OptionalField(VersionAdded = 4)]
		private SafeSerializationManager _safeSerializationManager; // 0x70
		internal StackTrace[] captured_traces; // 0x78
		private IntPtr[] native_trace_ips; // 0x80
		private int caught_in_unmanaged; // 0x88
		private const int _COMPlusExceptionCode = -532462766; // Metadata: 0x0064E5FE
	
		// Properties
		public virtual string Message { get; } // 0x000000018163AF20-0x000000018163B040 
		public virtual IDictionary Data { get; } // 0x000000018163AEB0-0x000000018163AF20 
		public Exception InnerException { get; } // 0x000000018033D240-0x000000018033D250 
		public MethodBase TargetSite { get; } // 0x000000018163B1D0-0x000000018163B290 
		public virtual string StackTrace { get; } // 0x000000018163B190-0x000000018163B1D0 
		public virtual string Source { get; } // 0x000000018163B040-0x000000018163B190 
		public int HResult { get; protected set; } // 0x000000018150C180-0x000000018150C190 0x000000018041DC00-0x000000018041DC10
	
		// Nested types
		internal enum ExceptionMessageKind // TypeDefIndex: 2426
		{
			ThreadAbort = 1,
			ThreadInterrupted = 2,
			OutOfMemory = 3
		}
	
		// Constructors
		public Exception(); // 0x000000018163A940-0x000000018163A960
		public Exception(string message); // 0x000000018163AE10-0x000000018163AE50
		public Exception(string message, Exception innerException); // 0x000000018163AE50-0x000000018163AEB0
		protected Exception(SerializationInfo info, StreamingContext context); // 0x000000018163A960-0x000000018163AE10
		static Exception(); // 0x000000018163A8F0-0x000000018163A940
	
		// Methods
		private void Init(); // 0x000000018163A400-0x000000018163A4A0
		private string GetClassName(); // 0x0000000181639E90-0x0000000181639EF0
		private string GetStackTrace(bool needFileInfo); // 0x000000018163A3B0-0x000000018163A400
		internal void SetErrorCode(int hr); // 0x000000018041DC00-0x000000018041DC10
		public override string ToString(); // 0x000000018163A8E0-0x000000018163A8F0
		private string ToString(bool needFileLineInfo, bool needMessage); // 0x000000018163A620-0x000000018163A8E0
		public virtual void GetObjectData(SerializationInfo info, StreamingContext context); // 0x0000000181639F80-0x000000018163A3B0
		[OnDeserialized]
		private void OnDeserialized(StreamingContext context); // 0x000000018163A4A0-0x000000018163A530
		private string StripFileInfo(string stackTrace, bool isRemoteStackTrace); // 0x0000000180A68C50-0x0000000180A68C60
		internal void RestoreExceptionDispatchInfo(ExceptionDispatchInfo exceptionDispatchInfo); // 0x000000018163A540-0x000000018163A620
		public new Type GetType(); // 0x00000001816240F0-0x0000000181624100
		internal static string GetMessageFromNativeResources(ExceptionMessageKind kind); // 0x0000000181639EF0-0x0000000181639F80
		internal Exception FixRemotingException(); // 0x0000000181639DA0-0x0000000181639E90
		internal static void ReportUnhandledException(Exception exception); // 0x000000018163A530-0x000000018163A540
	}
}
