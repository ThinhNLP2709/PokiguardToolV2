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
	public interface ILogger : ILogHandler // TypeDefIndex: 7651
	{
		// Properties
		ILogHandler logHandler { get; }
		bool logEnabled { get; }
	
		// Methods
		bool IsLogTypeAllowed(LogType logType);
		void Log(LogType logType, object message);
		void Log(LogType logType, object message, Object context);
		void LogError(string tag, object message);
		void LogFormat(LogType logType, string format, params object[] args);
	}
}
