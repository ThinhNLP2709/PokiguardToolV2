/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	public class Logger : ILogger // TypeDefIndex: 7653
	{
		// Fields
		[CompilerGenerated]
		private ILogHandler _logHandler_k__BackingField; // 0x10
		[CompilerGenerated]
		private bool _logEnabled_k__BackingField; // 0x18
		[CompilerGenerated]
		private LogType _filterLogType_k__BackingField; // 0x1C
	
		// Properties
		public ILogHandler logHandler { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
		public bool logEnabled { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180F9E350-0x0000000180F9E360 0x00000001804C2E10-0x00000001804C2E20
		public LogType filterLogType { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180B232F0-0x0000000180B23300 0x0000000180E025C0-0x0000000180E025D0
	
		// Constructors
		public Logger(ILogHandler logHandler); // 0x00000001821CDC70-0x00000001821CDCB0
	
		// Methods
		public bool IsLogTypeAllowed(LogType logType); // 0x00000001821CD660-0x00000001821CD680
		private static string GetString(object message); // 0x00000001821CD530-0x00000001821CD660
		public void Log(LogType logType, object message); // 0x00000001821CDA00-0x00000001821CDB30
		public void Log(LogType logType, object message, Object context); // 0x00000001821CDB30-0x00000001821CDC70
		public void LogError(string tag, object message); // 0x00000001821CD680-0x00000001821CD800
		public void LogException(Exception exception, Object context); // 0x00000001821CD800-0x00000001821CD8D0
		public void LogFormat(LogType logType, string format, params object[] args); // 0x00000001821CD8D0-0x00000001821CD960
		public void LogFormat(LogType logType, Object context, string format, params object[] args); // 0x00000001821CD960-0x00000001821CDA00
	}
}
