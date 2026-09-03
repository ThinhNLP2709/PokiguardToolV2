/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.IO
{
	[Serializable]
	public abstract class TextWriter : MarshalByRefObject, IDisposable // TypeDefIndex: 3667
	{
		// Fields
		public static readonly TextWriter Null; // 0x00
		private static readonly char[] s_coreNewLine; // 0x08
		protected char[] CoreNewLine; // 0x18
		private string CoreNewLineStr; // 0x20
		private IFormatProvider _internalFormatProvider; // 0x28
	
		// Properties
		public virtual IFormatProvider FormatProvider { get; } // 0x00000001815D3BD0-0x00000001815D3C10 
		public abstract Encoding Encoding { get; }
		public virtual string NewLine { get; } // 0x00000001802F8630-0x00000001802F8640 
	
		// Nested types
		[Serializable]
		private sealed class NullTextWriter : TextWriter // TypeDefIndex: 3668
		{
			// Properties
			public override Encoding Encoding { get; } // 0x00000001815B16F0-0x00000001815B1700 
	
			// Constructors
			internal NullTextWriter(); // 0x00000001815C8640-0x00000001815C86C0
	
			// Methods
			public override void Write(char[] buffer, int index, int count); // 0x00000001802E76C0-0x00000001802E76D0
			public override void Write(string value); // 0x00000001802E76C0-0x00000001802E76D0
			public override void WriteLine(); // 0x00000001802E76C0-0x00000001802E76D0
			public override void WriteLine(string value); // 0x00000001802E76C0-0x00000001802E76D0
			public override void Write(char value); // 0x00000001802E76C0-0x00000001802E76D0
		}
	
		[Serializable]
		internal sealed class SyncTextWriter : TextWriter, IDisposable // TypeDefIndex: 3669
		{
			// Fields
			private readonly TextWriter _out; // 0x30
	
			// Properties
			public override Encoding Encoding { get; } // 0x00000001815D1AC0-0x00000001815D1AF0 
			public override IFormatProvider FormatProvider { get; } // 0x0000000181506D00-0x0000000181506D30 
			public override string NewLine { get; } // 0x00000001815D1AF0-0x00000001815D1B20 
	
			// Constructors
			internal SyncTextWriter(TextWriter t); // 0x00000001815D1A30-0x00000001815D1AC0
	
			// Methods
			public override void Close(); // 0x00000001815D15A0-0x00000001815D15D0
			protected override void Dispose(bool disposing); // 0x00000001815D15D0-0x00000001815D1630
			public override void Flush(); // 0x00000001815D16E0-0x00000001815D1710
			public override void Write(char value); // 0x0000000181506B30-0x0000000181506B60
			public override void Write(char[] buffer); // 0x0000000181506B60-0x0000000181506B90
			public override void Write(char[] buffer, int index, int count); // 0x00000001815D1A00-0x00000001815D1A30
			public override void Write(string value); // 0x0000000181506D30-0x0000000181506D60
			public override void WriteLine(); // 0x00000001815D19D0-0x00000001815D1A00
			public override void WriteLine(string value); // 0x0000000181506D60-0x0000000181506D90
			public override void WriteLine(string format, object arg0); // 0x00000001815D1970-0x00000001815D19A0
			public override void WriteLine(string format, object arg0, object arg1, object arg2); // 0x00000001815D19A0-0x00000001815D19D0
			public override Task WriteAsync(char value); // 0x00000001815D18B0-0x00000001815D1970
			public override Task WriteAsync(string value); // 0x00000001815D17F0-0x00000001815D18B0
			public override Task WriteAsync(char[] buffer, int index, int count); // 0x00000001815D1710-0x00000001815D17F0
			public override Task FlushAsync(); // 0x00000001815D1630-0x00000001815D16E0
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 3670
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Action<object> __9__56_0; // 0x08
			public static Action<object> __9__57_0; // 0x10
			public static Action<object> __9__59_0; // 0x18
			public static Action<object> __9__67_0; // 0x20
	
			// Constructors
			static __c(); // 0x00000001815D5140-0x00000001815D51B0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _WriteAsync_b__56_0(object state); // 0x00000001815D4F50-0x00000001815D4FE0
			internal void _WriteAsync_b__57_0(object state); // 0x00000001815D4FE0-0x00000001815D5070
			internal void _WriteAsync_b__59_0(object state); // 0x00000001815D5070-0x00000001815D5110
			internal void _FlushAsync_b__67_0(object state); // 0x00000001815D4D90-0x00000001815D4E10
		}
	
		// Constructors
		protected TextWriter(); // 0x00000001815D3A90-0x00000001815D3B30
		protected TextWriter(IFormatProvider formatProvider); // 0x00000001815D3B30-0x00000001815D3BD0
		static TextWriter(); // 0x00000001815D3970-0x00000001815D3A90
	
		// Methods
		public virtual void Close(); // 0x00000001815D2A50-0x00000001815D2AC0
		protected virtual void Dispose(bool disposing); // 0x00000001802E76C0-0x00000001802E76D0
		public void Dispose(); // 0x00000001815D2AC0-0x00000001815D2B30
		public virtual void Flush(); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual void Write(char value); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual void Write(char[] buffer); // 0x00000001815D36F0-0x00000001815D3720
		public virtual void Write(char[] buffer, int index, int count); // 0x00000001815D3720-0x00000001815D3930
		public virtual void Write(string value); // 0x00000001815D3930-0x00000001815D3970
		public virtual void WriteLine(); // 0x00000001815D3660-0x00000001815D3680
		public virtual void WriteLine(string value); // 0x00000001815D3580-0x00000001815D35D0
		public virtual void WriteLine(string format, object arg0); // 0x00000001815D3680-0x00000001815D36F0
		public virtual void WriteLine(string format, object arg0, object arg1, object arg2); // 0x00000001815D35D0-0x00000001815D3660
		public virtual Task WriteAsync(char value); // 0x00000001815D2E70-0x00000001815D30C0
		public virtual Task WriteAsync(string value); // 0x00000001815D3330-0x00000001815D3580
		public virtual Task WriteAsync(char[] buffer, int index, int count); // 0x00000001815D30C0-0x00000001815D3330
		public virtual Task FlushAsync(); // 0x00000001815D2B30-0x00000001815D2D50
		public static TextWriter Synchronized(TextWriter writer); // 0x00000001815D2D50-0x00000001815D2E70
	}
}
