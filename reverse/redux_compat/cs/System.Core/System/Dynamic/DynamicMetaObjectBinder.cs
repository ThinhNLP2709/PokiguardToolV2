/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 14: System.Core.dll - Assembly: System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 11955-12609

namespace System.Dynamic
{
	public abstract class DynamicMetaObjectBinder : CallSiteBinder // TypeDefIndex: 12563
	{
		// Properties
		public virtual Type ReturnType { get; } // 0x0000000181742460-0x00000001817424A0 
		internal virtual bool IsStandardBinder { get; } // 0x00000001802E7840-0x00000001802E7850 
	
		// Constructors
		protected DynamicMetaObjectBinder(); // 0x00000001817EC480-0x00000001817EC4D0
	
		// Methods
		public sealed override Expression Bind(object[] args, ReadOnlyCollection<ParameterExpression> parameters, LabelTarget returnLabel); // 0x00000001817EB910-0x00000001817EC200
		private static DynamicMetaObject[] CreateArgumentMetaObjects(object[] args, ReadOnlyCollection<ParameterExpression> parameters); // 0x00000001817EC200-0x00000001817EC3B0
		public abstract DynamicMetaObject Bind(DynamicMetaObject target, DynamicMetaObject[] args);
		public Expression GetUpdateExpression(Type type); // 0x00000001817EC3B0-0x00000001817EC480
	}
}
