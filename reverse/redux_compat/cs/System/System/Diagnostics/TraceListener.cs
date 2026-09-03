/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Diagnostics
{
	public abstract class TraceListener : MarshalByRefObject, IDisposable // TypeDefIndex: 8734
	{
		// Fields
		private int indentLevel; // 0x18
		private int indentSize; // 0x1C
		private TraceOptions traceOptions; // 0x20
		private bool needIndent; // 0x24
		private string listenerName; // 0x28
		private TraceFilter filter; // 0x30
	
		// Properties
		public virtual bool IsThreadSafe { get; } // 0x00000001802E7840-0x00000001802E7850 
		public int IndentLevel { set; } // 0x0000000181B88100-0x0000000181B88120
		public int IndentSize { set; } // 0x0000000181B88120-0x0000000181B881E0
		[ComVisible(false)]
		public TraceFilter Filter { get; } // 0x000000018031E110-0x000000018031E120 
		protected bool NeedIndent { get; set; } // 0x000000018153BC50-0x000000018153BC60 0x0000000181706050-0x0000000181706060
		[ComVisible(false)]
		public TraceOptions TraceOutputOptions { get; } // 0x0000000180C4F680-0x0000000180C4F690 
	
		// Constructors
		protected TraceListener(string name); // 0x0000000181B880C0-0x0000000181B88100
	
		// Methods
		public void Dispose(); // 0x0000000181B87590-0x0000000181B87600
		protected virtual void Dispose(bool disposing); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual void Flush(); // 0x00000001802E76C0-0x00000001802E76D0
		public abstract void Write(string message);
		protected virtual void WriteIndent(); // 0x0000000181B88010-0x0000000181B880C0
		public abstract void WriteLine(string message);
		[ComVisible(false)]
		public virtual void TraceEvent(TraceEventCache eventCache, string source, TraceEventType eventType, int id, string message); // 0x0000000181B87610-0x0000000181B877A0
		private void WriteHeader(string source, TraceEventType eventType, int id); // 0x0000000181B87F10-0x0000000181B88010
		private void WriteFooter(TraceEventCache eventCache); // 0x0000000181B877A0-0x0000000181B87F10
		internal bool IsEnabled(TraceOptions opts); // 0x0000000181B87600-0x0000000181B87610
	}
}
