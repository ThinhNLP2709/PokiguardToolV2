/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml.Schema
{
	internal sealed class ParticleContentValidator : ContentValidator // TypeDefIndex: 7036
	{
		// Fields
		private SymbolsDictionary symbols; // 0x18
		private Positions positions; // 0x20
		private Stack stack; // 0x28
		private SyntaxTreeNode contentNode; // 0x30
		private bool isPartial; // 0x38
		private int minMaxNodesCount; // 0x3C
		private bool enableUpaCheck; // 0x40
	
		// Constructors
		public ParticleContentValidator(XmlSchemaContentType contentType); // 0x0000000181AD1930-0x0000000181AD1990
		public ParticleContentValidator(XmlSchemaContentType contentType, bool enableUpaCheck); // 0x0000000181AD1990-0x0000000181AD1A00
	
		// Methods
		public override void InitValidation(ValidationState context); // 0x0000000181AD16E0-0x0000000181AD1720
		public override object ValidateElement(XmlQualifiedName name, ValidationState context, out int errorCode); // 0x0000000181AD18F0-0x0000000181AD1930
		public override bool CompleteValidation(ValidationState context); // 0x0000000181AD0190-0x0000000181AD01D0
		public void Start(); // 0x0000000181AD1750-0x0000000181AD18F0
		public void OpenGroup(); // 0x0000000181AD1720-0x0000000181AD1750
		public void CloseGroup(); // 0x0000000181ACFE10-0x0000000181ACFFC0
		public bool Exists(XmlQualifiedName name); // 0x0000000181AD01D0-0x0000000181AD0210
		public void AddName(XmlQualifiedName name, object particle); // 0x0000000181ACEA20-0x0000000181ACEAD0
		public void AddNamespaceList(NamespaceList namespaceList, object particle); // 0x0000000181ACEAD0-0x0000000181ACEB90
		private void AddLeafNode(SyntaxTreeNode node); // 0x0000000181ACE830-0x0000000181ACE930
		public void AddChoice(); // 0x0000000181ACE730-0x0000000181ACE830
		public void AddSequence(); // 0x0000000181ACEC50-0x0000000181ACED50
		public void AddStar(); // 0x0000000181ACED50-0x0000000181ACEDB0
		public void AddPlus(); // 0x0000000181ACEB90-0x0000000181ACEBF0
		public void AddQMark(); // 0x0000000181ACEBF0-0x0000000181ACEC50
		public void AddLeafRange(decimal min, decimal max); // 0x0000000181ACE930-0x0000000181ACEA20
		private void Closure(InteriorNode node); // 0x0000000181ACFFC0-0x0000000181AD0190
		public ContentValidator Finish(bool useDFA); // 0x0000000181AD0210-0x0000000181AD12B0
		private BitSet[] CalculateTotalFollowposForRangeNodes(BitSet firstpos, BitSet[] followpos, out BitSet posWithRangeTerminals); // 0x0000000181ACF450-0x0000000181ACF890
		private void CheckCMUPAWithLeafRangeNodes(BitSet curpos); // 0x0000000181ACF890-0x0000000181ACFAC0
		private BitSet GetApplicableMinMaxFollowPos(BitSet curpos, BitSet posWithRangeTerminals, BitSet[] minmaxFollowPos); // 0x0000000181AD12B0-0x0000000181AD16E0
		private void CheckUniqueParticleAttribution(BitSet firstpos, BitSet[] followpos); // 0x0000000181ACFD50-0x0000000181ACFE10
		private void CheckUniqueParticleAttribution(BitSet curpos); // 0x0000000181ACFAC0-0x0000000181ACFD50
		private int[][] BuildTransitionTable(BitSet firstpos, BitSet[] followpos, int endMarkerPos); // 0x0000000181ACEDB0-0x0000000181ACF450
	}
}
