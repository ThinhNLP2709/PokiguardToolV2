/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	internal class ResolvedStyleAccessPropertyBag : PropertyBag<ResolvedStyleAccess>, INamedProperties<ResolvedStyleAccess> // TypeDefIndex: 4510
	{
		// Fields
		private readonly List<IProperty<ResolvedStyleAccess>> m_PropertiesList; // 0x18
		private readonly Dictionary<string, IProperty<ResolvedStyleAccess>> m_PropertiesHash; // 0x20
	
		// Nested types
		private class AlignContentProperty : ResolvedEnumProperty<Align> // TypeDefIndex: 4511
		{
			// Properties
			public override string Name { get; } // 0x000000018251C640-0x000000018251C670 
			public override string ussName { get; } // 0x000000018251C6A0-0x000000018251C6D0 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public AlignContentProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override Align GetValue(ref ResolvedStyleAccess container); // 0x000000018251C4D0-0x000000018251C520
			public override void SetValue(ref ResolvedStyleAccess container, Align value); // 0x000000018251C570-0x000000018251C5B0
		}
	
		private class AlignItemsProperty : ResolvedEnumProperty<Align> // TypeDefIndex: 4512
		{
			// Properties
			public override string Name { get; } // 0x000000018251C840-0x000000018251C870 
			public override string ussName { get; } // 0x000000018251C8A0-0x000000018251C8D0 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public AlignItemsProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override Align GetValue(ref ResolvedStyleAccess container); // 0x000000018251C6D0-0x000000018251C720
			public override void SetValue(ref ResolvedStyleAccess container, Align value); // 0x000000018251C770-0x000000018251C7B0
		}
	
		private class AlignSelfProperty : ResolvedEnumProperty<Align> // TypeDefIndex: 4513
		{
			// Properties
			public override string Name { get; } // 0x000000018251CA40-0x000000018251CA70 
			public override string ussName { get; } // 0x000000018251CAA0-0x000000018251CAD0 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public AlignSelfProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override Align GetValue(ref ResolvedStyleAccess container); // 0x000000018251C920-0x000000018251C970
			public override void SetValue(ref ResolvedStyleAccess container, Align value); // 0x000000018251C970-0x000000018251C9B0
		}
	
		private class AnimationPlayStateProperty : ResolvedEnumProperty<AnimationPlayState> // TypeDefIndex: 4514
		{
			// Properties
			public override string Name { get; } // 0x000000018251CD10-0x000000018251CD40 
			public override string ussName { get; } // 0x000000018251CD40-0x000000018251CD70 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public AnimationPlayStateProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override AnimationPlayState GetValue(ref ResolvedStyleAccess container); // 0x000000018251CAD0-0x000000018251CB20
			public override void SetValue(ref ResolvedStyleAccess container, AnimationPlayState value); // 0x000000018251CBE0-0x000000018251CC20
		}
	
		private class AspectRatioProperty : ResolvedRatioProperty // TypeDefIndex: 4515
		{
			// Properties
			public override string Name { get; } // 0x000000018251D060-0x000000018251D090 
			public override string ussName { get; } // 0x000000018251D090-0x000000018251D0C0 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public AspectRatioProperty(); // 0x000000018251D020-0x000000018251D030
	
			// Methods
			public override Ratio GetValue(ref ResolvedStyleAccess container); // 0x000000018251CDA0-0x000000018251CE60
			public override void SetValue(ref ResolvedStyleAccess container, Ratio value); // 0x000000018251CFE0-0x000000018251D020
		}
	
		private class BackdropFilterProperty : ResolvedListProperty<FilterFunction> // TypeDefIndex: 4516
		{
			// Properties
			public override string Name { get; } // 0x000000018251D320-0x000000018251D350 
			public override string ussName { get; } // 0x000000018251D380-0x000000018251D3B0 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public BackdropFilterProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override IEnumerable<FilterFunction> GetValue(ref ResolvedStyleAccess container); // 0x000000018251D1C0-0x000000018251D210
			public override void SetValue(ref ResolvedStyleAccess container, IEnumerable<FilterFunction> value); // 0x000000018251D2E0-0x000000018251D320
		}
	
		private class BackgroundColorProperty : ResolvedColorProperty // TypeDefIndex: 4517
		{
			// Properties
			public override string Name { get; } // 0x000000018251D6E0-0x000000018251D710 
			public override string ussName { get; } // 0x000000018251D710-0x000000018251D740 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public BackgroundColorProperty(); // 0x000000018251D020-0x000000018251D030
	
			// Methods
			public override Color GetValue(ref ResolvedStyleAccess container); // 0x000000018251D3E0-0x000000018251D4B0
			public override void SetValue(ref ResolvedStyleAccess container, Color value); // 0x000000018251D670-0x000000018251D6B0
		}
	
		private class BackgroundImageProperty : ResolvedBackgroundProperty // TypeDefIndex: 4518
		{
			// Properties
			public override string Name { get; } // 0x000000018251DAD0-0x000000018251DB00 
			public override string ussName { get; } // 0x000000018251DB00-0x000000018251DB30 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public BackgroundImageProperty(); // 0x000000018251D020-0x000000018251D030
	
			// Methods
			public override Background GetValue(ref ResolvedStyleAccess container); // 0x000000018251D770-0x000000018251D860
			public override void SetValue(ref ResolvedStyleAccess container, Background value); // 0x000000018251D960-0x000000018251D9A0
		}
	
		private class BackgroundPositionXProperty : ResolvedBackgroundPositionProperty // TypeDefIndex: 4519
		{
			// Properties
			public override string Name { get; } // 0x000000018251DE50-0x000000018251DE80 
			public override string ussName { get; } // 0x000000018251DEB0-0x000000018251DEE0 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public BackgroundPositionXProperty(); // 0x000000018251D020-0x000000018251D030
	
			// Methods
			public override BackgroundPosition GetValue(ref ResolvedStyleAccess container); // 0x000000018251DC30-0x000000018251DD10
			public override void SetValue(ref ResolvedStyleAccess container, BackgroundPosition value); // 0x000000018251DD10-0x000000018251DD50
		}
	
		private class BackgroundPositionYProperty : ResolvedBackgroundPositionProperty // TypeDefIndex: 4520
		{
			// Properties
			public override string Name { get; } // 0x000000018251E1A0-0x000000018251E1D0 
			public override string ussName { get; } // 0x000000018251E200-0x000000018251E230 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public BackgroundPositionYProperty(); // 0x000000018251D020-0x000000018251D030
	
			// Methods
			public override BackgroundPosition GetValue(ref ResolvedStyleAccess container); // 0x000000018251DFB0-0x000000018251E090
			public override void SetValue(ref ResolvedStyleAccess container, BackgroundPosition value); // 0x000000018251E160-0x000000018251E1A0
		}
	
		private class BackgroundRepeatProperty : ResolvedBackgroundRepeatProperty // TypeDefIndex: 4521
		{
			// Properties
			public override string Name { get; } // 0x000000018251E550-0x000000018251E580 
			public override string ussName { get; } // 0x000000018251E580-0x000000018251E5B0 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public BackgroundRepeatProperty(); // 0x000000018251D020-0x000000018251D030
	
			// Methods
			public override BackgroundRepeat GetValue(ref ResolvedStyleAccess container); // 0x000000018251E340-0x000000018251E400
			public override void SetValue(ref ResolvedStyleAccess container, BackgroundRepeat value); // 0x000000018251E400-0x000000018251E440
		}
	
		private class BackgroundSizeProperty : ResolvedBackgroundSizeProperty // TypeDefIndex: 4522
		{
			// Properties
			public override string Name { get; } // 0x000000018251E8F0-0x000000018251E920 
			public override string ussName { get; } // 0x000000018251E950-0x000000018251E980 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public BackgroundSizeProperty(); // 0x000000018251D020-0x000000018251D030
	
			// Methods
			public override BackgroundSize GetValue(ref ResolvedStyleAccess container); // 0x000000018251E5E0-0x000000018251E6C0
			public override void SetValue(ref ResolvedStyleAccess container, BackgroundSize value); // 0x000000018251E880-0x000000018251E8C0
		}
	
		private class BorderBottomColorProperty : ResolvedColorProperty // TypeDefIndex: 4523
		{
			// Properties
			public override string Name { get; } // 0x000000018251EC80-0x000000018251ECB0 
			public override string ussName { get; } // 0x000000018251ECE0-0x000000018251ED10 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public BorderBottomColorProperty(); // 0x000000018251D020-0x000000018251D030
	
			// Methods
			public override Color GetValue(ref ResolvedStyleAccess container); // 0x000000018251E980-0x000000018251EA50
			public override void SetValue(ref ResolvedStyleAccess container, Color value); // 0x000000018251EB30-0x000000018251EB70
		}
	
		private class BorderBottomLeftRadiusProperty : ResolvedFloatProperty // TypeDefIndex: 4524
		{
			// Properties
			public override string Name { get; } // 0x000000018251EF90-0x000000018251EFC0 
			public override string ussName { get; } // 0x000000018251EFF0-0x000000018251F020 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public BorderBottomLeftRadiusProperty(); // 0x000000018251D020-0x000000018251D030
	
			// Methods
			public override float GetValue(ref ResolvedStyleAccess container); // 0x000000018251ED10-0x000000018251ED60
			public override void SetValue(ref ResolvedStyleAccess container, float value); // 0x000000018251EE40-0x000000018251EE80
		}
	
		private class BorderBottomRightRadiusProperty : ResolvedFloatProperty // TypeDefIndex: 4525
		{
			// Properties
			public override string Name { get; } // 0x000000018251F270-0x000000018251F2A0 
			public override string ussName { get; } // 0x000000018251F2D0-0x000000018251F300 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public BorderBottomRightRadiusProperty(); // 0x000000018251D020-0x000000018251D030
	
			// Methods
			public override float GetValue(ref ResolvedStyleAccess container); // 0x000000018251F100-0x000000018251F150
			public override void SetValue(ref ResolvedStyleAccess container, float value); // 0x000000018251F230-0x000000018251F270
		}
	
		private class BorderBottomWidthProperty : ResolvedFloatProperty // TypeDefIndex: 4526
		{
			// Properties
			public override string Name { get; } // 0x000000018251F4A0-0x000000018251F4D0 
			public override string ussName { get; } // 0x000000018251F4D0-0x000000018251F500 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public BorderBottomWidthProperty(); // 0x000000018251D020-0x000000018251D030
	
			// Methods
			public override float GetValue(ref ResolvedStyleAccess container); // 0x000000018251F380-0x000000018251F3D0
			public override void SetValue(ref ResolvedStyleAccess container, float value); // 0x000000018251F3D0-0x000000018251F410
		}
	
		private class BorderLeftColorProperty : ResolvedColorProperty // TypeDefIndex: 4527
		{
			// Properties
			public override string Name { get; } // 0x000000018251F830-0x000000018251F860 
			public override string ussName { get; } // 0x000000018251F890-0x000000018251F8C0 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public BorderLeftColorProperty(); // 0x000000018251D020-0x000000018251D030
	
			// Methods
			public override Color GetValue(ref ResolvedStyleAccess container); // 0x000000018251F530-0x000000018251F600
			public override void SetValue(ref ResolvedStyleAccess container, Color value); // 0x000000018251F6E0-0x000000018251F720
		}
	
		private class BorderLeftWidthProperty : ResolvedFloatProperty // TypeDefIndex: 4528
		{
			// Properties
			public override string Name { get; } // 0x000000018251FA00-0x000000018251FA30 
			public override string ussName { get; } // 0x000000018251FA90-0x000000018251FAC0 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public BorderLeftWidthProperty(); // 0x000000018251D020-0x000000018251D030
	
			// Methods
			public override float GetValue(ref ResolvedStyleAccess container); // 0x000000018251F910-0x000000018251F960
			public override void SetValue(ref ResolvedStyleAccess container, float value); // 0x000000018251F960-0x000000018251F9A0
		}
	
		private class BorderRightColorProperty : ResolvedColorProperty // TypeDefIndex: 4529
		{
			// Properties
			public override string Name { get; } // 0x000000018251FDC0-0x000000018251FDF0 
			public override string ussName { get; } // 0x000000018251FE20-0x000000018251FE50 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public BorderRightColorProperty(); // 0x000000018251D020-0x000000018251D030
	
			// Methods
			public override Color GetValue(ref ResolvedStyleAccess container); // 0x000000018251FAC0-0x000000018251FB90
			public override void SetValue(ref ResolvedStyleAccess container, Color value); // 0x000000018251FD50-0x000000018251FD90
		}
	
		private class BorderRightWidthProperty : ResolvedFloatProperty // TypeDefIndex: 4530
		{
			// Properties
			public override string Name { get; } // 0x000000018251FFC0-0x000000018251FFF0 
			public override string ussName { get; } // 0x000000018251FFF0-0x0000000182520020 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public BorderRightWidthProperty(); // 0x000000018251D020-0x000000018251D030
	
			// Methods
			public override float GetValue(ref ResolvedStyleAccess container); // 0x000000018251FEA0-0x000000018251FEF0
			public override void SetValue(ref ResolvedStyleAccess container, float value); // 0x000000018251FF50-0x000000018251FF90
		}
	
		private class BorderTopColorProperty : ResolvedColorProperty // TypeDefIndex: 4531
		{
			// Properties
			public override string Name { get; } // 0x0000000182520320-0x0000000182520350 
			public override string ussName { get; } // 0x00000001825203B0-0x00000001825203E0 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public BorderTopColorProperty(); // 0x000000018251D020-0x000000018251D030
	
			// Methods
			public override Color GetValue(ref ResolvedStyleAccess container); // 0x0000000182520050-0x0000000182520120
			public override void SetValue(ref ResolvedStyleAccess container, Color value); // 0x00000001825202E0-0x0000000182520320
		}
	
		private class BorderTopLeftRadiusProperty : ResolvedFloatProperty // TypeDefIndex: 4532
		{
			// Properties
			public override string Name { get; } // 0x0000000182520660-0x0000000182520690 
			public override string ussName { get; } // 0x00000001825206C0-0x00000001825206F0 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public BorderTopLeftRadiusProperty(); // 0x000000018251D020-0x000000018251D030
	
			// Methods
			public override float GetValue(ref ResolvedStyleAccess container); // 0x00000001825204C0-0x0000000182520510
			public override void SetValue(ref ResolvedStyleAccess container, float value); // 0x0000000182520510-0x0000000182520550
		}
	
		private class BorderTopRightRadiusProperty : ResolvedFloatProperty // TypeDefIndex: 4533
		{
			// Properties
			public override string Name { get; } // 0x0000000182520940-0x0000000182520970 
			public override string ussName { get; } // 0x00000001825209A0-0x00000001825209D0 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public BorderTopRightRadiusProperty(); // 0x000000018251D020-0x000000018251D030
	
			// Methods
			public override float GetValue(ref ResolvedStyleAccess container); // 0x00000001825206F0-0x0000000182520740
			public override void SetValue(ref ResolvedStyleAccess container, float value); // 0x0000000182520820-0x0000000182520860
		}
	
		private class BorderTopWidthProperty : ResolvedFloatProperty // TypeDefIndex: 4534
		{
			// Properties
			public override string Name { get; } // 0x0000000182520B40-0x0000000182520B70 
			public override string ussName { get; } // 0x0000000182520BA0-0x0000000182520BD0 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public BorderTopWidthProperty(); // 0x000000018251D020-0x000000018251D030
	
			// Methods
			public override float GetValue(ref ResolvedStyleAccess container); // 0x0000000182520A00-0x0000000182520A50
			public override void SetValue(ref ResolvedStyleAccess container, float value); // 0x0000000182520AA0-0x0000000182520AE0
		}
	
		private class BottomProperty : ResolvedFloatProperty // TypeDefIndex: 4535
		{
			// Properties
			public override string Name { get; } // 0x0000000182520E50-0x0000000182520E80 
			public override string ussName { get; } // 0x0000000182520EE0-0x0000000182520F10 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public BottomProperty(); // 0x000000018251D020-0x000000018251D030
	
			// Methods
			public override float GetValue(ref ResolvedStyleAccess container); // 0x0000000182520CE0-0x0000000182520D30
			public override void SetValue(ref ResolvedStyleAccess container, float value); // 0x0000000182520D30-0x0000000182520D70
		}
	
		private class ColorProperty : ResolvedColorProperty // TypeDefIndex: 4536
		{
			// Properties
			public override string Name { get; } // 0x00000001825211E0-0x0000000182521210 
			public override string ussName { get; } // 0x0000000182521240-0x0000000182521270 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public ColorProperty(); // 0x000000018251D020-0x000000018251D030
	
			// Methods
			public override Color GetValue(ref ResolvedStyleAccess container); // 0x0000000182520FF0-0x00000001825210C0
			public override void SetValue(ref ResolvedStyleAccess container, Color value); // 0x00000001825211A0-0x00000001825211E0
		}
	
		private class ColumnGapProperty : ResolvedFloatProperty // TypeDefIndex: 4537
		{
			// Properties
			public override string Name { get; } // 0x00000001825214F0-0x0000000182521520 
			public override string ussName { get; } // 0x0000000182521580-0x00000001825215B0 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public ColumnGapProperty(); // 0x000000018251D020-0x000000018251D030
	
			// Methods
			public override float GetValue(ref ResolvedStyleAccess container); // 0x0000000182521380-0x00000001825213D0
			public override void SetValue(ref ResolvedStyleAccess container, float value); // 0x00000001825214B0-0x00000001825214F0
		}
	
		private class DisplayProperty : ResolvedEnumProperty<DisplayStyle> // TypeDefIndex: 4538
		{
			// Properties
			public override string Name { get; } // 0x0000000182524180-0x00000001825241B0 
			public override string ussName { get; } // 0x00000001825241B0-0x00000001825241E0 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public DisplayProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override DisplayStyle GetValue(ref ResolvedStyleAccess container); // 0x0000000182524000-0x0000000182524050
			public override void SetValue(ref ResolvedStyleAccess container, DisplayStyle value); // 0x0000000182524110-0x0000000182524150
		}
	
		private class FilterProperty : ResolvedListProperty<FilterFunction> // TypeDefIndex: 4539
		{
			// Properties
			public override string Name { get; } // 0x0000000182525BD0-0x0000000182525C00 
			public override string ussName { get; } // 0x0000000182525C30-0x0000000182525C60 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public FilterProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override IEnumerable<FilterFunction> GetValue(ref ResolvedStyleAccess container); // 0x00000001825259A0-0x00000001825259F0
			public override void SetValue(ref ResolvedStyleAccess container, IEnumerable<FilterFunction> value); // 0x0000000182525B90-0x0000000182525BD0
		}
	
		private class FlexBasisProperty : ResolvedStyleFloatProperty // TypeDefIndex: 4540
		{
			// Properties
			public override string Name { get; } // 0x0000000182525EE0-0x0000000182525F10 
			public override string ussName { get; } // 0x0000000182525F70-0x0000000182525FA0 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public FlexBasisProperty(); // 0x000000018251D020-0x000000018251D030
	
			// Methods
			public override StyleFloat GetValue(ref ResolvedStyleAccess container); // 0x0000000182525C90-0x0000000182525CE0
			public override void SetValue(ref ResolvedStyleAccess container, StyleFloat value); // 0x0000000182525EA0-0x0000000182525EE0
		}
	
		private class FlexDirectionProperty : ResolvedEnumProperty<FlexDirection> // TypeDefIndex: 4541
		{
			// Properties
			public override string Name { get; } // 0x00000001825261B0-0x00000001825261E0 
			public override string ussName { get; } // 0x0000000182526210-0x0000000182526240 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public FlexDirectionProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override FlexDirection GetValue(ref ResolvedStyleAccess container); // 0x0000000182525FA0-0x0000000182525FF0
			public override void SetValue(ref ResolvedStyleAccess container, FlexDirection value); // 0x00000001825260B0-0x00000001825260F0
		}
	
		private class FlexGrowProperty : ResolvedFloatProperty // TypeDefIndex: 4542
		{
			// Properties
			public override string Name { get; } // 0x00000001825263E0-0x0000000182526410 
			public override string ussName { get; } // 0x0000000182526440-0x0000000182526470 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public FlexGrowProperty(); // 0x000000018251D020-0x000000018251D030
	
			// Methods
			public override float GetValue(ref ResolvedStyleAccess container); // 0x0000000182526270-0x00000001825262C0
			public override void SetValue(ref ResolvedStyleAccess container, float value); // 0x0000000182526370-0x00000001825263B0
		}
	
		private class FlexShrinkProperty : ResolvedFloatProperty // TypeDefIndex: 4543
		{
			// Properties
			public override string Name { get; } // 0x00000001825265E0-0x0000000182526610 
			public override string ussName { get; } // 0x0000000182526640-0x0000000182526670 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public FlexShrinkProperty(); // 0x000000018251D020-0x000000018251D030
	
			// Methods
			public override float GetValue(ref ResolvedStyleAccess container); // 0x00000001825264C0-0x0000000182526510
			public override void SetValue(ref ResolvedStyleAccess container, float value); // 0x0000000182526510-0x0000000182526550
		}
	
		private class FlexWrapProperty : ResolvedEnumProperty<Wrap> // TypeDefIndex: 4544
		{
			// Properties
			public override string Name { get; } // 0x0000000182526880-0x00000001825268B0 
			public override string ussName { get; } // 0x00000001825268E0-0x0000000182526910 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public FlexWrapProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override Wrap GetValue(ref ResolvedStyleAccess container); // 0x0000000182526730-0x0000000182526780
			public override void SetValue(ref ResolvedStyleAccess container, Wrap value); // 0x0000000182526780-0x00000001825267C0
		}
	
		private class FontSizeProperty : ResolvedFloatProperty // TypeDefIndex: 4545
		{
			// Properties
			public override string Name { get; } // 0x0000000182527450-0x0000000182527480 
			public override string ussName { get; } // 0x0000000182527480-0x00000001825274B0 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public FontSizeProperty(); // 0x000000018251D020-0x000000018251D030
	
			// Methods
			public override float GetValue(ref ResolvedStyleAccess container); // 0x00000001825271D0-0x0000000182527220
			public override void SetValue(ref ResolvedStyleAccess container, float value); // 0x0000000182527300-0x0000000182527340
		}
	
		private class HeightProperty : ResolvedFloatProperty // TypeDefIndex: 4546
		{
			// Properties
			public override string Name { get; } // 0x0000000182527730-0x0000000182527760 
			public override string ussName { get; } // 0x00000001825277C0-0x00000001825277F0 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public HeightProperty(); // 0x000000018251D020-0x000000018251D030
	
			// Methods
			public override float GetValue(ref ResolvedStyleAccess container); // 0x00000001825274E0-0x0000000182527530
			public override void SetValue(ref ResolvedStyleAccess container, float value); // 0x00000001825276F0-0x0000000182527730
		}
	
		private class JustifyContentProperty : ResolvedEnumProperty<Justify> // TypeDefIndex: 4547
		{
			// Properties
			public override string Name { get; } // 0x0000000182534A20-0x0000000182534A50 
			public override string ussName { get; } // 0x0000000182534A50-0x0000000182534A80 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public JustifyContentProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override Justify GetValue(ref ResolvedStyleAccess container); // 0x00000001825348A0-0x00000001825348F0
			public override void SetValue(ref ResolvedStyleAccess container, Justify value); // 0x00000001825349B0-0x00000001825349F0
		}
	
		private class LeftProperty : ResolvedFloatProperty // TypeDefIndex: 4548
		{
			// Properties
			public override string Name { get; } // 0x0000000182534D00-0x0000000182534D30 
			public override string ussName { get; } // 0x0000000182534D90-0x0000000182534DC0 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public LeftProperty(); // 0x000000018251D020-0x000000018251D030
	
			// Methods
			public override float GetValue(ref ResolvedStyleAccess container); // 0x0000000182534B90-0x0000000182534BE0
			public override void SetValue(ref ResolvedStyleAccess container, float value); // 0x0000000182534BE0-0x0000000182534C20
		}
	
		private class LetterSpacingProperty : ResolvedFloatProperty // TypeDefIndex: 4549
		{
			// Properties
			public override string Name { get; } // 0x0000000182535040-0x0000000182535070 
			public override string ussName { get; } // 0x0000000182535070-0x00000001825350A0 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public LetterSpacingProperty(); // 0x000000018251D020-0x000000018251D030
	
			// Methods
			public override float GetValue(ref ResolvedStyleAccess container); // 0x0000000182534DC0-0x0000000182534E10
			public override void SetValue(ref ResolvedStyleAccess container, float value); // 0x0000000182534EF0-0x0000000182534F30
		}
	
		private class MarginBottomProperty : ResolvedFloatProperty // TypeDefIndex: 4550
		{
			// Properties
			public override string Name { get; } // 0x0000000182535350-0x0000000182535380 
			public override string ussName { get; } // 0x00000001825353B0-0x00000001825353E0 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public MarginBottomProperty(); // 0x000000018251D020-0x000000018251D030
	
			// Methods
			public override float GetValue(ref ResolvedStyleAccess container); // 0x00000001825350D0-0x0000000182535120
			public override void SetValue(ref ResolvedStyleAccess container, float value); // 0x00000001825352E0-0x0000000182535320
		}
	
		private class MarginLeftProperty : ResolvedFloatProperty // TypeDefIndex: 4551
		{
			// Properties
			public override string Name { get; } // 0x0000000182535630-0x0000000182535660 
			public override string ussName { get; } // 0x0000000182535690-0x00000001825356C0 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public MarginLeftProperty(); // 0x000000018251D020-0x000000018251D030
	
			// Methods
			public override float GetValue(ref ResolvedStyleAccess container); // 0x00000001825354C0-0x0000000182535510
			public override void SetValue(ref ResolvedStyleAccess container, float value); // 0x0000000182535510-0x0000000182535550
		}
	
		private class MarginRightProperty : ResolvedFloatProperty // TypeDefIndex: 4552
		{
			// Properties
			public override string Name { get; } // 0x0000000182535970-0x00000001825359A0 
			public override string ussName { get; } // 0x00000001825359A0-0x00000001825359D0 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public MarginRightProperty(); // 0x000000018251D020-0x000000018251D030
	
			// Methods
			public override float GetValue(ref ResolvedStyleAccess container); // 0x00000001825356F0-0x0000000182535740
			public override void SetValue(ref ResolvedStyleAccess container, float value); // 0x0000000182535820-0x0000000182535860
		}
	
		private class MarginTopProperty : ResolvedFloatProperty // TypeDefIndex: 4553
		{
			// Properties
			public override string Name { get; } // 0x0000000182535C80-0x0000000182535CB0 
			public override string ussName { get; } // 0x0000000182535CB0-0x0000000182535CE0 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public MarginTopProperty(); // 0x000000018251D020-0x000000018251D030
	
			// Methods
			public override float GetValue(ref ResolvedStyleAccess container); // 0x0000000182535AE0-0x0000000182535B30
			public override void SetValue(ref ResolvedStyleAccess container, float value); // 0x0000000182535B30-0x0000000182535B70
		}
	
		private class MaxHeightProperty : ResolvedStyleFloatProperty // TypeDefIndex: 4554
		{
			// Properties
			public override string Name { get; } // 0x0000000182535F90-0x0000000182535FC0 
			public override string ussName { get; } // 0x0000000182535FC0-0x0000000182535FF0 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public MaxHeightProperty(); // 0x000000018251D020-0x000000018251D030
	
			// Methods
			public override StyleFloat GetValue(ref ResolvedStyleAccess container); // 0x0000000182535DF0-0x0000000182535E40
			public override void SetValue(ref ResolvedStyleAccess container, StyleFloat value); // 0x0000000182535E40-0x0000000182535E80
		}
	
		private class MaxWidthProperty : ResolvedStyleFloatProperty // TypeDefIndex: 4555
		{
			// Properties
			public override string Name { get; } // 0x00000001825362A0-0x00000001825362D0 
			public override string ussName { get; } // 0x0000000182536300-0x0000000182536330 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public MaxWidthProperty(); // 0x000000018251D020-0x000000018251D030
	
			// Methods
			public override StyleFloat GetValue(ref ResolvedStyleAccess container); // 0x0000000182536020-0x0000000182536070
			public override void SetValue(ref ResolvedStyleAccess container, StyleFloat value); // 0x0000000182536150-0x0000000182536190
		}
	
		private class MinHeightProperty : ResolvedStyleFloatProperty // TypeDefIndex: 4556
		{
			// Properties
			public override string Name { get; } // 0x0000000182536580-0x00000001825365B0 
			public override string ussName { get; } // 0x0000000182536610-0x0000000182536640 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public MinHeightProperty(); // 0x000000018251D020-0x000000018251D030
	
			// Methods
			public override StyleFloat GetValue(ref ResolvedStyleAccess container); // 0x0000000182536330-0x0000000182536380
			public override void SetValue(ref ResolvedStyleAccess container, StyleFloat value); // 0x0000000182536460-0x00000001825364A0
		}
	
		private class MinWidthProperty : ResolvedStyleFloatProperty // TypeDefIndex: 4557
		{
			// Properties
			public override string Name { get; } // 0x0000000182536890-0x00000001825368C0 
			public override string ussName { get; } // 0x0000000182536920-0x0000000182536950 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public MinWidthProperty(); // 0x000000018251D020-0x000000018251D030
	
			// Methods
			public override StyleFloat GetValue(ref ResolvedStyleAccess container); // 0x0000000182536720-0x0000000182536770
			public override void SetValue(ref ResolvedStyleAccess container, StyleFloat value); // 0x0000000182536850-0x0000000182536890
		}
	
		private class OpacityProperty : ResolvedFloatProperty // TypeDefIndex: 4558
		{
			// Properties
			public override string Name { get; } // 0x0000000182536B10-0x0000000182536B40 
			public override string ussName { get; } // 0x0000000182536B40-0x0000000182536B70 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public OpacityProperty(); // 0x000000018251D020-0x000000018251D030
	
			// Methods
			public override float GetValue(ref ResolvedStyleAccess container); // 0x00000001825369A0-0x00000001825369F0
			public override void SetValue(ref ResolvedStyleAccess container, float value); // 0x0000000182536A40-0x0000000182536A80
		}
	
		private class PaddingBottomProperty : ResolvedFloatProperty // TypeDefIndex: 4559
		{
			// Properties
			public override string Name { get; } // 0x0000000182536FD0-0x0000000182537000 
			public override string ussName { get; } // 0x0000000182537060-0x0000000182537090 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public PaddingBottomProperty(); // 0x000000018251D020-0x000000018251D030
	
			// Methods
			public override float GetValue(ref ResolvedStyleAccess container); // 0x0000000182536E60-0x0000000182536EB0
			public override void SetValue(ref ResolvedStyleAccess container, float value); // 0x0000000182536EB0-0x0000000182536EF0
		}
	
		private class PaddingLeftProperty : ResolvedFloatProperty // TypeDefIndex: 4560
		{
			// Properties
			public override string Name { get; } // 0x00000001825372E0-0x0000000182537310 
			public override string ussName { get; } // 0x0000000182537340-0x0000000182537370 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public PaddingLeftProperty(); // 0x000000018251D020-0x000000018251D030
	
			// Methods
			public override float GetValue(ref ResolvedStyleAccess container); // 0x0000000182537170-0x00000001825371C0
			public override void SetValue(ref ResolvedStyleAccess container, float value); // 0x00000001825372A0-0x00000001825372E0
		}
	
		private class PaddingRightProperty : ResolvedFloatProperty // TypeDefIndex: 4561
		{
			// Properties
			public override string Name { get; } // 0x0000000182537620-0x0000000182537650 
			public override string ussName { get; } // 0x0000000182537680-0x00000001825376B0 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public PaddingRightProperty(); // 0x000000018251D020-0x000000018251D030
	
			// Methods
			public override float GetValue(ref ResolvedStyleAccess container); // 0x00000001825373A0-0x00000001825373F0
			public override void SetValue(ref ResolvedStyleAccess container, float value); // 0x00000001825375B0-0x00000001825375F0
		}
	
		private class PaddingTopProperty : ResolvedFloatProperty // TypeDefIndex: 4562
		{
			// Properties
			public override string Name { get; } // 0x0000000182537930-0x0000000182537960 
			public override string ussName { get; } // 0x0000000182537960-0x0000000182537990 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public PaddingTopProperty(); // 0x000000018251D020-0x000000018251D030
	
			// Methods
			public override float GetValue(ref ResolvedStyleAccess container); // 0x00000001825376B0-0x0000000182537700
			public override void SetValue(ref ResolvedStyleAccess container, float value); // 0x00000001825378C0-0x0000000182537900
		}
	
		private class PositionProperty : ResolvedEnumProperty<Position> // TypeDefIndex: 4563
		{
			// Properties
			public override string Name { get; } // 0x0000000182537BD0-0x0000000182537C00 
			public override string ussName { get; } // 0x0000000182537C60-0x0000000182537C90 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public PositionProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override Position GetValue(ref ResolvedStyleAccess container); // 0x00000001825379C0-0x0000000182537A10
			public override void SetValue(ref ResolvedStyleAccess container, Position value); // 0x0000000182537B90-0x0000000182537BD0
		}
	
		private class RightProperty : ResolvedFloatProperty // TypeDefIndex: 4564
		{
			// Properties
			public override string Name { get; } // 0x000000018253C380-0x000000018253C3B0 
			public override string ussName { get; } // 0x000000018253C3B0-0x000000018253C3E0 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public RightProperty(); // 0x000000018251D020-0x000000018251D030
	
			// Methods
			public override float GetValue(ref ResolvedStyleAccess container); // 0x000000018253C1E0-0x000000018253C230
			public override void SetValue(ref ResolvedStyleAccess container, float value); // 0x000000018253C310-0x000000018253C350
		}
	
		private class RotateProperty : ResolvedRotateProperty // TypeDefIndex: 4565
		{
			// Properties
			public override string Name { get; } // 0x000000018253C690-0x000000018253C6C0 
			public override string ussName { get; } // 0x000000018253C720-0x000000018253C750 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public RotateProperty(); // 0x000000018251D020-0x000000018251D030
	
			// Methods
			public override Rotate GetValue(ref ResolvedStyleAccess container); // 0x000000018253C490-0x000000018253C570
			public override void SetValue(ref ResolvedStyleAccess container, Rotate value); // 0x000000018253C570-0x000000018253C5B0
		}
	
		private class RowGapProperty : ResolvedFloatProperty // TypeDefIndex: 4566
		{
			// Properties
			public override string Name { get; } // 0x000000018253C9D0-0x000000018253CA00 
			public override string ussName { get; } // 0x000000018253CA30-0x000000018253CA60 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public RowGapProperty(); // 0x000000018251D020-0x000000018251D030
	
			// Methods
			public override float GetValue(ref ResolvedStyleAccess container); // 0x000000018253C750-0x000000018253C7A0
			public override void SetValue(ref ResolvedStyleAccess container, float value); // 0x000000018253C960-0x000000018253C9A0
		}
	
		private class ScaleProperty : ResolvedScaleProperty // TypeDefIndex: 4567
		{
			// Properties
			public override string Name { get; } // 0x000000018253CD30-0x000000018253CD60 
			public override string ussName { get; } // 0x000000018253CDC0-0x000000018253CDF0 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public ScaleProperty(); // 0x000000018251D020-0x000000018251D030
	
			// Methods
			public override Scale GetValue(ref ResolvedStyleAccess container); // 0x000000018253CA60-0x000000018253CB30
			public override void SetValue(ref ResolvedStyleAccess container, Scale value); // 0x000000018253CCF0-0x000000018253CD30
		}
	
		private class TextOverflowProperty : ResolvedEnumProperty<TextOverflow> // TypeDefIndex: 4568
		{
			// Properties
			public override string Name { get; } // 0x000000018253D000-0x000000018253D030 
			public override string ussName { get; } // 0x000000018253D060-0x000000018253D090 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public TextOverflowProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override TextOverflow GetValue(ref ResolvedStyleAccess container); // 0x000000018253CEB0-0x000000018253CF00
			public override void SetValue(ref ResolvedStyleAccess container, TextOverflow value); // 0x000000018253CFC0-0x000000018253D000
		}
	
		private class TextShadowProperty : ResolvedTextShadowProperty // TypeDefIndex: 4569
		{
			// Properties
			public override string Name { get; } // 0x000000018253D3A0-0x000000018253D3D0 
			public override string ussName { get; } // 0x000000018253D430-0x000000018253D460 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public TextShadowProperty(); // 0x000000018251D020-0x000000018251D030
	
			// Methods
			public override TextShadow GetValue(ref ResolvedStyleAccess container); // 0x000000018253D0C0-0x000000018253D1A0
			public override void SetValue(ref ResolvedStyleAccess container, TextShadow value); // 0x000000018253D360-0x000000018253D3A0
		}
	
		private class TopProperty : ResolvedFloatProperty // TypeDefIndex: 4570
		{
			// Properties
			public override string Name { get; } // 0x0000000182546CD0-0x0000000182546D00 
			public override string ussName { get; } // 0x0000000182546D00-0x0000000182546D30 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public TopProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override float GetValue(ref ResolvedStyleAccess container); // 0x0000000182546C40-0x0000000182546C90
			public override void SetValue(ref ResolvedStyleAccess container, float value); // 0x0000000182546C90-0x0000000182546CD0
		}
	
		private class TransformOriginProperty : ResolvedVector3Property // TypeDefIndex: 4571
		{
			// Properties
			public override string Name { get; } // 0x0000000182547380-0x00000001825473B0 
			public override string ussName { get; } // 0x00000001825473B0-0x00000001825473E0 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public TransformOriginProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override Vector3 GetValue(ref ResolvedStyleAccess container); // 0x0000000182547260-0x0000000182547340
			public override void SetValue(ref ResolvedStyleAccess container, Vector3 value); // 0x0000000182547340-0x0000000182547380
		}
	
		private class TransitionDelayProperty : ResolvedListProperty<TimeValue> // TypeDefIndex: 4572
		{
			// Properties
			public override string Name { get; } // 0x0000000182547AD0-0x0000000182547B00 
			public override string ussName { get; } // 0x0000000182547B00-0x0000000182547B30 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public TransitionDelayProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override IEnumerable<TimeValue> GetValue(ref ResolvedStyleAccess container); // 0x0000000182547A40-0x0000000182547A90
			public override void SetValue(ref ResolvedStyleAccess container, IEnumerable<TimeValue> value); // 0x0000000182547A90-0x0000000182547AD0
		}
	
		private class TransitionDurationProperty : ResolvedListProperty<TimeValue> // TypeDefIndex: 4573
		{
			// Properties
			public override string Name { get; } // 0x0000000182547BC0-0x0000000182547BF0 
			public override string ussName { get; } // 0x0000000182547BF0-0x0000000182547C20 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public TransitionDurationProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override IEnumerable<TimeValue> GetValue(ref ResolvedStyleAccess container); // 0x0000000182547B30-0x0000000182547B80
			public override void SetValue(ref ResolvedStyleAccess container, IEnumerable<TimeValue> value); // 0x0000000182547B80-0x0000000182547BC0
		}
	
		private class TransitionPropertyProperty : ResolvedListProperty<StylePropertyName> // TypeDefIndex: 4574
		{
			// Properties
			public override string Name { get; } // 0x0000000182547CB0-0x0000000182547CE0 
			public override string ussName { get; } // 0x0000000182547CE0-0x0000000182547D10 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public TransitionPropertyProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override IEnumerable<StylePropertyName> GetValue(ref ResolvedStyleAccess container); // 0x0000000182547C20-0x0000000182547C70
			public override void SetValue(ref ResolvedStyleAccess container, IEnumerable<StylePropertyName> value); // 0x0000000182547C70-0x0000000182547CB0
		}
	
		private class TransitionTimingFunctionProperty : ResolvedListProperty<EasingFunction> // TypeDefIndex: 4575
		{
			// Properties
			public override string Name { get; } // 0x0000000182547DA0-0x0000000182547DD0 
			public override string ussName { get; } // 0x0000000182547DD0-0x0000000182547E00 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public TransitionTimingFunctionProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override IEnumerable<EasingFunction> GetValue(ref ResolvedStyleAccess container); // 0x0000000182547D10-0x0000000182547D60
			public override void SetValue(ref ResolvedStyleAccess container, IEnumerable<EasingFunction> value); // 0x0000000182547D60-0x0000000182547DA0
		}
	
		private class TranslateProperty : ResolvedVector3Property // TypeDefIndex: 4576
		{
			// Properties
			public override string Name { get; } // 0x0000000182547F20-0x0000000182547F50 
			public override string ussName { get; } // 0x0000000182547F50-0x0000000182547F80 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public TranslateProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override Vector3 GetValue(ref ResolvedStyleAccess container); // 0x0000000182547E00-0x0000000182547EE0
			public override void SetValue(ref ResolvedStyleAccess container, Vector3 value); // 0x0000000182547EE0-0x0000000182547F20
		}
	
		private class UnityAnimationClipProperty : ResolvedUIAnimationClipProperty // TypeDefIndex: 4577
		{
			// Properties
			public override string Name { get; } // 0x000000018255A9D0-0x000000018255AA00 
			public override string ussName { get; } // 0x000000018255AA00-0x000000018255AA30 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public UnityAnimationClipProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override UIAnimationClip GetValue(ref ResolvedStyleAccess container); // 0x000000018255A8D0-0x000000018255A990
			public override void SetValue(ref ResolvedStyleAccess container, UIAnimationClip value); // 0x000000018255A990-0x000000018255A9D0
		}
	
		private class UnityBackgroundImageTintColorProperty : ResolvedColorProperty // TypeDefIndex: 4578
		{
			// Properties
			public override string Name { get; } // 0x000000018255AB40-0x000000018255AB70 
			public override string ussName { get; } // 0x000000018255AB70-0x000000018255ABA0 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public UnityBackgroundImageTintColorProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override Color GetValue(ref ResolvedStyleAccess container); // 0x000000018255AA30-0x000000018255AB00
			public override void SetValue(ref ResolvedStyleAccess container, Color value); // 0x000000018255AB00-0x000000018255AB40
		}
	
		private class UnityEditorTextRenderingModeProperty : ResolvedEnumProperty<EditorTextRenderingMode> // TypeDefIndex: 4579
		{
			// Properties
			public override string Name { get; } // 0x000000018255AC30-0x000000018255AC60 
			public override string ussName { get; } // 0x000000018255AC60-0x000000018255AC90 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public UnityEditorTextRenderingModeProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override EditorTextRenderingMode GetValue(ref ResolvedStyleAccess container); // 0x000000018255ABA0-0x000000018255ABF0
			public override void SetValue(ref ResolvedStyleAccess container, EditorTextRenderingMode value); // 0x000000018255ABF0-0x000000018255AC30
		}
	
		private class UnityFontProperty : ResolvedFontProperty // TypeDefIndex: 4580
		{
			// Properties
			public override string Name { get; } // 0x000000018255AF00-0x000000018255AF30 
			public override string ussName { get; } // 0x000000018255AF30-0x000000018255AF60 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public UnityFontProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override Font GetValue(ref ResolvedStyleAccess container); // 0x000000018255AE00-0x000000018255AEC0
			public override void SetValue(ref ResolvedStyleAccess container, Font value); // 0x000000018255AEC0-0x000000018255AF00
		}
	
		private class UnityFontDefinitionProperty : ResolvedFontDefinitionProperty // TypeDefIndex: 4581
		{
			// Properties
			public override string Name { get; } // 0x000000018255ADA0-0x000000018255ADD0 
			public override string ussName { get; } // 0x000000018255ADD0-0x000000018255AE00 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public UnityFontDefinitionProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override FontDefinition GetValue(ref ResolvedStyleAccess container); // 0x000000018255AC90-0x000000018255AD60
			public override void SetValue(ref ResolvedStyleAccess container, FontDefinition value); // 0x000000018255AD60-0x000000018255ADA0
		}
	
		private class UnityFontStyleAndWeightProperty : ResolvedEnumProperty<FontStyle> // TypeDefIndex: 4582
		{
			// Properties
			public override string Name { get; } // 0x000000018255AFF0-0x000000018255B020 
			public override string ussName { get; } // 0x000000018255B020-0x000000018255B050 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public UnityFontStyleAndWeightProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override FontStyle GetValue(ref ResolvedStyleAccess container); // 0x000000018255AF60-0x000000018255AFB0
			public override void SetValue(ref ResolvedStyleAccess container, FontStyle value); // 0x000000018255AFB0-0x000000018255AFF0
		}
	
		private class UnityMaterialProperty : ResolvedMaterialDefinitionProperty // TypeDefIndex: 4583
		{
			// Properties
			public override string Name { get; } // 0x000000018255B160-0x000000018255B190 
			public override string ussName { get; } // 0x000000018255B190-0x000000018255B1C0 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public UnityMaterialProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override MaterialDefinition GetValue(ref ResolvedStyleAccess container); // 0x000000018255B050-0x000000018255B120
			public override void SetValue(ref ResolvedStyleAccess container, MaterialDefinition value); // 0x000000018255B120-0x000000018255B160
		}
	
		private class UnityParagraphSpacingProperty : ResolvedFloatProperty // TypeDefIndex: 4584
		{
			// Properties
			public override string Name { get; } // 0x000000018255B250-0x000000018255B280 
			public override string ussName { get; } // 0x000000018255B280-0x000000018255B2B0 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public UnityParagraphSpacingProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override float GetValue(ref ResolvedStyleAccess container); // 0x000000018255B1C0-0x000000018255B210
			public override void SetValue(ref ResolvedStyleAccess container, float value); // 0x000000018255B210-0x000000018255B250
		}
	
		private class UnitySliceBottomProperty : ResolvedIntProperty // TypeDefIndex: 4585
		{
			// Properties
			public override string Name { get; } // 0x000000018255B340-0x000000018255B370 
			public override string ussName { get; } // 0x000000018255B370-0x000000018255B3A0 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public UnitySliceBottomProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override int GetValue(ref ResolvedStyleAccess container); // 0x000000018255B2B0-0x000000018255B300
			public override void SetValue(ref ResolvedStyleAccess container, int value); // 0x000000018255B300-0x000000018255B340
		}
	
		private class UnitySliceLeftProperty : ResolvedIntProperty // TypeDefIndex: 4586
		{
			// Properties
			public override string Name { get; } // 0x000000018255B430-0x000000018255B460 
			public override string ussName { get; } // 0x000000018255B460-0x000000018255B490 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public UnitySliceLeftProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override int GetValue(ref ResolvedStyleAccess container); // 0x000000018255B3A0-0x000000018255B3F0
			public override void SetValue(ref ResolvedStyleAccess container, int value); // 0x000000018255B3F0-0x000000018255B430
		}
	
		private class UnitySliceRightProperty : ResolvedIntProperty // TypeDefIndex: 4587
		{
			// Properties
			public override string Name { get; } // 0x000000018255B520-0x000000018255B550 
			public override string ussName { get; } // 0x000000018255B550-0x000000018255B580 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public UnitySliceRightProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override int GetValue(ref ResolvedStyleAccess container); // 0x000000018255B490-0x000000018255B4E0
			public override void SetValue(ref ResolvedStyleAccess container, int value); // 0x000000018255B4E0-0x000000018255B520
		}
	
		private class UnitySliceScaleProperty : ResolvedFloatProperty // TypeDefIndex: 4588
		{
			// Properties
			public override string Name { get; } // 0x000000018255B610-0x000000018255B640 
			public override string ussName { get; } // 0x000000018255B640-0x000000018255B670 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public UnitySliceScaleProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override float GetValue(ref ResolvedStyleAccess container); // 0x000000018255B580-0x000000018255B5D0
			public override void SetValue(ref ResolvedStyleAccess container, float value); // 0x000000018255B5D0-0x000000018255B610
		}
	
		private class UnitySliceTopProperty : ResolvedIntProperty // TypeDefIndex: 4589
		{
			// Properties
			public override string Name { get; } // 0x000000018255B700-0x000000018255B730 
			public override string ussName { get; } // 0x000000018255B730-0x000000018255B760 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public UnitySliceTopProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override int GetValue(ref ResolvedStyleAccess container); // 0x000000018255B670-0x000000018255B6C0
			public override void SetValue(ref ResolvedStyleAccess container, int value); // 0x000000018255B6C0-0x000000018255B700
		}
	
		private class UnitySliceTypeProperty : ResolvedEnumProperty<SliceType> // TypeDefIndex: 4590
		{
			// Properties
			public override string Name { get; } // 0x000000018255B7F0-0x000000018255B820 
			public override string ussName { get; } // 0x000000018255B820-0x000000018255B850 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public UnitySliceTypeProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override SliceType GetValue(ref ResolvedStyleAccess container); // 0x000000018255B760-0x000000018255B7B0
			public override void SetValue(ref ResolvedStyleAccess container, SliceType value); // 0x000000018255B7B0-0x000000018255B7F0
		}
	
		private class UnityTextAlignProperty : ResolvedEnumProperty<TextAnchor> // TypeDefIndex: 4591
		{
			// Properties
			public override string Name { get; } // 0x000000018255B8E0-0x000000018255B910 
			public override string ussName { get; } // 0x000000018255B910-0x000000018255B940 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public UnityTextAlignProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override TextAnchor GetValue(ref ResolvedStyleAccess container); // 0x000000018255B850-0x000000018255B8A0
			public override void SetValue(ref ResolvedStyleAccess container, TextAnchor value); // 0x000000018255B8A0-0x000000018255B8E0
		}
	
		private class UnityTextGeneratorProperty : ResolvedEnumProperty<TextGeneratorType> // TypeDefIndex: 4592
		{
			// Properties
			public override string Name { get; } // 0x000000018255B9D0-0x000000018255BA00 
			public override string ussName { get; } // 0x000000018255BA00-0x000000018255BA30 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public UnityTextGeneratorProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override TextGeneratorType GetValue(ref ResolvedStyleAccess container); // 0x000000018255B940-0x000000018255B990
			public override void SetValue(ref ResolvedStyleAccess container, TextGeneratorType value); // 0x000000018255B990-0x000000018255B9D0
		}
	
		private class UnityTextOutlineColorProperty : ResolvedColorProperty // TypeDefIndex: 4593
		{
			// Properties
			public override string Name { get; } // 0x000000018255BB40-0x000000018255BB70 
			public override string ussName { get; } // 0x000000018255BB70-0x000000018255BBA0 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public UnityTextOutlineColorProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override Color GetValue(ref ResolvedStyleAccess container); // 0x000000018255BA30-0x000000018255BB00
			public override void SetValue(ref ResolvedStyleAccess container, Color value); // 0x000000018255BB00-0x000000018255BB40
		}
	
		private class UnityTextOutlineWidthProperty : ResolvedFloatProperty // TypeDefIndex: 4594
		{
			// Properties
			public override string Name { get; } // 0x000000018255BC30-0x000000018255BC60 
			public override string ussName { get; } // 0x000000018255BC60-0x000000018255BC90 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public UnityTextOutlineWidthProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override float GetValue(ref ResolvedStyleAccess container); // 0x000000018255BBA0-0x000000018255BBF0
			public override void SetValue(ref ResolvedStyleAccess container, float value); // 0x000000018255BBF0-0x000000018255BC30
		}
	
		private class UnityTextOverflowPositionProperty : ResolvedEnumProperty<TextOverflowPosition> // TypeDefIndex: 4595
		{
			// Properties
			public override string Name { get; } // 0x000000018255BD20-0x000000018255BD50 
			public override string ussName { get; } // 0x000000018255BD50-0x000000018255BD80 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public UnityTextOverflowPositionProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override TextOverflowPosition GetValue(ref ResolvedStyleAccess container); // 0x000000018255BC90-0x000000018255BCE0
			public override void SetValue(ref ResolvedStyleAccess container, TextOverflowPosition value); // 0x000000018255BCE0-0x000000018255BD20
		}
	
		private class VisibilityProperty : ResolvedEnumProperty<Visibility> // TypeDefIndex: 4596
		{
			// Properties
			public override string Name { get; } // 0x000000018255BE80-0x000000018255BEB0 
			public override string ussName { get; } // 0x000000018255BEB0-0x000000018255BEE0 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public VisibilityProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override Visibility GetValue(ref ResolvedStyleAccess container); // 0x000000018255BDF0-0x000000018255BE40
			public override void SetValue(ref ResolvedStyleAccess container, Visibility value); // 0x000000018255BE40-0x000000018255BE80
		}
	
		private class WhiteSpaceProperty : ResolvedEnumProperty<WhiteSpace> // TypeDefIndex: 4597
		{
			// Properties
			public override string Name { get; } // 0x000000018255D7C0-0x000000018255D7F0 
			public override string ussName { get; } // 0x000000018255D7F0-0x000000018255D820 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public WhiteSpaceProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override WhiteSpace GetValue(ref ResolvedStyleAccess container); // 0x000000018255D730-0x000000018255D780
			public override void SetValue(ref ResolvedStyleAccess container, WhiteSpace value); // 0x000000018255D780-0x000000018255D7C0
		}
	
		private class WidthProperty : ResolvedFloatProperty // TypeDefIndex: 4598
		{
			// Properties
			public override string Name { get; } // 0x000000018255D8B0-0x000000018255D8E0 
			public override string ussName { get; } // 0x000000018255D8E0-0x000000018255D910 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public WidthProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override float GetValue(ref ResolvedStyleAccess container); // 0x000000018255D820-0x000000018255D870
			public override void SetValue(ref ResolvedStyleAccess container, float value); // 0x000000018255D870-0x000000018255D8B0
		}
	
		private class WordSpacingProperty : ResolvedFloatProperty // TypeDefIndex: 4599
		{
			// Properties
			public override string Name { get; } // 0x000000018255D9A0-0x000000018255D9D0 
			public override string ussName { get; } // 0x000000018255D9D0-0x000000018255DA00 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public WordSpacingProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override float GetValue(ref ResolvedStyleAccess container); // 0x000000018255D910-0x000000018255D960
			public override void SetValue(ref ResolvedStyleAccess container, float value); // 0x000000018255D960-0x000000018255D9A0
		}
	
		internal interface IStyleProperty : IProperty<ResolvedStyleAccess> // TypeDefIndex: 4600
		{
			// Properties
			string ussName { get; }
		}
	
		private abstract class ResolvedStyleProperty<TValue> : Property<ResolvedStyleAccess, TValue>, IStyleProperty // TypeDefIndex: 4601
		{
			// Properties
			public abstract string ussName { get; }
	
			// Constructors
			protected ResolvedStyleProperty();
		}
	
		private abstract class ResolvedEnumProperty<TValue> : ResolvedStyleProperty<TValue> // TypeDefIndex: 4602
			where TValue : struct, IConvertible
		{
			// Constructors
			protected ResolvedEnumProperty();
		}
	
		private abstract class ResolvedUIAnimationClipProperty : ResolvedStyleProperty<UIAnimationClip> // TypeDefIndex: 4603
		{
			// Constructors
			protected ResolvedUIAnimationClipProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
		}
	
		private abstract class ResolvedColorProperty : ResolvedStyleProperty<Color> // TypeDefIndex: 4604
		{
			// Constructors
			protected ResolvedColorProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
		}
	
		private abstract class ResolvedBackgroundProperty : ResolvedStyleProperty<Background> // TypeDefIndex: 4605
		{
			// Constructors
			protected ResolvedBackgroundProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
		}
	
		private abstract class ResolvedFloatProperty : ResolvedStyleProperty<float> // TypeDefIndex: 4606
		{
			// Constructors
			protected ResolvedFloatProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
		}
	
		private abstract class ResolvedStyleFloatProperty : ResolvedStyleProperty<StyleFloat> // TypeDefIndex: 4607
		{
			// Constructors
			protected ResolvedStyleFloatProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
		}
	
		private abstract class ResolvedListProperty<T> : ResolvedStyleProperty<IEnumerable<T>> // TypeDefIndex: 4608
		{
			// Constructors
			protected ResolvedListProperty();
		}
	
		private abstract class ResolvedFontProperty : ResolvedStyleProperty<Font> // TypeDefIndex: 4609
		{
			// Constructors
			protected ResolvedFontProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
		}
	
		private abstract class ResolvedFontDefinitionProperty : ResolvedStyleProperty<FontDefinition> // TypeDefIndex: 4610
		{
			// Constructors
			protected ResolvedFontDefinitionProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
		}
	
		private abstract class ResolvedIntProperty : ResolvedStyleProperty<int> // TypeDefIndex: 4611
		{
			// Constructors
			protected ResolvedIntProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
		}
	
		private abstract class ResolvedRotateProperty : ResolvedStyleProperty<Rotate> // TypeDefIndex: 4612
		{
			// Constructors
			protected ResolvedRotateProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
		}
	
		private abstract class ResolvedScaleProperty : ResolvedStyleProperty<Scale> // TypeDefIndex: 4613
		{
			// Constructors
			protected ResolvedScaleProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
		}
	
		private abstract class ResolvedVector3Property : ResolvedStyleProperty<Vector3> // TypeDefIndex: 4614
		{
			// Constructors
			protected ResolvedVector3Property(); // 0x0000000180A6DF30-0x0000000180A6DF40
		}
	
		private abstract class ResolvedBackgroundPositionProperty : ResolvedStyleProperty<BackgroundPosition> // TypeDefIndex: 4615
		{
			// Constructors
			protected ResolvedBackgroundPositionProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
		}
	
		private abstract class ResolvedBackgroundRepeatProperty : ResolvedStyleProperty<BackgroundRepeat> // TypeDefIndex: 4616
		{
			// Constructors
			protected ResolvedBackgroundRepeatProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
		}
	
		private abstract class ResolvedBackgroundSizeProperty : ResolvedStyleProperty<BackgroundSize> // TypeDefIndex: 4617
		{
			// Constructors
			protected ResolvedBackgroundSizeProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
		}
	
		private abstract class ResolvedMaterialDefinitionProperty : ResolvedStyleProperty<MaterialDefinition> // TypeDefIndex: 4618
		{
			// Constructors
			protected ResolvedMaterialDefinitionProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
		}
	
		private abstract class ResolvedRatioProperty : ResolvedStyleProperty<Ratio> // TypeDefIndex: 4619
		{
			// Constructors
			protected ResolvedRatioProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
		}
	
		private abstract class ResolvedTextShadowProperty : ResolvedStyleProperty<TextShadow> // TypeDefIndex: 4620
		{
			// Constructors
			protected ResolvedTextShadowProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
		}
	
		// Constructors
		public ResolvedStyleAccessPropertyBag(); // 0x0000000182538260-0x000000018253AB00
	
		// Methods
		private void AddPropertyRange(params IStyleProperty[] properties); // 0x0000000182537EE0-0x00000001825381F0
		public override PropertyCollection<ResolvedStyleAccess> GetProperties(); // 0x0000000180DE7660-0x0000000180DE7690
		public override PropertyCollection<ResolvedStyleAccess> GetProperties(ref ResolvedStyleAccess container); // 0x0000000180DE7660-0x0000000180DE7690
		public bool TryGetProperty(ref ResolvedStyleAccess container, string name, out IProperty<ResolvedStyleAccess> property); // 0x00000001825381F0-0x0000000182538260
	}
}
