/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 14: System.Core.dll - Assembly: System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 11955-12609

namespace System.Linq.Expressions.Interpreter
{
	[DebuggerTypeProxy(typeof(DebugView))]
	internal sealed class InstructionList // TypeDefIndex: 12301
	{
		// Fields
		private readonly List<Instruction> _instructions; // 0x10
		private List<object> _objects; // 0x18
		private int _currentStackDepth; // 0x20
		private int _maxStackDepth; // 0x24
		private int _currentContinuationsDepth; // 0x28
		private int _maxContinuationDepth; // 0x2C
		private int _runtimeLabelCount; // 0x30
		private List<BranchLabel> _labels; // 0x38
		private List<KeyValuePair<int, object>> _debugCookies; // 0x40
		private static Instruction s_null; // 0x00
		private static Instruction s_true; // 0x08
		private static Instruction s_false; // 0x10
		private static Instruction[] s_Ints; // 0x18
		private static Instruction[] s_loadObjectCached; // 0x20
		private static Instruction[] s_loadLocal; // 0x28
		private static Instruction[] s_loadLocalBoxed; // 0x30
		private static Instruction[] s_loadLocalFromClosure; // 0x38
		private static Instruction[] s_loadLocalFromClosureBoxed; // 0x40
		private static Instruction[] s_assignLocal; // 0x48
		private static Instruction[] s_storeLocal; // 0x50
		private static Instruction[] s_assignLocalBoxed; // 0x58
		private static Instruction[] s_storeLocalBoxed; // 0x60
		private static Instruction[] s_assignLocalToClosure; // 0x68
		private static readonly Dictionary<FieldInfo, Instruction> s_loadFields; // 0x70
		private static readonly RuntimeLabel[] s_emptyRuntimeLabels; // 0x78
	
		// Properties
		public int Count { get; } // 0x0000000180B5F570-0x0000000180B5F590 
		public int CurrentStackDepth { get; } // 0x0000000180C4F680-0x0000000180C4F690 
		public int CurrentContinuationsDepth { get; } // 0x0000000180377930-0x0000000180377940 
	
		// Nested types
		internal sealed class DebugView // TypeDefIndex: 12302
		{
			// Nested types
			[DebuggerDisplay("{GetValue(),nq}", Name = "{GetName(),nq}", Type = "{GetDisplayType(), nq}")]
			[IsReadOnly]
			internal struct InstructionView // TypeDefIndex: 12303
			{
				// Fields
				private readonly int _index; // 0x00
				private readonly int _stackDepth; // 0x04
				private readonly int _continuationsDepth; // 0x08
				private readonly string _name; // 0x10
				private readonly Instruction _instruction; // 0x18
	
				// Constructors
				public InstructionView(Instruction instruction, string name, int index, int stackDepth, int continuationsDepth); // 0x00000001817CF7B0-0x00000001817CF810
	
				// Methods
				internal string GetValue(); // 0x0000000180377550-0x0000000180377560
			}
	
			// Methods
			internal static InstructionView[] GetInstructionViews(IReadOnlyList<Instruction> instructions, IReadOnlyList<object> objects, Func<int, int> labelIndexer, IReadOnlyList<KeyValuePair<int, object>> debugCookies); // 0x00000001817C5760-0x00000001817C5B30
		}
	
		// Constructors
		public InstructionList(); // 0x00000001817CF730-0x00000001817CF7B0
		static InstructionList(); // 0x00000001817CF600-0x00000001817CF730
	
		// Methods
		public void Emit(Instruction instruction); // 0x00000001817CE7B0-0x00000001817CE8F0
		private void UpdateStackDepth(Instruction instruction); // 0x00000001817CF540-0x00000001817CF600
		public void UnEmit(); // 0x00000001817CF460-0x00000001817CF540
		internal Instruction GetInstruction(int index); // 0x0000000180CAFA00-0x0000000180CAFA20
		public InstructionArray ToArray(); // 0x00000001817CF330-0x00000001817CF460
		public void EmitLoad(object value); // 0x00000001817CD8F0-0x00000001817CD900
		public void EmitLoad(bool value); // 0x00000001817CD730-0x00000001817CD8F0
		public void EmitLoad(object value, Type type); // 0x00000001817CD1A0-0x00000001817CD730
		public void EmitDup(); // 0x00000001817CC020-0x00000001817CC080
		public void EmitPop(); // 0x00000001817CDE90-0x00000001817CDEF0
		internal void SwitchToBoxed(int index, int instructionIndex); // 0x00000001817CF290-0x00000001817CF330
		public void EmitLoadLocal(int index); // 0x00000001817CCFF0-0x00000001817CD1A0
		public void EmitLoadLocalBoxed(int index); // 0x00000001817CCAB0-0x00000001817CCC90
		internal static Instruction LoadLocalBoxed(int index); // 0x00000001817CECE0-0x00000001817CEE80
		public void EmitLoadLocalFromClosure(int index); // 0x00000001817CCE40-0x00000001817CCFF0
		public void EmitLoadLocalFromClosureBoxed(int index); // 0x00000001817CCC90-0x00000001817CCE40
		public void EmitAssignLocal(int index); // 0x00000001817CB630-0x00000001817CB7E0
		public void EmitStoreLocal(int index); // 0x00000001817CE340-0x00000001817CE4F0
		public void EmitAssignLocalBoxed(int index); // 0x00000001817CB2A0-0x00000001817CB480
		internal static Instruction AssignLocalBoxed(int index); // 0x00000001817CADF0-0x00000001817CAF90
		public void EmitStoreLocalBoxed(int index); // 0x00000001817CE0F0-0x00000001817CE2D0
		internal static Instruction StoreLocalBoxed(int index); // 0x00000001817CF0F0-0x00000001817CF290
		public void EmitAssignLocalToClosure(int index); // 0x00000001817CB480-0x00000001817CB630
		public void EmitStoreLocalToClosure(int index); // 0x00000001817CE2D0-0x00000001817CE340
		public void EmitInitializeLocal(int index, Type type); // 0x00000001817CC630-0x00000001817CC770
		internal void EmitInitializeParameter(int index); // 0x00000001817CC770-0x00000001817CC810
		internal static Instruction Parameter(int index); // 0x00000001817CF090-0x00000001817CF0F0
		internal static Instruction ParameterBox(int index); // 0x00000001817CF030-0x00000001817CF090
		internal static Instruction InitReference(int index); // 0x00000001817CEC80-0x00000001817CECE0
		internal static Instruction InitImmutableRefBox(int index); // 0x00000001817CEC20-0x00000001817CEC80
		public void EmitNewRuntimeVariables(int count); // 0x00000001817CDB40-0x00000001817CDBB0
		public void EmitGetArrayItem(); // 0x00000001817CC460-0x00000001817CC4C0
		public void EmitSetArrayItem(); // 0x00000001817CDFE0-0x00000001817CE040
		public void EmitNewArray(Type elementType); // 0x00000001817CDAD0-0x00000001817CDB40
		public void EmitNewArrayBounds(Type elementType, int rank); // 0x00000001817CD9D0-0x00000001817CDA50
		public void EmitNewArrayInit(Type elementType, int elementCount); // 0x00000001817CDA50-0x00000001817CDAD0
		public void EmitAdd(Type type, bool @checked); // 0x00000001817CB1D0-0x00000001817CB210
		public void EmitSub(Type type, bool @checked); // 0x00000001817CE570-0x00000001817CE5B0
		public void EmitMul(Type type, bool @checked); // 0x00000001817CD930-0x00000001817CD970
		public void EmitDiv(Type type); // 0x00000001817CBFF0-0x00000001817CC020
		public void EmitModulo(Type type); // 0x00000001817CD900-0x00000001817CD930
		public void EmitExclusiveOr(Type type); // 0x00000001817CC430-0x00000001817CC460
		public void EmitAnd(Type type); // 0x00000001817CB210-0x00000001817CB240
		public void EmitOr(Type type); // 0x00000001817CDE60-0x00000001817CDE90
		public void EmitLeftShift(Type type); // 0x00000001817CC9D0-0x00000001817CCA00
		public void EmitRightShift(Type type); // 0x00000001817CDFB0-0x00000001817CDFE0
		public void EmitEqual(Type type, bool liftedToNull = false /* Metadata: 0x006A25C4 */); // 0x00000001817CC3F0-0x00000001817CC430
		public void EmitNotEqual(Type type, bool liftedToNull = false /* Metadata: 0x006A25C5 */); // 0x00000001817CDC40-0x00000001817CDC80
		public void EmitLessThan(Type type, bool liftedToNull); // 0x00000001817CCA40-0x00000001817CCA80
		public void EmitLessThanOrEqual(Type type, bool liftedToNull); // 0x00000001817CCA00-0x00000001817CCA40
		public void EmitGreaterThan(Type type, bool liftedToNull); // 0x00000001817CC5C0-0x00000001817CC600
		public void EmitGreaterThanOrEqual(Type type, bool liftedToNull); // 0x00000001817CC580-0x00000001817CC5C0
		public void EmitNumericConvertChecked(TypeCode from, TypeCode to, bool isLiftedToNull); // 0x00000001817CDD20-0x00000001817CDDC0
		public void EmitNumericConvertUnchecked(TypeCode from, TypeCode to, bool isLiftedToNull); // 0x00000001817CDDC0-0x00000001817CDE60
		public void EmitConvertToUnderlying(TypeCode to, bool isLiftedToNull); // 0x00000001817CBE60-0x00000001817CBEE0
		public void EmitCast(Type toType); // 0x00000001817CBDA0-0x00000001817CBDD0
		public void EmitCastToEnum(Type toType); // 0x00000001817CBD30-0x00000001817CBDA0
		public void EmitCastReferenceToEnum(Type toType); // 0x00000001817CBCC0-0x00000001817CBD30
		public void EmitNot(Type type); // 0x00000001817CDC80-0x00000001817CDCB0
		public void EmitDefaultValue(Type type); // 0x00000001817CBF80-0x00000001817CBFF0
		public void EmitNew(ConstructorInfo constructorInfo, ParameterInfo[] parameters); // 0x00000001817CDBB0-0x00000001817CDC40
		public void EmitByRefNew(ConstructorInfo constructorInfo, ParameterInfo[] parameters, ByRefUpdater[] updaters); // 0x00000001817CBB60-0x00000001817CBC10
		internal void EmitCreateDelegate(LightDelegateCreator creator); // 0x00000001817CBEE0-0x00000001817CBF50
		public void EmitTypeEquals(); // 0x00000001817CE6E0-0x00000001817CE740
		public void EmitArrayLength(); // 0x00000001817CB240-0x00000001817CB2A0
		public void EmitNegate(Type type); // 0x00000001817CD9A0-0x00000001817CD9D0
		public void EmitNegateChecked(Type type); // 0x00000001817CD970-0x00000001817CD9A0
		public void EmitIncrement(Type type); // 0x00000001817CC600-0x00000001817CC630
		public void EmitDecrement(Type type); // 0x00000001817CBF50-0x00000001817CBF80
		public void EmitTypeIs(Type type); // 0x00000001817CE740-0x00000001817CE7B0
		public void EmitTypeAs(Type type); // 0x00000001817CE670-0x00000001817CE6E0
		public void EmitLoadField(FieldInfo field); // 0x00000001817CCA80-0x00000001817CCAB0
		private Instruction GetLoadField(FieldInfo field); // 0x00000001817CE9F0-0x00000001817CEC20
		public void EmitStoreField(FieldInfo field); // 0x00000001817CE040-0x00000001817CE0F0
		public void EmitCall(MethodInfo method); // 0x00000001817CBC40-0x00000001817CBCC0
		public void EmitCall(MethodInfo method, ParameterInfo[] parameters); // 0x00000001817CBC10-0x00000001817CBC40
		public void EmitByRefCall(MethodInfo method, ParameterInfo[] parameters, ByRefUpdater[] byrefArgs); // 0x00000001817CBAA0-0x00000001817CBB60
		public void EmitNullableCall(MethodInfo method, ParameterInfo[] parameters); // 0x00000001817CDCB0-0x00000001817CDD20
		private RuntimeLabel[] BuildRuntimeLabels(); // 0x00000001817CAF90-0x00000001817CB1D0
		public BranchLabel MakeLabel(); // 0x00000001817CEE80-0x00000001817CEFA0
		internal void FixupBranch(int branchIndex, int offset); // 0x00000001817CE930-0x00000001817CE9F0
		private int EnsureLabelIndex(BranchLabel label); // 0x00000001817CE8F0-0x00000001817CE930
		public int MarkRuntimeLabel(); // 0x00000001817CEFD0-0x00000001817CF030
		public void MarkLabel(BranchLabel label); // 0x00000001817CEFA0-0x00000001817CEFD0
		public void EmitGoto(BranchLabel label, bool hasResult, bool hasValue, bool labelTargetGetsValue); // 0x00000001817CC4C0-0x00000001817CC580
		private void EmitBranch(OffsetInstruction instruction, BranchLabel label); // 0x00000001817CBA50-0x00000001817CBAA0
		public void EmitBranch(BranchLabel label); // 0x00000001817CB900-0x00000001817CB990
		public void EmitBranch(BranchLabel label, bool hasResult, bool hasValue); // 0x00000001817CB990-0x00000001817CBA50
		public void EmitCoalescingBranch(BranchLabel leftNotNull); // 0x00000001817CBDD0-0x00000001817CBE60
		public void EmitBranchTrue(BranchLabel elseLabel); // 0x00000001817CB870-0x00000001817CB900
		public void EmitBranchFalse(BranchLabel elseLabel); // 0x00000001817CB7E0-0x00000001817CB870
		public void EmitThrow(); // 0x00000001817CE610-0x00000001817CE670
		public void EmitThrowVoid(); // 0x00000001817CE5B0-0x00000001817CE610
		public void EmitRethrow(); // 0x00000001817CDF50-0x00000001817CDFB0
		public void EmitRethrowVoid(); // 0x00000001817CDEF0-0x00000001817CDF50
		public void EmitEnterTryFinally(BranchLabel finallyStartLabel); // 0x00000001817CC390-0x00000001817CC3F0
		public void EmitEnterTryCatch(); // 0x00000001817CC2C0-0x00000001817CC2F0
		public EnterTryFaultInstruction EmitEnterTryFault(BranchLabel tryEnd); // 0x00000001817CC2F0-0x00000001817CC390
		public void EmitEnterFinally(BranchLabel finallyStartLabel); // 0x00000001817CC230-0x00000001817CC2C0
		public void EmitLeaveFinally(); // 0x00000001817CC970-0x00000001817CC9D0
		public void EmitEnterFault(BranchLabel faultStartLabel); // 0x00000001817CC1A0-0x00000001817CC230
		public void EmitLeaveFault(); // 0x00000001817CC910-0x00000001817CC970
		public void EmitEnterExceptionFilter(); // 0x00000001817CC080-0x00000001817CC0E0
		public void EmitLeaveExceptionFilter(); // 0x00000001817CC810-0x00000001817CC870
		public void EmitEnterExceptionHandlerNonVoid(); // 0x00000001817CC0E0-0x00000001817CC140
		public void EmitEnterExceptionHandlerVoid(); // 0x00000001817CC140-0x00000001817CC1A0
		public void EmitLeaveExceptionHandler(bool hasValue, BranchLabel tryExpressionEndLabel); // 0x00000001817CC870-0x00000001817CC910
		public void EmitIntSwitch<T>(Dictionary<T, int> cases);
		public void EmitStringSwitch(Dictionary<string, int> cases, StrongBox<int> nullCase); // 0x00000001817CE4F0-0x00000001817CE570
	}
}
