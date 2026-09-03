/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 11: System.Data.dll - Assembly: System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 11180-11419

namespace System.Data
{
	internal sealed class LikeNode : BinaryNode // TypeDefIndex: 11272
	{
		// Fields
		private int _kind; // 0x30
		private string _pattern; // 0x38
	
		// Constructors
		internal LikeNode(DataTable table, int op, ExpressionNode left, ExpressionNode right); // 0x0000000181884120-0x0000000181884190
	
		// Methods
		internal override object Eval(DataRow row, DataRowVersion version); // 0x00000001818902C0-0x0000000181890840
		internal string AnalyzePattern(string pat); // 0x000000018188FF80-0x00000001818902C0
	}
}
