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
	internal class InlineStyleAccessPropertyBag : PropertyBag<InlineStyleAccess>, INamedProperties<InlineStyleAccess> // TypeDefIndex: 4389
	{
		// Fields
		private readonly List<IProperty<InlineStyleAccess>> m_PropertiesList; // 0x18
		private readonly Dictionary<string, IProperty<InlineStyleAccess>> m_PropertiesHash; // 0x20
	
		// Nested types
		private class AlignContentProperty : InlineStyleEnumProperty<Align> // TypeDefIndex: 4390
		{
			// Properties
			public override string Name { get; } // 0x000000018251C610-0x000000018251C640 
			public override string ussName { get; } // 0x000000018251C670-0x000000018251C6A0 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public AlignContentProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleEnum<Align> GetValue(ref InlineStyleAccess container); // 0x000000018251C520-0x000000018251C570
			public override void SetValue(ref InlineStyleAccess container, StyleEnum<Align> value); // 0x000000018251C5B0-0x000000018251C610
		}
	
		private class AlignItemsProperty : InlineStyleEnumProperty<Align> // TypeDefIndex: 4391
		{
			// Properties
			public override string Name { get; } // 0x000000018251C810-0x000000018251C840 
			public override string ussName { get; } // 0x000000018251C870-0x000000018251C8A0 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public AlignItemsProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleEnum<Align> GetValue(ref InlineStyleAccess container); // 0x000000018251C720-0x000000018251C770
			public override void SetValue(ref InlineStyleAccess container, StyleEnum<Align> value); // 0x000000018251C7B0-0x000000018251C810
		}
	
		private class AlignSelfProperty : InlineStyleEnumProperty<Align> // TypeDefIndex: 4392
		{
			// Properties
			public override string Name { get; } // 0x000000018251CA10-0x000000018251CA40 
			public override string ussName { get; } // 0x000000018251CA70-0x000000018251CAA0 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public AlignSelfProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleEnum<Align> GetValue(ref InlineStyleAccess container); // 0x000000018251C8D0-0x000000018251C920
			public override void SetValue(ref InlineStyleAccess container, StyleEnum<Align> value); // 0x000000018251C9B0-0x000000018251CA10
		}
	
		private class AnimationPlayStateProperty : InlineStyleEnumProperty<AnimationPlayState> // TypeDefIndex: 4393
		{
			// Properties
			public override string Name { get; } // 0x000000018251CCE0-0x000000018251CD10 
			public override string ussName { get; } // 0x000000018251CD70-0x000000018251CDA0 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public AnimationPlayStateProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleEnum<AnimationPlayState> GetValue(ref InlineStyleAccess container); // 0x000000018251CB20-0x000000018251CBE0
			public override void SetValue(ref InlineStyleAccess container, StyleEnum<AnimationPlayState> value); // 0x000000018251CC20-0x000000018251CCE0
		}
	
		private class AspectRatioProperty : InlineStyleRatioProperty // TypeDefIndex: 4394
		{
			// Properties
			public override string Name { get; } // 0x000000018251D030-0x000000018251D060 
			public override string ussName { get; } // 0x000000018251D0C0-0x000000018251D0F0 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public AspectRatioProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleRatio GetValue(ref InlineStyleAccess container); // 0x000000018251CE60-0x000000018251CF20
			public override void SetValue(ref InlineStyleAccess container, StyleRatio value); // 0x000000018251CF20-0x000000018251CFE0
		}
	
		private class BackdropFilterProperty : InlineStyleListProperty<FilterFunction> // TypeDefIndex: 4395
		{
			// Properties
			public override string Name { get; } // 0x000000018251D350-0x000000018251D380 
			public override string ussName { get; } // 0x000000018251D3B0-0x000000018251D3E0 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public BackdropFilterProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleList<FilterFunction> GetValue(ref InlineStyleAccess container); // 0x000000018251D0F0-0x000000018251D1C0
			public override void SetValue(ref InlineStyleAccess container, StyleList<FilterFunction> value); // 0x000000018251D210-0x000000018251D2E0
		}
	
		private class BackgroundColorProperty : InlineStyleColorProperty // TypeDefIndex: 4396
		{
			// Properties
			public override string Name { get; } // 0x000000018251D6B0-0x000000018251D6E0 
			public override string ussName { get; } // 0x000000018251D740-0x000000018251D770 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public BackgroundColorProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleColor GetValue(ref InlineStyleAccess container); // 0x000000018251D4B0-0x000000018251D590
			public override void SetValue(ref InlineStyleAccess container, StyleColor value); // 0x000000018251D590-0x000000018251D670
		}
	
		private class BackgroundImageProperty : InlineStyleBackgroundProperty // TypeDefIndex: 4397
		{
			// Properties
			public override string Name { get; } // 0x000000018251DAA0-0x000000018251DAD0 
			public override string ussName { get; } // 0x000000018251DB30-0x000000018251DB60 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public BackgroundImageProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleBackground GetValue(ref InlineStyleAccess container); // 0x000000018251D860-0x000000018251D960
			public override void SetValue(ref InlineStyleAccess container, StyleBackground value); // 0x000000018251D9A0-0x000000018251DAA0
		}
	
		private class BackgroundPositionXProperty : InlineStyleBackgroundPositionProperty // TypeDefIndex: 4398
		{
			// Properties
			public override string Name { get; } // 0x000000018251DE20-0x000000018251DE50 
			public override string ussName { get; } // 0x000000018251DE80-0x000000018251DEB0 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public BackgroundPositionXProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleBackgroundPosition GetValue(ref InlineStyleAccess container); // 0x000000018251DB60-0x000000018251DC30
			public override void SetValue(ref InlineStyleAccess container, StyleBackgroundPosition value); // 0x000000018251DD50-0x000000018251DE20
		}
	
		private class BackgroundPositionYProperty : InlineStyleBackgroundPositionProperty // TypeDefIndex: 4399
		{
			// Properties
			public override string Name { get; } // 0x000000018251E1D0-0x000000018251E200 
			public override string ussName { get; } // 0x000000018251E230-0x000000018251E260 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public BackgroundPositionYProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleBackgroundPosition GetValue(ref InlineStyleAccess container); // 0x000000018251DEE0-0x000000018251DFB0
			public override void SetValue(ref InlineStyleAccess container, StyleBackgroundPosition value); // 0x000000018251E090-0x000000018251E160
		}
	
		private class BackgroundRepeatProperty : InlineStyleBackgroundRepeatProperty // TypeDefIndex: 4400
		{
			// Properties
			public override string Name { get; } // 0x000000018251E520-0x000000018251E550 
			public override string ussName { get; } // 0x000000018251E5B0-0x000000018251E5E0 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public BackgroundRepeatProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleBackgroundRepeat GetValue(ref InlineStyleAccess container); // 0x000000018251E260-0x000000018251E340
			public override void SetValue(ref InlineStyleAccess container, StyleBackgroundRepeat value); // 0x000000018251E440-0x000000018251E520
		}
	
		private class BackgroundSizeProperty : InlineStyleBackgroundSizeProperty // TypeDefIndex: 4401
		{
			// Properties
			public override string Name { get; } // 0x000000018251E8C0-0x000000018251E8F0 
			public override string ussName { get; } // 0x000000018251E920-0x000000018251E950 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public BackgroundSizeProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleBackgroundSize GetValue(ref InlineStyleAccess container); // 0x000000018251E6C0-0x000000018251E7A0
			public override void SetValue(ref InlineStyleAccess container, StyleBackgroundSize value); // 0x000000018251E7A0-0x000000018251E880
		}
	
		private class BorderBottomColorProperty : InlineStyleColorProperty // TypeDefIndex: 4402
		{
			// Properties
			public override string Name { get; } // 0x000000018251EC50-0x000000018251EC80 
			public override string ussName { get; } // 0x000000018251ECB0-0x000000018251ECE0 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public BorderBottomColorProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleColor GetValue(ref InlineStyleAccess container); // 0x000000018251EA50-0x000000018251EB30
			public override void SetValue(ref InlineStyleAccess container, StyleColor value); // 0x000000018251EB70-0x000000018251EC50
		}
	
		private class BorderBottomLeftRadiusProperty : InlineStyleLengthProperty // TypeDefIndex: 4403
		{
			// Properties
			public override string Name { get; } // 0x000000018251EF60-0x000000018251EF90 
			public override string ussName { get; } // 0x000000018251EFC0-0x000000018251EFF0 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public BorderBottomLeftRadiusProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleLength GetValue(ref InlineStyleAccess container); // 0x000000018251ED60-0x000000018251EE40
			public override void SetValue(ref InlineStyleAccess container, StyleLength value); // 0x000000018251EE80-0x000000018251EF60
		}
	
		private class BorderBottomRightRadiusProperty : InlineStyleLengthProperty // TypeDefIndex: 4404
		{
			// Properties
			public override string Name { get; } // 0x000000018251F2A0-0x000000018251F2D0 
			public override string ussName { get; } // 0x000000018251F300-0x000000018251F330 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public BorderBottomRightRadiusProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleLength GetValue(ref InlineStyleAccess container); // 0x000000018251F020-0x000000018251F100
			public override void SetValue(ref InlineStyleAccess container, StyleLength value); // 0x000000018251F150-0x000000018251F230
		}
	
		private class BorderBottomWidthProperty : InlineStyleFloatProperty // TypeDefIndex: 4405
		{
			// Properties
			public override string Name { get; } // 0x000000018251F470-0x000000018251F4A0 
			public override string ussName { get; } // 0x000000018251F500-0x000000018251F530 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public BorderBottomWidthProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleFloat GetValue(ref InlineStyleAccess container); // 0x000000018251F330-0x000000018251F380
			public override void SetValue(ref InlineStyleAccess container, StyleFloat value); // 0x000000018251F410-0x000000018251F470
		}
	
		private class BorderLeftColorProperty : InlineStyleColorProperty // TypeDefIndex: 4406
		{
			// Properties
			public override string Name { get; } // 0x000000018251F800-0x000000018251F830 
			public override string ussName { get; } // 0x000000018251F860-0x000000018251F890 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public BorderLeftColorProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleColor GetValue(ref InlineStyleAccess container); // 0x000000018251F600-0x000000018251F6E0
			public override void SetValue(ref InlineStyleAccess container, StyleColor value); // 0x000000018251F720-0x000000018251F800
		}
	
		private class BorderLeftWidthProperty : InlineStyleFloatProperty // TypeDefIndex: 4407
		{
			// Properties
			public override string Name { get; } // 0x000000018251FA30-0x000000018251FA60 
			public override string ussName { get; } // 0x000000018251FA60-0x000000018251FA90 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public BorderLeftWidthProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleFloat GetValue(ref InlineStyleAccess container); // 0x000000018251F8C0-0x000000018251F910
			public override void SetValue(ref InlineStyleAccess container, StyleFloat value); // 0x000000018251F9A0-0x000000018251FA00
		}
	
		private class BorderRightColorProperty : InlineStyleColorProperty // TypeDefIndex: 4408
		{
			// Properties
			public override string Name { get; } // 0x000000018251FD90-0x000000018251FDC0 
			public override string ussName { get; } // 0x000000018251FDF0-0x000000018251FE20 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public BorderRightColorProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleColor GetValue(ref InlineStyleAccess container); // 0x000000018251FB90-0x000000018251FC70
			public override void SetValue(ref InlineStyleAccess container, StyleColor value); // 0x000000018251FC70-0x000000018251FD50
		}
	
		private class BorderRightWidthProperty : InlineStyleFloatProperty // TypeDefIndex: 4409
		{
			// Properties
			public override string Name { get; } // 0x000000018251FF90-0x000000018251FFC0 
			public override string ussName { get; } // 0x0000000182520020-0x0000000182520050 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public BorderRightWidthProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleFloat GetValue(ref InlineStyleAccess container); // 0x000000018251FE50-0x000000018251FEA0
			public override void SetValue(ref InlineStyleAccess container, StyleFloat value); // 0x000000018251FEF0-0x000000018251FF50
		}
	
		private class BorderTopColorProperty : InlineStyleColorProperty // TypeDefIndex: 4410
		{
			// Properties
			public override string Name { get; } // 0x0000000182520350-0x0000000182520380 
			public override string ussName { get; } // 0x0000000182520380-0x00000001825203B0 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public BorderTopColorProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleColor GetValue(ref InlineStyleAccess container); // 0x0000000182520120-0x0000000182520200
			public override void SetValue(ref InlineStyleAccess container, StyleColor value); // 0x0000000182520200-0x00000001825202E0
		}
	
		private class BorderTopLeftRadiusProperty : InlineStyleLengthProperty // TypeDefIndex: 4411
		{
			// Properties
			public override string Name { get; } // 0x0000000182520630-0x0000000182520660 
			public override string ussName { get; } // 0x0000000182520690-0x00000001825206C0 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public BorderTopLeftRadiusProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleLength GetValue(ref InlineStyleAccess container); // 0x00000001825203E0-0x00000001825204C0
			public override void SetValue(ref InlineStyleAccess container, StyleLength value); // 0x0000000182520550-0x0000000182520630
		}
	
		private class BorderTopRightRadiusProperty : InlineStyleLengthProperty // TypeDefIndex: 4412
		{
			// Properties
			public override string Name { get; } // 0x0000000182520970-0x00000001825209A0 
			public override string ussName { get; } // 0x00000001825209D0-0x0000000182520A00 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public BorderTopRightRadiusProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleLength GetValue(ref InlineStyleAccess container); // 0x0000000182520740-0x0000000182520820
			public override void SetValue(ref InlineStyleAccess container, StyleLength value); // 0x0000000182520860-0x0000000182520940
		}
	
		private class BorderTopWidthProperty : InlineStyleFloatProperty // TypeDefIndex: 4413
		{
			// Properties
			public override string Name { get; } // 0x0000000182520B70-0x0000000182520BA0 
			public override string ussName { get; } // 0x0000000182520BD0-0x0000000182520C00 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public BorderTopWidthProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleFloat GetValue(ref InlineStyleAccess container); // 0x0000000182520A50-0x0000000182520AA0
			public override void SetValue(ref InlineStyleAccess container, StyleFloat value); // 0x0000000182520AE0-0x0000000182520B40
		}
	
		private class BottomProperty : InlineStyleLengthProperty // TypeDefIndex: 4414
		{
			// Properties
			public override string Name { get; } // 0x0000000182520E80-0x0000000182520EB0 
			public override string ussName { get; } // 0x0000000182520EB0-0x0000000182520EE0 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public BottomProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleLength GetValue(ref InlineStyleAccess container); // 0x0000000182520C00-0x0000000182520CE0
			public override void SetValue(ref InlineStyleAccess container, StyleLength value); // 0x0000000182520D70-0x0000000182520E50
		}
	
		private class ColorProperty : InlineStyleColorProperty // TypeDefIndex: 4415
		{
			// Properties
			public override string Name { get; } // 0x0000000182521210-0x0000000182521240 
			public override string ussName { get; } // 0x0000000182521270-0x00000001825212A0 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public ColorProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleColor GetValue(ref InlineStyleAccess container); // 0x0000000182520F10-0x0000000182520FF0
			public override void SetValue(ref InlineStyleAccess container, StyleColor value); // 0x00000001825210C0-0x00000001825211A0
		}
	
		private class ColumnGapProperty : InlineStyleLengthProperty // TypeDefIndex: 4416
		{
			// Properties
			public override string Name { get; } // 0x0000000182521520-0x0000000182521550 
			public override string ussName { get; } // 0x0000000182521550-0x0000000182521580 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public ColumnGapProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleLength GetValue(ref InlineStyleAccess container); // 0x00000001825212A0-0x0000000182521380
			public override void SetValue(ref InlineStyleAccess container, StyleLength value); // 0x00000001825213D0-0x00000001825214B0
		}
	
		private class CursorProperty : InlineStyleCursorProperty // TypeDefIndex: 4417
		{
			// Properties
			public override string Name { get; } // 0x0000000182523870-0x00000001825238A0 
			public override string ussName { get; } // 0x00000001825238A0-0x00000001825238D0 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public CursorProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleCursor GetValue(ref InlineStyleAccess container); // 0x00000001825236B0-0x0000000182523790
			public override void SetValue(ref InlineStyleAccess container, StyleCursor value); // 0x0000000182523790-0x0000000182523870
		}
	
		private class DisplayProperty : InlineStyleEnumProperty<DisplayStyle> // TypeDefIndex: 4418
		{
			// Properties
			public override string Name { get; } // 0x0000000182524150-0x0000000182524180 
			public override string ussName { get; } // 0x00000001825241E0-0x0000000182524210 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public DisplayProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleEnum<DisplayStyle> GetValue(ref InlineStyleAccess container); // 0x0000000182523F40-0x0000000182524000
			public override void SetValue(ref InlineStyleAccess container, StyleEnum<DisplayStyle> value); // 0x0000000182524050-0x0000000182524110
		}
	
		private class FilterProperty : InlineStyleListProperty<FilterFunction> // TypeDefIndex: 4419
		{
			// Properties
			public override string Name { get; } // 0x0000000182525C00-0x0000000182525C30 
			public override string ussName { get; } // 0x0000000182525C60-0x0000000182525C90 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public FilterProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleList<FilterFunction> GetValue(ref InlineStyleAccess container); // 0x00000001825259F0-0x0000000182525AC0
			public override void SetValue(ref InlineStyleAccess container, StyleList<FilterFunction> value); // 0x0000000182525AC0-0x0000000182525B90
		}
	
		private class FlexBasisProperty : InlineStyleLengthProperty // TypeDefIndex: 4420
		{
			// Properties
			public override string Name { get; } // 0x0000000182525F10-0x0000000182525F40 
			public override string ussName { get; } // 0x0000000182525F40-0x0000000182525F70 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public FlexBasisProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleLength GetValue(ref InlineStyleAccess container); // 0x0000000182525CE0-0x0000000182525DC0
			public override void SetValue(ref InlineStyleAccess container, StyleLength value); // 0x0000000182525DC0-0x0000000182525EA0
		}
	
		private class FlexDirectionProperty : InlineStyleEnumProperty<FlexDirection> // TypeDefIndex: 4421
		{
			// Properties
			public override string Name { get; } // 0x00000001825261E0-0x0000000182526210 
			public override string ussName { get; } // 0x0000000182526240-0x0000000182526270 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public FlexDirectionProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleEnum<FlexDirection> GetValue(ref InlineStyleAccess container); // 0x0000000182525FF0-0x00000001825260B0
			public override void SetValue(ref InlineStyleAccess container, StyleEnum<FlexDirection> value); // 0x00000001825260F0-0x00000001825261B0
		}
	
		private class FlexGrowProperty : InlineStyleFloatProperty // TypeDefIndex: 4422
		{
			// Properties
			public override string Name { get; } // 0x00000001825263B0-0x00000001825263E0 
			public override string ussName { get; } // 0x0000000182526410-0x0000000182526440 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public FlexGrowProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleFloat GetValue(ref InlineStyleAccess container); // 0x00000001825262C0-0x0000000182526310
			public override void SetValue(ref InlineStyleAccess container, StyleFloat value); // 0x0000000182526310-0x0000000182526370
		}
	
		private class FlexShrinkProperty : InlineStyleFloatProperty // TypeDefIndex: 4423
		{
			// Properties
			public override string Name { get; } // 0x00000001825265B0-0x00000001825265E0 
			public override string ussName { get; } // 0x0000000182526610-0x0000000182526640 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public FlexShrinkProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleFloat GetValue(ref InlineStyleAccess container); // 0x0000000182526470-0x00000001825264C0
			public override void SetValue(ref InlineStyleAccess container, StyleFloat value); // 0x0000000182526550-0x00000001825265B0
		}
	
		private class FlexWrapProperty : InlineStyleEnumProperty<Wrap> // TypeDefIndex: 4424
		{
			// Properties
			public override string Name { get; } // 0x00000001825268B0-0x00000001825268E0 
			public override string ussName { get; } // 0x0000000182526910-0x0000000182526940 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public FlexWrapProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleEnum<Wrap> GetValue(ref InlineStyleAccess container); // 0x0000000182526670-0x0000000182526730
			public override void SetValue(ref InlineStyleAccess container, StyleEnum<Wrap> value); // 0x00000001825267C0-0x0000000182526880
		}
	
		private class FontSizeProperty : InlineStyleLengthProperty // TypeDefIndex: 4425
		{
			// Properties
			public override string Name { get; } // 0x0000000182527420-0x0000000182527450 
			public override string ussName { get; } // 0x00000001825274B0-0x00000001825274E0 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public FontSizeProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleLength GetValue(ref InlineStyleAccess container); // 0x0000000182527220-0x0000000182527300
			public override void SetValue(ref InlineStyleAccess container, StyleLength value); // 0x0000000182527340-0x0000000182527420
		}
	
		private class HeightProperty : InlineStyleLengthProperty // TypeDefIndex: 4426
		{
			// Properties
			public override string Name { get; } // 0x0000000182527760-0x0000000182527790 
			public override string ussName { get; } // 0x0000000182527790-0x00000001825277C0 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public HeightProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleLength GetValue(ref InlineStyleAccess container); // 0x0000000182527530-0x0000000182527610
			public override void SetValue(ref InlineStyleAccess container, StyleLength value); // 0x0000000182527610-0x00000001825276F0
		}
	
		private class JustifyContentProperty : InlineStyleEnumProperty<Justify> // TypeDefIndex: 4427
		{
			// Properties
			public override string Name { get; } // 0x00000001825349F0-0x0000000182534A20 
			public override string ussName { get; } // 0x0000000182534A80-0x0000000182534AB0 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public JustifyContentProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleEnum<Justify> GetValue(ref InlineStyleAccess container); // 0x00000001825347E0-0x00000001825348A0
			public override void SetValue(ref InlineStyleAccess container, StyleEnum<Justify> value); // 0x00000001825348F0-0x00000001825349B0
		}
	
		private class LeftProperty : InlineStyleLengthProperty // TypeDefIndex: 4428
		{
			// Properties
			public override string Name { get; } // 0x0000000182534D30-0x0000000182534D60 
			public override string ussName { get; } // 0x0000000182534D60-0x0000000182534D90 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public LeftProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleLength GetValue(ref InlineStyleAccess container); // 0x0000000182534AB0-0x0000000182534B90
			public override void SetValue(ref InlineStyleAccess container, StyleLength value); // 0x0000000182534C20-0x0000000182534D00
		}
	
		private class LetterSpacingProperty : InlineStyleLengthProperty // TypeDefIndex: 4429
		{
			// Properties
			public override string Name { get; } // 0x0000000182535010-0x0000000182535040 
			public override string ussName { get; } // 0x00000001825350A0-0x00000001825350D0 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public LetterSpacingProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleLength GetValue(ref InlineStyleAccess container); // 0x0000000182534E10-0x0000000182534EF0
			public override void SetValue(ref InlineStyleAccess container, StyleLength value); // 0x0000000182534F30-0x0000000182535010
		}
	
		private class MarginBottomProperty : InlineStyleLengthProperty // TypeDefIndex: 4430
		{
			// Properties
			public override string Name { get; } // 0x0000000182535320-0x0000000182535350 
			public override string ussName { get; } // 0x0000000182535380-0x00000001825353B0 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public MarginBottomProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleLength GetValue(ref InlineStyleAccess container); // 0x0000000182535120-0x0000000182535200
			public override void SetValue(ref InlineStyleAccess container, StyleLength value); // 0x0000000182535200-0x00000001825352E0
		}
	
		private class MarginLeftProperty : InlineStyleLengthProperty // TypeDefIndex: 4431
		{
			// Properties
			public override string Name { get; } // 0x0000000182535660-0x0000000182535690 
			public override string ussName { get; } // 0x00000001825356C0-0x00000001825356F0 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public MarginLeftProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleLength GetValue(ref InlineStyleAccess container); // 0x00000001825353E0-0x00000001825354C0
			public override void SetValue(ref InlineStyleAccess container, StyleLength value); // 0x0000000182535550-0x0000000182535630
		}
	
		private class MarginRightProperty : InlineStyleLengthProperty // TypeDefIndex: 4432
		{
			// Properties
			public override string Name { get; } // 0x0000000182535940-0x0000000182535970 
			public override string ussName { get; } // 0x00000001825359D0-0x0000000182535A00 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public MarginRightProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleLength GetValue(ref InlineStyleAccess container); // 0x0000000182535740-0x0000000182535820
			public override void SetValue(ref InlineStyleAccess container, StyleLength value); // 0x0000000182535860-0x0000000182535940
		}
	
		private class MarginTopProperty : InlineStyleLengthProperty // TypeDefIndex: 4433
		{
			// Properties
			public override string Name { get; } // 0x0000000182535C50-0x0000000182535C80 
			public override string ussName { get; } // 0x0000000182535CE0-0x0000000182535D10 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public MarginTopProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleLength GetValue(ref InlineStyleAccess container); // 0x0000000182535A00-0x0000000182535AE0
			public override void SetValue(ref InlineStyleAccess container, StyleLength value); // 0x0000000182535B70-0x0000000182535C50
		}
	
		private class MaxHeightProperty : InlineStyleLengthProperty // TypeDefIndex: 4434
		{
			// Properties
			public override string Name { get; } // 0x0000000182535F60-0x0000000182535F90 
			public override string ussName { get; } // 0x0000000182535FF0-0x0000000182536020 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public MaxHeightProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleLength GetValue(ref InlineStyleAccess container); // 0x0000000182535D10-0x0000000182535DF0
			public override void SetValue(ref InlineStyleAccess container, StyleLength value); // 0x0000000182535E80-0x0000000182535F60
		}
	
		private class MaxWidthProperty : InlineStyleLengthProperty // TypeDefIndex: 4435
		{
			// Properties
			public override string Name { get; } // 0x0000000182536270-0x00000001825362A0 
			public override string ussName { get; } // 0x00000001825362D0-0x0000000182536300 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public MaxWidthProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleLength GetValue(ref InlineStyleAccess container); // 0x0000000182536070-0x0000000182536150
			public override void SetValue(ref InlineStyleAccess container, StyleLength value); // 0x0000000182536190-0x0000000182536270
		}
	
		private class MinHeightProperty : InlineStyleLengthProperty // TypeDefIndex: 4436
		{
			// Properties
			public override string Name { get; } // 0x00000001825365B0-0x00000001825365E0 
			public override string ussName { get; } // 0x00000001825365E0-0x0000000182536610 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public MinHeightProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleLength GetValue(ref InlineStyleAccess container); // 0x0000000182536380-0x0000000182536460
			public override void SetValue(ref InlineStyleAccess container, StyleLength value); // 0x00000001825364A0-0x0000000182536580
		}
	
		private class MinWidthProperty : InlineStyleLengthProperty // TypeDefIndex: 4437
		{
			// Properties
			public override string Name { get; } // 0x00000001825368C0-0x00000001825368F0 
			public override string ussName { get; } // 0x00000001825368F0-0x0000000182536920 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public MinWidthProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleLength GetValue(ref InlineStyleAccess container); // 0x0000000182536640-0x0000000182536720
			public override void SetValue(ref InlineStyleAccess container, StyleLength value); // 0x0000000182536770-0x0000000182536850
		}
	
		private class OpacityProperty : InlineStyleFloatProperty // TypeDefIndex: 4438
		{
			// Properties
			public override string Name { get; } // 0x0000000182536AE0-0x0000000182536B10 
			public override string ussName { get; } // 0x0000000182536B70-0x0000000182536BA0 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public OpacityProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleFloat GetValue(ref InlineStyleAccess container); // 0x00000001825369F0-0x0000000182536A40
			public override void SetValue(ref InlineStyleAccess container, StyleFloat value); // 0x0000000182536A80-0x0000000182536AE0
		}
	
		private class OverflowProperty : InlineStyleEnumProperty<Overflow> // TypeDefIndex: 4439
		{
			// Properties
			public override string Name { get; } // 0x0000000182536D20-0x0000000182536D50 
			public override string ussName { get; } // 0x0000000182536D50-0x0000000182536D80 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public OverflowProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleEnum<Overflow> GetValue(ref InlineStyleAccess container); // 0x0000000182536BA0-0x0000000182536C60
			public override void SetValue(ref InlineStyleAccess container, StyleEnum<Overflow> value); // 0x0000000182536C60-0x0000000182536D20
		}
	
		private class PaddingBottomProperty : InlineStyleLengthProperty // TypeDefIndex: 4440
		{
			// Properties
			public override string Name { get; } // 0x0000000182537000-0x0000000182537030 
			public override string ussName { get; } // 0x0000000182537030-0x0000000182537060 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public PaddingBottomProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleLength GetValue(ref InlineStyleAccess container); // 0x0000000182536D80-0x0000000182536E60
			public override void SetValue(ref InlineStyleAccess container, StyleLength value); // 0x0000000182536EF0-0x0000000182536FD0
		}
	
		private class PaddingLeftProperty : InlineStyleLengthProperty // TypeDefIndex: 4441
		{
			// Properties
			public override string Name { get; } // 0x0000000182537310-0x0000000182537340 
			public override string ussName { get; } // 0x0000000182537370-0x00000001825373A0 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public PaddingLeftProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleLength GetValue(ref InlineStyleAccess container); // 0x0000000182537090-0x0000000182537170
			public override void SetValue(ref InlineStyleAccess container, StyleLength value); // 0x00000001825371C0-0x00000001825372A0
		}
	
		private class PaddingRightProperty : InlineStyleLengthProperty // TypeDefIndex: 4442
		{
			// Properties
			public override string Name { get; } // 0x00000001825375F0-0x0000000182537620 
			public override string ussName { get; } // 0x0000000182537650-0x0000000182537680 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public PaddingRightProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleLength GetValue(ref InlineStyleAccess container); // 0x00000001825373F0-0x00000001825374D0
			public override void SetValue(ref InlineStyleAccess container, StyleLength value); // 0x00000001825374D0-0x00000001825375B0
		}
	
		private class PaddingTopProperty : InlineStyleLengthProperty // TypeDefIndex: 4443
		{
			// Properties
			public override string Name { get; } // 0x0000000182537900-0x0000000182537930 
			public override string ussName { get; } // 0x0000000182537990-0x00000001825379C0 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public PaddingTopProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleLength GetValue(ref InlineStyleAccess container); // 0x0000000182537700-0x00000001825377E0
			public override void SetValue(ref InlineStyleAccess container, StyleLength value); // 0x00000001825377E0-0x00000001825378C0
		}
	
		private class PositionProperty : InlineStyleEnumProperty<Position> // TypeDefIndex: 4444
		{
			// Properties
			public override string Name { get; } // 0x0000000182537C00-0x0000000182537C30 
			public override string ussName { get; } // 0x0000000182537C30-0x0000000182537C60 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public PositionProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleEnum<Position> GetValue(ref InlineStyleAccess container); // 0x0000000182537A10-0x0000000182537AD0
			public override void SetValue(ref InlineStyleAccess container, StyleEnum<Position> value); // 0x0000000182537AD0-0x0000000182537B90
		}
	
		private class RightProperty : InlineStyleLengthProperty // TypeDefIndex: 4445
		{
			// Properties
			public override string Name { get; } // 0x000000018253C350-0x000000018253C380 
			public override string ussName { get; } // 0x000000018253C3E0-0x000000018253C410 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public RightProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleLength GetValue(ref InlineStyleAccess container); // 0x000000018253C100-0x000000018253C1E0
			public override void SetValue(ref InlineStyleAccess container, StyleLength value); // 0x000000018253C230-0x000000018253C310
		}
	
		private class RotateProperty : InlineStyleRotateProperty // TypeDefIndex: 4446
		{
			// Properties
			public override string Name { get; } // 0x000000018253C6C0-0x000000018253C6F0 
			public override string ussName { get; } // 0x000000018253C6F0-0x000000018253C720 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public RotateProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleRotate GetValue(ref InlineStyleAccess container); // 0x000000018253C410-0x000000018253C490
			public override void SetValue(ref InlineStyleAccess container, StyleRotate value); // 0x000000018253C5B0-0x000000018253C690
		}
	
		private class RowGapProperty : InlineStyleLengthProperty // TypeDefIndex: 4447
		{
			// Properties
			public override string Name { get; } // 0x000000018253C9A0-0x000000018253C9D0 
			public override string ussName { get; } // 0x000000018253CA00-0x000000018253CA30 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public RowGapProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleLength GetValue(ref InlineStyleAccess container); // 0x000000018253C7A0-0x000000018253C880
			public override void SetValue(ref InlineStyleAccess container, StyleLength value); // 0x000000018253C880-0x000000018253C960
		}
	
		private class ScaleProperty : InlineStyleScaleProperty // TypeDefIndex: 4448
		{
			// Properties
			public override string Name { get; } // 0x000000018253CD60-0x000000018253CD90 
			public override string ussName { get; } // 0x000000018253CD90-0x000000018253CDC0 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public ScaleProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleScale GetValue(ref InlineStyleAccess container); // 0x000000018253CB30-0x000000018253CC10
			public override void SetValue(ref InlineStyleAccess container, StyleScale value); // 0x000000018253CC10-0x000000018253CCF0
		}
	
		private class TextOverflowProperty : InlineStyleEnumProperty<TextOverflow> // TypeDefIndex: 4449
		{
			// Properties
			public override string Name { get; } // 0x000000018253D030-0x000000018253D060 
			public override string ussName { get; } // 0x000000018253D090-0x000000018253D0C0 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public TextOverflowProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleEnum<TextOverflow> GetValue(ref InlineStyleAccess container); // 0x000000018253CDF0-0x000000018253CEB0
			public override void SetValue(ref InlineStyleAccess container, StyleEnum<TextOverflow> value); // 0x000000018253CF00-0x000000018253CFC0
		}
	
		private class TextShadowProperty : InlineStyleTextShadowProperty // TypeDefIndex: 4450
		{
			// Properties
			public override string Name { get; } // 0x000000018253D3D0-0x000000018253D400 
			public override string ussName { get; } // 0x000000018253D400-0x000000018253D430 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public TextShadowProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleTextShadow GetValue(ref InlineStyleAccess container); // 0x000000018253D1A0-0x000000018253D280
			public override void SetValue(ref InlineStyleAccess container, StyleTextShadow value); // 0x000000018253D280-0x000000018253D360
		}
	
		private class TopProperty : InlineStyleLengthProperty // TypeDefIndex: 4451
		{
			// Properties
			public override string Name { get; } // 0x000000018253D620-0x000000018253D650 
			public override string ussName { get; } // 0x000000018253D650-0x000000018253D680 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public TopProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleLength GetValue(ref InlineStyleAccess container); // 0x000000018253D460-0x000000018253D540
			public override void SetValue(ref InlineStyleAccess container, StyleLength value); // 0x000000018253D540-0x000000018253D620
		}
	
		private class TransformOriginProperty : InlineStyleTransformOriginProperty // TypeDefIndex: 4452
		{
			// Properties
			public override string Name { get; } // 0x000000018253D840-0x000000018253D870 
			public override string ussName { get; } // 0x000000018253D870-0x000000018253D8A0 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public TransformOriginProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleTransformOrigin GetValue(ref InlineStyleAccess container); // 0x000000018253D680-0x000000018253D760
			public override void SetValue(ref InlineStyleAccess container, StyleTransformOrigin value); // 0x000000018253D760-0x000000018253D840
		}
	
		private class TransitionDelayProperty : InlineStyleListProperty<TimeValue> // TypeDefIndex: 4453
		{
			// Properties
			public override string Name { get; } // 0x000000018253DA40-0x000000018253DA70 
			public override string ussName { get; } // 0x000000018253DA70-0x000000018253DAA0 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public TransitionDelayProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleList<TimeValue> GetValue(ref InlineStyleAccess container); // 0x000000018253D8A0-0x000000018253D970
			public override void SetValue(ref InlineStyleAccess container, StyleList<TimeValue> value); // 0x000000018253D970-0x000000018253DA40
		}
	
		private class TransitionDurationProperty : InlineStyleListProperty<TimeValue> // TypeDefIndex: 4454
		{
			// Properties
			public override string Name { get; } // 0x000000018253DC40-0x000000018253DC70 
			public override string ussName { get; } // 0x000000018253DC70-0x000000018253DCA0 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public TransitionDurationProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleList<TimeValue> GetValue(ref InlineStyleAccess container); // 0x000000018253DAA0-0x000000018253DB70
			public override void SetValue(ref InlineStyleAccess container, StyleList<TimeValue> value); // 0x000000018253DB70-0x000000018253DC40
		}
	
		private class TransitionPropertyProperty : InlineStyleListProperty<StylePropertyName> // TypeDefIndex: 4455
		{
			// Properties
			public override string Name { get; } // 0x000000018253DE40-0x000000018253DE70 
			public override string ussName { get; } // 0x000000018253DE70-0x000000018253DEA0 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public TransitionPropertyProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleList<StylePropertyName> GetValue(ref InlineStyleAccess container); // 0x000000018253DCA0-0x000000018253DD70
			public override void SetValue(ref InlineStyleAccess container, StyleList<StylePropertyName> value); // 0x000000018253DD70-0x000000018253DE40
		}
	
		private class TransitionTimingFunctionProperty : InlineStyleListProperty<EasingFunction> // TypeDefIndex: 4456
		{
			// Properties
			public override string Name { get; } // 0x000000018253E040-0x000000018253E070 
			public override string ussName { get; } // 0x000000018253E070-0x000000018253E0A0 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public TransitionTimingFunctionProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleList<EasingFunction> GetValue(ref InlineStyleAccess container); // 0x000000018253DEA0-0x000000018253DF70
			public override void SetValue(ref InlineStyleAccess container, StyleList<EasingFunction> value); // 0x000000018253DF70-0x000000018253E040
		}
	
		private class TranslateProperty : InlineStyleTranslateProperty // TypeDefIndex: 4457
		{
			// Properties
			public override string Name { get; } // 0x000000018253E210-0x000000018253E240 
			public override string ussName { get; } // 0x000000018253E240-0x000000018253E270 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public TranslateProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleTranslate GetValue(ref InlineStyleAccess container); // 0x000000018253E0A0-0x000000018253E120
			public override void SetValue(ref InlineStyleAccess container, StyleTranslate value); // 0x000000018253E120-0x000000018253E210
		}
	
		private class UnityAnimationClipProperty : InlineStyleUIAnimationClipProperty // TypeDefIndex: 4458
		{
			// Properties
			public override string Name { get; } // 0x000000018253E610-0x000000018253E640 
			public override string ussName { get; } // 0x000000018253E640-0x000000018253E670 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public UnityAnimationClipProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleUIAnimationClip GetValue(ref InlineStyleAccess container); // 0x000000018253E470-0x000000018253E540
			public override void SetValue(ref InlineStyleAccess container, StyleUIAnimationClip value); // 0x000000018253E540-0x000000018253E610
		}
	
		private class UnityBackgroundImageTintColorProperty : InlineStyleColorProperty // TypeDefIndex: 4459
		{
			// Properties
			public override string Name { get; } // 0x000000018253E830-0x000000018253E860 
			public override string ussName { get; } // 0x000000018253E860-0x000000018253E890 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public UnityBackgroundImageTintColorProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleColor GetValue(ref InlineStyleAccess container); // 0x000000018253E670-0x000000018253E750
			public override void SetValue(ref InlineStyleAccess container, StyleColor value); // 0x000000018253E750-0x000000018253E830
		}
	
		private class UnityEditorTextRenderingModeProperty : InlineStyleEnumProperty<EditorTextRenderingMode> // TypeDefIndex: 4460
		{
			// Properties
			public override string Name { get; } // 0x000000018253EA10-0x000000018253EA40 
			public override string ussName { get; } // 0x000000018253EA40-0x000000018253EA70 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public UnityEditorTextRenderingModeProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleEnum<EditorTextRenderingMode> GetValue(ref InlineStyleAccess container); // 0x000000018253E890-0x000000018253E950
			public override void SetValue(ref InlineStyleAccess container, StyleEnum<EditorTextRenderingMode> value); // 0x000000018253E950-0x000000018253EA10
		}
	
		private class UnityFontProperty : InlineStyleFontProperty // TypeDefIndex: 4461
		{
			// Properties
			public override string Name { get; } // 0x000000018253EE30-0x000000018253EE60 
			public override string ussName { get; } // 0x000000018253EE60-0x000000018253EE90 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public UnityFontProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleFont GetValue(ref InlineStyleAccess container); // 0x000000018253EC90-0x000000018253ED60
			public override void SetValue(ref InlineStyleAccess container, StyleFont value); // 0x000000018253ED60-0x000000018253EE30
		}
	
		private class UnityFontDefinitionProperty : InlineStyleFontDefinitionProperty // TypeDefIndex: 4462
		{
			// Properties
			public override string Name { get; } // 0x000000018253EC30-0x000000018253EC60 
			public override string ussName { get; } // 0x000000018253EC60-0x000000018253EC90 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public UnityFontDefinitionProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleFontDefinition GetValue(ref InlineStyleAccess container); // 0x000000018253EA70-0x000000018253EB50
			public override void SetValue(ref InlineStyleAccess container, StyleFontDefinition value); // 0x000000018253EB50-0x000000018253EC30
		}
	
		private class UnityFontStyleAndWeightProperty : InlineStyleEnumProperty<FontStyle> // TypeDefIndex: 4463
		{
			// Properties
			public override string Name { get; } // 0x000000018253F010-0x000000018253F040 
			public override string ussName { get; } // 0x000000018253F040-0x000000018253F070 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public UnityFontStyleAndWeightProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleEnum<FontStyle> GetValue(ref InlineStyleAccess container); // 0x000000018253EE90-0x000000018253EF50
			public override void SetValue(ref InlineStyleAccess container, StyleEnum<FontStyle> value); // 0x000000018253EF50-0x000000018253F010
		}
	
		private class UnityMaterialProperty : InlineStyleMaterialDefinitionProperty // TypeDefIndex: 4464
		{
			// Properties
			public override string Name { get; } // 0x000000018253F230-0x000000018253F260 
			public override string ussName { get; } // 0x000000018253F260-0x000000018253F290 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public UnityMaterialProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleMaterialDefinition GetValue(ref InlineStyleAccess container); // 0x000000018253F070-0x000000018253F150
			public override void SetValue(ref InlineStyleAccess container, StyleMaterialDefinition value); // 0x000000018253F150-0x000000018253F230
		}
	
		private class UnityOverflowClipBoxProperty : InlineStyleEnumProperty<OverflowClipBox> // TypeDefIndex: 4465
		{
			// Properties
			public override string Name { get; } // 0x000000018253F410-0x000000018253F440 
			public override string ussName { get; } // 0x000000018253F440-0x000000018253F470 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public UnityOverflowClipBoxProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleEnum<OverflowClipBox> GetValue(ref InlineStyleAccess container); // 0x000000018253F290-0x000000018253F350
			public override void SetValue(ref InlineStyleAccess container, StyleEnum<OverflowClipBox> value); // 0x000000018253F350-0x000000018253F410
		}
	
		private class UnityParagraphSpacingProperty : InlineStyleLengthProperty // TypeDefIndex: 4466
		{
			// Properties
			public override string Name { get; } // 0x000000018253F630-0x000000018253F660 
			public override string ussName { get; } // 0x000000018253F660-0x000000018253F690 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public UnityParagraphSpacingProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleLength GetValue(ref InlineStyleAccess container); // 0x000000018253F470-0x000000018253F550
			public override void SetValue(ref InlineStyleAccess container, StyleLength value); // 0x000000018253F550-0x000000018253F630
		}
	
		private class UnitySliceBottomProperty : InlineStyleIntProperty // TypeDefIndex: 4467
		{
			// Properties
			public override string Name { get; } // 0x000000018253F740-0x000000018253F770 
			public override string ussName { get; } // 0x000000018253F770-0x000000018253F7A0 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public UnitySliceBottomProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleInt GetValue(ref InlineStyleAccess container); // 0x000000018253F690-0x000000018253F6E0
			public override void SetValue(ref InlineStyleAccess container, StyleInt value); // 0x000000018253F6E0-0x000000018253F740
		}
	
		private class UnitySliceLeftProperty : InlineStyleIntProperty // TypeDefIndex: 4468
		{
			// Properties
			public override string Name { get; } // 0x000000018253F850-0x000000018253F880 
			public override string ussName { get; } // 0x000000018253F880-0x000000018253F8B0 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public UnitySliceLeftProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleInt GetValue(ref InlineStyleAccess container); // 0x000000018253F7A0-0x000000018253F7F0
			public override void SetValue(ref InlineStyleAccess container, StyleInt value); // 0x000000018253F7F0-0x000000018253F850
		}
	
		private class UnitySliceRightProperty : InlineStyleIntProperty // TypeDefIndex: 4469
		{
			// Properties
			public override string Name { get; } // 0x000000018253F960-0x000000018253F990 
			public override string ussName { get; } // 0x000000018253F990-0x000000018253F9C0 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public UnitySliceRightProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleInt GetValue(ref InlineStyleAccess container); // 0x000000018253F8B0-0x000000018253F900
			public override void SetValue(ref InlineStyleAccess container, StyleInt value); // 0x000000018253F900-0x000000018253F960
		}
	
		private class UnitySliceScaleProperty : InlineStyleFloatProperty // TypeDefIndex: 4470
		{
			// Properties
			public override string Name { get; } // 0x000000018253FA70-0x000000018253FAA0 
			public override string ussName { get; } // 0x000000018253FAA0-0x000000018253FAD0 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public UnitySliceScaleProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleFloat GetValue(ref InlineStyleAccess container); // 0x000000018253F9C0-0x000000018253FA10
			public override void SetValue(ref InlineStyleAccess container, StyleFloat value); // 0x000000018253FA10-0x000000018253FA70
		}
	
		private class UnitySliceTopProperty : InlineStyleIntProperty // TypeDefIndex: 4471
		{
			// Properties
			public override string Name { get; } // 0x000000018253FB80-0x000000018253FBB0 
			public override string ussName { get; } // 0x000000018253FBB0-0x000000018253FBE0 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public UnitySliceTopProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleInt GetValue(ref InlineStyleAccess container); // 0x000000018253FAD0-0x000000018253FB20
			public override void SetValue(ref InlineStyleAccess container, StyleInt value); // 0x000000018253FB20-0x000000018253FB80
		}
	
		private class UnitySliceTypeProperty : InlineStyleEnumProperty<SliceType> // TypeDefIndex: 4472
		{
			// Properties
			public override string Name { get; } // 0x000000018253FD60-0x000000018253FD90 
			public override string ussName { get; } // 0x000000018253FD90-0x000000018253FDC0 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public UnitySliceTypeProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleEnum<SliceType> GetValue(ref InlineStyleAccess container); // 0x000000018253FBE0-0x000000018253FCA0
			public override void SetValue(ref InlineStyleAccess container, StyleEnum<SliceType> value); // 0x000000018253FCA0-0x000000018253FD60
		}
	
		private class UnityTextAlignProperty : InlineStyleEnumProperty<TextAnchor> // TypeDefIndex: 4473
		{
			// Properties
			public override string Name { get; } // 0x000000018253FF40-0x000000018253FF70 
			public override string ussName { get; } // 0x000000018253FF70-0x000000018253FFA0 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public UnityTextAlignProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleEnum<TextAnchor> GetValue(ref InlineStyleAccess container); // 0x000000018253FDC0-0x000000018253FE80
			public override void SetValue(ref InlineStyleAccess container, StyleEnum<TextAnchor> value); // 0x000000018253FE80-0x000000018253FF40
		}
	
		private class UnityTextAutoSizeProperty : InlineStyleTextAutoSizeProperty // TypeDefIndex: 4474
		{
			// Properties
			public override string Name { get; } // 0x0000000182540160-0x0000000182540190 
			public override string ussName { get; } // 0x0000000182540190-0x00000001825401C0 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public UnityTextAutoSizeProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleTextAutoSize GetValue(ref InlineStyleAccess container); // 0x000000018253FFA0-0x0000000182540080
			public override void SetValue(ref InlineStyleAccess container, StyleTextAutoSize value); // 0x0000000182540080-0x0000000182540160
		}
	
		private class UnityTextGeneratorProperty : InlineStyleEnumProperty<TextGeneratorType> // TypeDefIndex: 4475
		{
			// Properties
			public override string Name { get; } // 0x0000000182540340-0x0000000182540370 
			public override string ussName { get; } // 0x0000000182540370-0x00000001825403A0 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public UnityTextGeneratorProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleEnum<TextGeneratorType> GetValue(ref InlineStyleAccess container); // 0x00000001825401C0-0x0000000182540280
			public override void SetValue(ref InlineStyleAccess container, StyleEnum<TextGeneratorType> value); // 0x0000000182540280-0x0000000182540340
		}
	
		private class UnityTextOutlineColorProperty : InlineStyleColorProperty // TypeDefIndex: 4476
		{
			// Properties
			public override string Name { get; } // 0x0000000182540560-0x0000000182540590 
			public override string ussName { get; } // 0x0000000182540590-0x00000001825405C0 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public UnityTextOutlineColorProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleColor GetValue(ref InlineStyleAccess container); // 0x00000001825403A0-0x0000000182540480
			public override void SetValue(ref InlineStyleAccess container, StyleColor value); // 0x0000000182540480-0x0000000182540560
		}
	
		private class UnityTextOutlineWidthProperty : InlineStyleFloatProperty // TypeDefIndex: 4477
		{
			// Properties
			public override string Name { get; } // 0x0000000182540670-0x00000001825406A0 
			public override string ussName { get; } // 0x00000001825406A0-0x00000001825406D0 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public UnityTextOutlineWidthProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleFloat GetValue(ref InlineStyleAccess container); // 0x00000001825405C0-0x0000000182540610
			public override void SetValue(ref InlineStyleAccess container, StyleFloat value); // 0x0000000182540610-0x0000000182540670
		}
	
		private class UnityTextOverflowPositionProperty : InlineStyleEnumProperty<TextOverflowPosition> // TypeDefIndex: 4478
		{
			// Properties
			public override string Name { get; } // 0x0000000182540850-0x0000000182540880 
			public override string ussName { get; } // 0x0000000182540880-0x00000001825408B0 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public UnityTextOverflowPositionProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleEnum<TextOverflowPosition> GetValue(ref InlineStyleAccess container); // 0x00000001825406D0-0x0000000182540790
			public override void SetValue(ref InlineStyleAccess container, StyleEnum<TextOverflowPosition> value); // 0x0000000182540790-0x0000000182540850
		}
	
		private class VisibilityProperty : InlineStyleEnumProperty<Visibility> // TypeDefIndex: 4479
		{
			// Properties
			public override string Name { get; } // 0x0000000182541570-0x00000001825415A0 
			public override string ussName { get; } // 0x00000001825415A0-0x00000001825415D0 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public VisibilityProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleEnum<Visibility> GetValue(ref InlineStyleAccess container); // 0x00000001825413F0-0x00000001825414B0
			public override void SetValue(ref InlineStyleAccess container, StyleEnum<Visibility> value); // 0x00000001825414B0-0x0000000182541570
		}
	
		private class WhiteSpaceProperty : InlineStyleEnumProperty<WhiteSpace> // TypeDefIndex: 4480
		{
			// Properties
			public override string Name { get; } // 0x0000000182541750-0x0000000182541780 
			public override string ussName { get; } // 0x0000000182541780-0x00000001825417B0 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public WhiteSpaceProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleEnum<WhiteSpace> GetValue(ref InlineStyleAccess container); // 0x00000001825415D0-0x0000000182541690
			public override void SetValue(ref InlineStyleAccess container, StyleEnum<WhiteSpace> value); // 0x0000000182541690-0x0000000182541750
		}
	
		private class WidthProperty : InlineStyleLengthProperty // TypeDefIndex: 4481
		{
			// Properties
			public override string Name { get; } // 0x0000000182541970-0x00000001825419A0 
			public override string ussName { get; } // 0x00000001825419A0-0x00000001825419D0 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public WidthProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleLength GetValue(ref InlineStyleAccess container); // 0x00000001825417B0-0x0000000182541890
			public override void SetValue(ref InlineStyleAccess container, StyleLength value); // 0x0000000182541890-0x0000000182541970
		}
	
		private class WordSpacingProperty : InlineStyleLengthProperty // TypeDefIndex: 4482
		{
			// Properties
			public override string Name { get; } // 0x0000000182541B90-0x0000000182541BC0 
			public override string ussName { get; } // 0x0000000182541BC0-0x0000000182541BF0 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public WordSpacingProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override StyleLength GetValue(ref InlineStyleAccess container); // 0x00000001825419D0-0x0000000182541AB0
			public override void SetValue(ref InlineStyleAccess container, StyleLength value); // 0x0000000182541AB0-0x0000000182541B90
		}
	
		internal interface IStyleProperty : IProperty<InlineStyleAccess> // TypeDefIndex: 4483
		{
			// Properties
			string ussName { get; }
		}
	
		private abstract class InlineStyleProperty<TStyleValue> : Property<InlineStyleAccess, TStyleValue>, IStyleProperty // TypeDefIndex: 4484
		{
			// Properties
			public abstract string ussName { get; }
	
			// Constructors
			protected InlineStyleProperty();
		}
	
		private abstract class InlineStyleEnumProperty<TValue> : InlineStyleProperty<StyleEnum<TValue>> // TypeDefIndex: 4485
			where TValue : struct, IConvertible
		{
			// Constructors
			protected InlineStyleEnumProperty();
		}
	
		private abstract class InlineStyleColorProperty : InlineStyleProperty<StyleColor> // TypeDefIndex: 4486
		{
			// Constructors
			protected InlineStyleColorProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
		}
	
		private abstract class InlineStyleRatioProperty : InlineStyleProperty<StyleRatio> // TypeDefIndex: 4487
		{
			// Constructors
			protected InlineStyleRatioProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
		}
	
		private abstract class InlineStyleBackgroundProperty : InlineStyleProperty<StyleBackground> // TypeDefIndex: 4488
		{
			// Constructors
			protected InlineStyleBackgroundProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
		}
	
		private abstract class InlineStyleLengthProperty : InlineStyleProperty<StyleLength> // TypeDefIndex: 4489
		{
			// Constructors
			protected InlineStyleLengthProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
		}
	
		private abstract class InlineStyleFloatProperty : InlineStyleProperty<StyleFloat> // TypeDefIndex: 4490
		{
			// Constructors
			protected InlineStyleFloatProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
		}
	
		private abstract class InlineStyleListProperty<T> : InlineStyleProperty<StyleList<T>> // TypeDefIndex: 4491
		{
			// Constructors
			protected InlineStyleListProperty();
		}
	
		private abstract class InlineStyleFontProperty : InlineStyleProperty<StyleFont> // TypeDefIndex: 4492
		{
			// Constructors
			protected InlineStyleFontProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
		}
	
		private abstract class InlineStyleFontDefinitionProperty : InlineStyleProperty<StyleFontDefinition> // TypeDefIndex: 4493
		{
			// Constructors
			protected InlineStyleFontDefinitionProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
		}
	
		private abstract class InlineStyleIntProperty : InlineStyleProperty<StyleInt> // TypeDefIndex: 4494
		{
			// Constructors
			protected InlineStyleIntProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
		}
	
		private abstract class InlineStyleRotateProperty : InlineStyleProperty<StyleRotate> // TypeDefIndex: 4495
		{
			// Constructors
			protected InlineStyleRotateProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
		}
	
		private abstract class InlineStyleScaleProperty : InlineStyleProperty<StyleScale> // TypeDefIndex: 4496
		{
			// Constructors
			protected InlineStyleScaleProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
		}
	
		private abstract class InlineStyleCursorProperty : InlineStyleProperty<StyleCursor> // TypeDefIndex: 4497
		{
			// Constructors
			protected InlineStyleCursorProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
		}
	
		private abstract class InlineStyleTextShadowProperty : InlineStyleProperty<StyleTextShadow> // TypeDefIndex: 4498
		{
			// Constructors
			protected InlineStyleTextShadowProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
		}
	
		private abstract class InlineStyleTextAutoSizeProperty : InlineStyleProperty<StyleTextAutoSize> // TypeDefIndex: 4499
		{
			// Constructors
			protected InlineStyleTextAutoSizeProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
		}
	
		private abstract class InlineStyleTransformOriginProperty : InlineStyleProperty<StyleTransformOrigin> // TypeDefIndex: 4500
		{
			// Constructors
			protected InlineStyleTransformOriginProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
		}
	
		private abstract class InlineStyleTranslateProperty : InlineStyleProperty<StyleTranslate> // TypeDefIndex: 4501
		{
			// Constructors
			protected InlineStyleTranslateProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
		}
	
		private abstract class InlineStyleBackgroundPositionProperty : InlineStyleProperty<StyleBackgroundPosition> // TypeDefIndex: 4502
		{
			// Constructors
			protected InlineStyleBackgroundPositionProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
		}
	
		private abstract class InlineStyleBackgroundRepeatProperty : InlineStyleProperty<StyleBackgroundRepeat> // TypeDefIndex: 4503
		{
			// Constructors
			protected InlineStyleBackgroundRepeatProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
		}
	
		private abstract class InlineStyleBackgroundSizeProperty : InlineStyleProperty<StyleBackgroundSize> // TypeDefIndex: 4504
		{
			// Constructors
			protected InlineStyleBackgroundSizeProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
		}
	
		private abstract class InlineStyleMaterialDefinitionProperty : InlineStyleProperty<StyleMaterialDefinition> // TypeDefIndex: 4505
		{
			// Constructors
			protected InlineStyleMaterialDefinitionProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
		}
	
		private abstract class InlineStyleUIAnimationClipProperty : InlineStyleProperty<StyleUIAnimationClip> // TypeDefIndex: 4506
		{
			// Constructors
			protected InlineStyleUIAnimationClipProperty(); // 0x0000000180A6DF30-0x0000000180A6DF40
		}
	
		// Constructors
		public InlineStyleAccessPropertyBag(); // 0x0000000182527B70-0x000000018252A5E0
	
		// Methods
		private void AddPropertyRange(params IStyleProperty[] properties); // 0x00000001825277F0-0x0000000182527B00
		public override PropertyCollection<InlineStyleAccess> GetProperties(); // 0x0000000180DE7660-0x0000000180DE7690
		public override PropertyCollection<InlineStyleAccess> GetProperties(ref InlineStyleAccess container); // 0x0000000180DE7660-0x0000000180DE7690
		public bool TryGetProperty(ref InlineStyleAccess container, string name, out IProperty<InlineStyleAccess> property); // 0x0000000182527B00-0x0000000182527B70
	}
}
