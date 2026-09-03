/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.IO
{
	[Serializable]
	public abstract class TextReader : MarshalByRefObject, IDisposable // TypeDefIndex: 3663
	{
		// Fields
		public static readonly TextReader Null; // 0x00
	
		// Nested types
		[Serializable]
		private sealed class NullTextReader : TextReader // TypeDefIndex: 3664
		{
			// Constructors
			public NullTextReader(); // 0x00000001815C85F0-0x00000001815C8640
	
			// Methods
			public override int Read(char[] buffer, int index, int count); // 0x00000001802E7860-0x00000001802E7870
			public override string ReadLine(); // 0x00000001802E7860-0x00000001802E7870
		}
	
		[Serializable]
		internal sealed class SyncTextReader : TextReader // TypeDefIndex: 3665
		{
			// Fields
			internal readonly TextReader _in; // 0x18
	
			// Constructors
			internal SyncTextReader(TextReader t); // 0x00000001815D1530-0x00000001815D15A0
	
			// Methods
			public override void Close(); // 0x00000001815D1210-0x00000001815D1240
			protected override void Dispose(bool disposing); // 0x00000001815D1240-0x00000001815D12A0
			public override int Peek(); // 0x000000018143A8B0-0x000000018143A8E0
			public override int Read(); // 0x00000001815D1500-0x00000001815D1530
			public override int Read(char[] buffer, int index, int count); // 0x00000001815D14D0-0x00000001815D1500
			public override string ReadLine(); // 0x00000001815D1470-0x00000001815D14A0
			public override string ReadToEnd(); // 0x00000001815D14A0-0x00000001815D14D0
			public override Task<int> ReadAsync(char[] buffer, int index, int count); // 0x00000001815D12A0-0x00000001815D1470
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 3666
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Func<object, int> __9__17_0; // 0x08
	
			// Constructors
			static __c(); // 0x00000001815D51B0-0x00000001815D5220
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal int _ReadAsyncInternal_b__17_0(object state); // 0x00000001815D4E10-0x00000001815D4EE0
		}
	
		// Constructors
		protected TextReader(); // 0x00000001802E5CB0-0x00000001802E5CC0
		static TextReader(); // 0x00000001815D29A0-0x00000001815D2A50
	
		// Methods
		public virtual void Close(); // 0x00000001815D1D30-0x00000001815D1DA0
		public void Dispose(); // 0x00000001815D1DA0-0x00000001815D1E10
		protected virtual void Dispose(bool disposing); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual int Peek(); // 0x00000001815418D0-0x00000001815418E0
		public virtual int Read(); // 0x00000001815418D0-0x00000001815418E0
		public virtual int Read(char[] buffer, int index, int count); // 0x00000001815D2680-0x00000001815D28A0
		public virtual int Read(Span<char> buffer); // 0x00000001815D2440-0x00000001815D2680
		public virtual string ReadToEnd(); // 0x00000001815D2350-0x00000001815D2440
		public virtual string ReadLine(); // 0x00000001815D2250-0x00000001815D2350
		public virtual Task<int> ReadAsync(char[] buffer, int index, int count); // 0x00000001815D2040-0x00000001815D2250
		internal virtual ValueTask<int> ReadAsyncInternal(Memory<char> buffer, CancellationToken cancellationToken); // 0x00000001815D1E10-0x00000001815D2040
		public static TextReader Synchronized(TextReader reader); // 0x00000001815D28A0-0x00000001815D29A0
	}
}
