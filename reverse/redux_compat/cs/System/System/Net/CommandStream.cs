/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Net
{
	internal class CommandStream : NetworkStreamWrapper // TypeDefIndex: 9007
	{
		// Fields
		private static readonly AsyncCallback s_writeCallbackDelegate; // 0x00
		private static readonly AsyncCallback s_readCallbackDelegate; // 0x08
		private bool _recoverableFailure; // 0x38
		protected WebRequest _request; // 0x40
		protected bool _isAsync; // 0x48
		private bool _aborted; // 0x49
		protected PipelineEntry[] _commands; // 0x50
		protected int _index; // 0x58
		private bool _doRead; // 0x5C
		private bool _doSend; // 0x5D
		private ResponseDescription _currentResponseDescription; // 0x60
		protected string _abortReason; // 0x68
		private string _buffer; // 0x70
		private Encoding _encoding; // 0x78
		private Decoder _decoder; // 0x80
	
		// Properties
		internal bool RecoverableFailure { get; } // 0x0000000180476380-0x0000000180476390 
		protected Encoding Encoding { get; set; } // 0x000000018033D4E0-0x000000018033D4F0 0x0000000181BE0DB0-0x0000000181BE0E10
	
		// Nested types
		internal enum PipelineInstruction // TypeDefIndex: 9008
		{
			Abort = 0,
			Advance = 1,
			Pause = 2,
			Reread = 3,
			GiveStream = 4
		}
	
		[Flags]
		internal enum PipelineEntryFlags // TypeDefIndex: 9009
		{
			UserCommand = 1,
			GiveDataStream = 2,
			CreateDataConnection = 4,
			DontLogParameter = 8
		}
	
		internal class PipelineEntry // TypeDefIndex: 9010
		{
			// Fields
			internal string Command; // 0x10
			internal PipelineEntryFlags Flags; // 0x18
	
			// Constructors
			internal PipelineEntry(string command); // 0x00000001803855F0-0x0000000180385630
			internal PipelineEntry(string command, PipelineEntryFlags flags); // 0x0000000180E02950-0x0000000180E029A0
	
			// Methods
			internal bool HasFlag(PipelineEntryFlags flags); // 0x0000000181BF3C20-0x0000000181BF3C30
		}
	
		// Constructors
		internal CommandStream(TcpClient client); // 0x0000000181BE0CD0-0x0000000181BE0DB0
		static CommandStream(); // 0x0000000181BE0BE0-0x0000000181BE0CD0
	
		// Methods
		internal virtual void Abort(Exception e); // 0x0000000181BDF0A0-0x0000000181BDF2A0
		protected override void Dispose(bool disposing); // 0x0000000181BDF820-0x0000000181BDF8A0
		protected void InvokeRequestCallback(object obj); // 0x0000000181BDFA70-0x0000000181BDFB00
		protected void MarkAsRecoverableFailure(); // 0x0000000181BDFB00-0x0000000181BDFB10
		internal Stream SubmitRequest(WebRequest request, bool isAsync, bool readInitalResponseOnConnect); // 0x0000000181BE09B0-0x0000000181BE0A50
		protected virtual void ClearState(); // 0x0000000181BDF2E0-0x0000000181BDF300
		protected virtual PipelineEntry[] BuildCommandsList(WebRequest request); // 0x00000001802E7860-0x00000001802E7870
		protected Exception GenerateException(string message, WebExceptionStatus status, Exception innerException); // 0x0000000181BDF950-0x0000000181BDF9D0
		protected Exception GenerateException(FtpStatusCode code, string statusDescription, Exception innerException); // 0x0000000181BDF8A0-0x0000000181BDF950
		protected void InitCommandPipeline(WebRequest request, PipelineEntry[] commands, bool isAsync); // 0x0000000181BDF9D0-0x0000000181BDFA70
		internal void CheckContinuePipeline(); // 0x0000000181BDF2A0-0x0000000181BDF2E0
		protected Stream ContinueCommandPipeline(); // 0x0000000181BDF300-0x0000000181BDF820
		private bool PostSendCommandProcessing(ref Stream stream); // 0x0000000181BDFD30-0x0000000181BDFE20
		private bool PostReadCommandProcessing(ref Stream stream); // 0x0000000181BDFB10-0x0000000181BDFD30
		protected virtual PipelineInstruction PipelineCallback(PipelineEntry entry, ResponseDescription response, bool timeout, ref Stream stream); // 0x00000001802E7860-0x00000001802E7870
		private static void ReadCallback(IAsyncResult asyncResult); // 0x0000000181BDFE20-0x0000000181BE0010
		private static void WriteCallback(IAsyncResult asyncResult); // 0x0000000181BE0A50-0x0000000181BE0BE0
		protected virtual bool CheckValid(ResponseDescription response, ref int validThrough, ref int completeLength); // 0x00000001802E7840-0x00000001802E7850
		private ResponseDescription ReceiveCommandResponse(); // 0x0000000181BE0650-0x0000000181BE09B0
		private void ReceiveCommandResponseCallback(ReceiveState state, int bytesRead); // 0x0000000181BE0010-0x0000000181BE0650
	}
}
