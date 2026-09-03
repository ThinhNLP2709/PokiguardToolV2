/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Utilities;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem
{
	internal class FastKeyboard : Keyboard // TypeDefIndex: 6169
	{
		// Fields
		public const string metadata = ";AnyKey;Button;Axis;Key;DiscreteButton;Keyboard"; // Metadata: 0x00698B58
	
		// Constructors
		public FastKeyboard(); // 0x0000000181D2EBC0-0x0000000181D34530
	
		// Methods
		private AnyKeyControl Initialize_ctrlKeyboardanyKey(InternedString kAnyKeyLayout, InputControl parent); // 0x0000000181D1D940-0x0000000181D1DBB0
		private KeyControl Initialize_ctrlKeyboardescape(InternedString kKeyLayout, InputControl parent); // 0x0000000181D20310-0x0000000181D20590
		private KeyControl Initialize_ctrlKeyboardspace(InternedString kKeyLayout, InputControl parent); // 0x0000000181D2D360-0x0000000181D2D5D0
		private KeyControl Initialize_ctrlKeyboardenter(InternedString kKeyLayout, InputControl parent); // 0x0000000181D1FE20-0x0000000181D200A0
		private KeyControl Initialize_ctrlKeyboardtab(InternedString kKeyLayout, InputControl parent); // 0x0000000181D2D840-0x0000000181D2DAB0
		private KeyControl Initialize_ctrlKeyboardbackquote(InternedString kKeyLayout, InputControl parent); // 0x0000000181D1DE20-0x0000000181D1E090
		private KeyControl Initialize_ctrlKeyboardquote(InternedString kKeyLayout, InputControl parent); // 0x0000000181D2B300-0x0000000181D2B570
		private KeyControl Initialize_ctrlKeyboardsemicolon(InternedString kKeyLayout, InputControl parent); // 0x0000000181D2CBD0-0x0000000181D2CE40
		private KeyControl Initialize_ctrlKeyboardcomma(InternedString kKeyLayout, InputControl parent); // 0x0000000181D1EA50-0x0000000181D1ECC0
		private KeyControl Initialize_ctrlKeyboardperiod(InternedString kKeyLayout, InputControl parent); // 0x0000000181D2ABB0-0x0000000181D2AE20
		private KeyControl Initialize_ctrlKeyboardslash(InternedString kKeyLayout, InputControl parent); // 0x0000000181D2D0F0-0x0000000181D2D360
		private KeyControl Initialize_ctrlKeyboardbackslash(InternedString kKeyLayout, InputControl parent); // 0x0000000181D1E090-0x0000000181D1E300
		private KeyControl Initialize_ctrlKeyboardleftBracket(InternedString kKeyLayout, InputControl parent); // 0x0000000181D25AF0-0x0000000181D25D60
		private KeyControl Initialize_ctrlKeyboardrightBracket(InternedString kKeyLayout, InputControl parent); // 0x0000000181D2BCE0-0x0000000181D2BF50
		private KeyControl Initialize_ctrlKeyboardminus(InternedString kKeyLayout, InputControl parent); // 0x0000000181D26EC0-0x0000000181D27130
		private KeyControl Initialize_ctrlKeyboardequals(InternedString kKeyLayout, InputControl parent); // 0x0000000181D200A0-0x0000000181D20310
		private KeyControl Initialize_ctrlKeyboardupArrow(InternedString kKeyLayout, InputControl parent); // 0x0000000181D2DD20-0x0000000181D2DF90
		private KeyControl Initialize_ctrlKeyboarddownArrow(InternedString kKeyLayout, InputControl parent); // 0x0000000181D1F6D0-0x0000000181D1F940
		private KeyControl Initialize_ctrlKeyboardleftArrow(InternedString kKeyLayout, InputControl parent); // 0x0000000181D25880-0x0000000181D25AF0
		private KeyControl Initialize_ctrlKeyboardrightArrow(InternedString kKeyLayout, InputControl parent); // 0x0000000181D2BA70-0x0000000181D2BCE0
		private KeyControl Initialize_ctrlKeyboarda(InternedString kKeyLayout, InputControl parent); // 0x0000000181D1D420-0x0000000181D1D690
		private KeyControl Initialize_ctrlKeyboardb(InternedString kKeyLayout, InputControl parent); // 0x0000000181D1DBB0-0x0000000181D1DE20
		private KeyControl Initialize_ctrlKeyboardc(InternedString kKeyLayout, InputControl parent); // 0x0000000181D1E570-0x0000000181D1E7E0
		private KeyControl Initialize_ctrlKeyboardd(InternedString kKeyLayout, InputControl parent); // 0x0000000181D1F1F0-0x0000000181D1F460
		private KeyControl Initialize_ctrlKeyboarde(InternedString kKeyLayout, InputControl parent); // 0x0000000181D1F940-0x0000000181D1FBB0
		private KeyControl Initialize_ctrlKeyboardf(InternedString kKeyLayout, InputControl parent); // 0x0000000181D24010-0x0000000181D24280
		private KeyControl Initialize_ctrlKeyboardg(InternedString kKeyLayout, InputControl parent); // 0x0000000181D24280-0x0000000181D244F0
		private KeyControl Initialize_ctrlKeyboardh(InternedString kKeyLayout, InputControl parent); // 0x0000000181D244F0-0x0000000181D24760
		private KeyControl Initialize_ctrlKeyboardi(InternedString kKeyLayout, InputControl parent); // 0x0000000181D249D0-0x0000000181D24C40
		private KeyControl Initialize_ctrlKeyboardj(InternedString kKeyLayout, InputControl parent); // 0x0000000181D24EB0-0x0000000181D25120
		private KeyControl Initialize_ctrlKeyboardk(InternedString kKeyLayout, InputControl parent); // 0x0000000181D25120-0x0000000181D25390
		private KeyControl Initialize_ctrlKeyboardl(InternedString kKeyLayout, InputControl parent); // 0x0000000181D25390-0x0000000181D25600
		private KeyControl Initialize_ctrlKeyboardm(InternedString kKeyLayout, InputControl parent); // 0x0000000181D26500-0x0000000181D26770
		private KeyControl Initialize_ctrlKeyboardn(InternedString kKeyLayout, InputControl parent); // 0x0000000181D27130-0x0000000181D273A0
		private KeyControl Initialize_ctrlKeyboardo(InternedString kKeyLayout, InputControl parent); // 0x0000000181D29F80-0x0000000181D2A1F0
		private KeyControl Initialize_ctrlKeyboardp(InternedString kKeyLayout, InputControl parent); // 0x0000000181D2A1F0-0x0000000181D2A460
		private KeyControl Initialize_ctrlKeyboardq(InternedString kKeyLayout, InputControl parent); // 0x0000000181D2B090-0x0000000181D2B300
		private KeyControl Initialize_ctrlKeyboardr(InternedString kKeyLayout, InputControl parent); // 0x0000000181D2B570-0x0000000181D2B7E0
		private KeyControl Initialize_ctrlKeyboards(InternedString kKeyLayout, InputControl parent); // 0x0000000181D2C6F0-0x0000000181D2C960
		private KeyControl Initialize_ctrlKeyboardt(InternedString kKeyLayout, InputControl parent); // 0x0000000181D2D5D0-0x0000000181D2D840
		private KeyControl Initialize_ctrlKeyboardu(InternedString kKeyLayout, InputControl parent); // 0x0000000181D2DAB0-0x0000000181D2DD20
		private KeyControl Initialize_ctrlKeyboardv(InternedString kKeyLayout, InputControl parent); // 0x0000000181D2DF90-0x0000000181D2E200
		private KeyControl Initialize_ctrlKeyboardw(InternedString kKeyLayout, InputControl parent); // 0x0000000181D2E200-0x0000000181D2E470
		private KeyControl Initialize_ctrlKeyboardx(InternedString kKeyLayout, InputControl parent); // 0x0000000181D2E470-0x0000000181D2E6E0
		private KeyControl Initialize_ctrlKeyboardy(InternedString kKeyLayout, InputControl parent); // 0x0000000181D2E6E0-0x0000000181D2E950
		private KeyControl Initialize_ctrlKeyboardz(InternedString kKeyLayout, InputControl parent); // 0x0000000181D2E950-0x0000000181D2EBC0
		private KeyControl Initialize_ctrlKeyboard1(InternedString kKeyLayout, InputControl parent); // 0x0000000181D1AE00-0x0000000181D1B060
		private KeyControl Initialize_ctrlKeyboard2(InternedString kKeyLayout, InputControl parent); // 0x0000000181D1B060-0x0000000181D1B2C0
		private KeyControl Initialize_ctrlKeyboard3(InternedString kKeyLayout, InputControl parent); // 0x0000000181D1B2C0-0x0000000181D1B520
		private KeyControl Initialize_ctrlKeyboard4(InternedString kKeyLayout, InputControl parent); // 0x0000000181D1B520-0x0000000181D1B780
		private KeyControl Initialize_ctrlKeyboard5(InternedString kKeyLayout, InputControl parent); // 0x0000000181D1B780-0x0000000181D1B9E0
		private KeyControl Initialize_ctrlKeyboard6(InternedString kKeyLayout, InputControl parent); // 0x0000000181D1B9E0-0x0000000181D1BC40
		private KeyControl Initialize_ctrlKeyboard7(InternedString kKeyLayout, InputControl parent); // 0x0000000181D1BC40-0x0000000181D1BEA0
		private KeyControl Initialize_ctrlKeyboard8(InternedString kKeyLayout, InputControl parent); // 0x0000000181D1BEA0-0x0000000181D1C100
		private KeyControl Initialize_ctrlKeyboard9(InternedString kKeyLayout, InputControl parent); // 0x0000000181D1C100-0x0000000181D1C360
		private KeyControl Initialize_ctrlKeyboard0(InternedString kKeyLayout, InputControl parent); // 0x0000000181D1ABA0-0x0000000181D1AE00
		private KeyControl Initialize_ctrlKeyboardleftShift(InternedString kKeyLayout, InputControl parent); // 0x0000000181D26280-0x0000000181D26500
		private KeyControl Initialize_ctrlKeyboardrightShift(InternedString kKeyLayout, InputControl parent); // 0x0000000181D2C470-0x0000000181D2C6F0
		private DiscreteButtonControl Initialize_ctrlKeyboardshift(InternedString kDiscreteButtonLayout, InputControl parent); // 0x0000000181D2CE40-0x0000000181D2D0F0
		private KeyControl Initialize_ctrlKeyboardleftAlt(InternedString kKeyLayout, InputControl parent); // 0x0000000181D25600-0x0000000181D25880
		private KeyControl Initialize_ctrlKeyboardrightAlt(InternedString kKeyLayout, InputControl parent); // 0x0000000181D2B7E0-0x0000000181D2BA70
		private DiscreteButtonControl Initialize_ctrlKeyboardalt(InternedString kDiscreteButtonLayout, InputControl parent); // 0x0000000181D1D690-0x0000000181D1D940
		private KeyControl Initialize_ctrlKeyboardleftCtrl(InternedString kKeyLayout, InputControl parent); // 0x0000000181D25D60-0x0000000181D25FE0
		private KeyControl Initialize_ctrlKeyboardrightCtrl(InternedString kKeyLayout, InputControl parent); // 0x0000000181D2BF50-0x0000000181D2C1D0
		private DiscreteButtonControl Initialize_ctrlKeyboardctrl(InternedString kDiscreteButtonLayout, InputControl parent); // 0x0000000181D1EF40-0x0000000181D1F1F0
		private KeyControl Initialize_ctrlKeyboardleftMeta(InternedString kKeyLayout, InputControl parent); // 0x0000000181D25FE0-0x0000000181D26280
		private KeyControl Initialize_ctrlKeyboardrightMeta(InternedString kKeyLayout, InputControl parent); // 0x0000000181D2C1D0-0x0000000181D2C470
		private KeyControl Initialize_ctrlKeyboardcontextMenu(InternedString kKeyLayout, InputControl parent); // 0x0000000181D1ECC0-0x0000000181D1EF40
		private KeyControl Initialize_ctrlKeyboardbackspace(InternedString kKeyLayout, InputControl parent); // 0x0000000181D1E300-0x0000000181D1E570
		private KeyControl Initialize_ctrlKeyboardpageDown(InternedString kKeyLayout, InputControl parent); // 0x0000000181D2A460-0x0000000181D2A6D0
		private KeyControl Initialize_ctrlKeyboardpageUp(InternedString kKeyLayout, InputControl parent); // 0x0000000181D2A6D0-0x0000000181D2A940
		private KeyControl Initialize_ctrlKeyboardhome(InternedString kKeyLayout, InputControl parent); // 0x0000000181D24760-0x0000000181D249D0
		private KeyControl Initialize_ctrlKeyboardend(InternedString kKeyLayout, InputControl parent); // 0x0000000181D1FBB0-0x0000000181D1FE20
		private KeyControl Initialize_ctrlKeyboardinsert(InternedString kKeyLayout, InputControl parent); // 0x0000000181D24C40-0x0000000181D24EB0
		private KeyControl Initialize_ctrlKeyboarddelete(InternedString kKeyLayout, InputControl parent); // 0x0000000181D1F460-0x0000000181D1F6D0
		private KeyControl Initialize_ctrlKeyboardcapsLock(InternedString kKeyLayout, InputControl parent); // 0x0000000181D1E7E0-0x0000000181D1EA50
		private KeyControl Initialize_ctrlKeyboardnumLock(InternedString kKeyLayout, InputControl parent); // 0x0000000181D273A0-0x0000000181D27610
		private KeyControl Initialize_ctrlKeyboardprintScreen(InternedString kKeyLayout, InputControl parent); // 0x0000000181D2AE20-0x0000000181D2B090
		private KeyControl Initialize_ctrlKeyboardscrollLock(InternedString kKeyLayout, InputControl parent); // 0x0000000181D2C960-0x0000000181D2CBD0
		private KeyControl Initialize_ctrlKeyboardpause(InternedString kKeyLayout, InputControl parent); // 0x0000000181D2A940-0x0000000181D2ABB0
		private KeyControl Initialize_ctrlKeyboardnumpadEnter(InternedString kKeyLayout, InputControl parent); // 0x0000000181D290E0-0x0000000181D29350
		private KeyControl Initialize_ctrlKeyboardnumpadDivide(InternedString kKeyLayout, InputControl parent); // 0x0000000181D28E70-0x0000000181D290E0
		private KeyControl Initialize_ctrlKeyboardnumpadMultiply(InternedString kKeyLayout, InputControl parent); // 0x0000000181D29830-0x0000000181D29AA0
		private KeyControl Initialize_ctrlKeyboardnumpadPlus(InternedString kKeyLayout, InputControl parent); // 0x0000000181D29D10-0x0000000181D29F80
		private KeyControl Initialize_ctrlKeyboardnumpadMinus(InternedString kKeyLayout, InputControl parent); // 0x0000000181D295C0-0x0000000181D29830
		private KeyControl Initialize_ctrlKeyboardnumpadPeriod(InternedString kKeyLayout, InputControl parent); // 0x0000000181D29AA0-0x0000000181D29D10
		private KeyControl Initialize_ctrlKeyboardnumpadEquals(InternedString kKeyLayout, InputControl parent); // 0x0000000181D29350-0x0000000181D295C0
		private KeyControl Initialize_ctrlKeyboardnumpad1(InternedString kKeyLayout, InputControl parent); // 0x0000000181D27880-0x0000000181D27AF0
		private KeyControl Initialize_ctrlKeyboardnumpad2(InternedString kKeyLayout, InputControl parent); // 0x0000000181D27AF0-0x0000000181D27D60
		private KeyControl Initialize_ctrlKeyboardnumpad3(InternedString kKeyLayout, InputControl parent); // 0x0000000181D27D60-0x0000000181D27FD0
		private KeyControl Initialize_ctrlKeyboardnumpad4(InternedString kKeyLayout, InputControl parent); // 0x0000000181D27FD0-0x0000000181D28240
		private KeyControl Initialize_ctrlKeyboardnumpad5(InternedString kKeyLayout, InputControl parent); // 0x0000000181D28240-0x0000000181D284B0
		private KeyControl Initialize_ctrlKeyboardnumpad6(InternedString kKeyLayout, InputControl parent); // 0x0000000181D284B0-0x0000000181D28720
		private KeyControl Initialize_ctrlKeyboardnumpad7(InternedString kKeyLayout, InputControl parent); // 0x0000000181D28720-0x0000000181D28990
		private KeyControl Initialize_ctrlKeyboardnumpad8(InternedString kKeyLayout, InputControl parent); // 0x0000000181D28990-0x0000000181D28C00
		private KeyControl Initialize_ctrlKeyboardnumpad9(InternedString kKeyLayout, InputControl parent); // 0x0000000181D28C00-0x0000000181D28E70
		private KeyControl Initialize_ctrlKeyboardnumpad0(InternedString kKeyLayout, InputControl parent); // 0x0000000181D27610-0x0000000181D27880
		private KeyControl Initialize_ctrlKeyboardf1(InternedString kKeyLayout, InputControl parent); // 0x0000000181D21DF0-0x0000000181D22060
		private KeyControl Initialize_ctrlKeyboardf2(InternedString kKeyLayout, InputControl parent); // 0x0000000181D22C90-0x0000000181D22F00
		private KeyControl Initialize_ctrlKeyboardf3(InternedString kKeyLayout, InputControl parent); // 0x0000000181D22F00-0x0000000181D23170
		private KeyControl Initialize_ctrlKeyboardf4(InternedString kKeyLayout, InputControl parent); // 0x0000000181D23170-0x0000000181D233E0
		private KeyControl Initialize_ctrlKeyboardf5(InternedString kKeyLayout, InputControl parent); // 0x0000000181D233E0-0x0000000181D23650
		private KeyControl Initialize_ctrlKeyboardf6(InternedString kKeyLayout, InputControl parent); // 0x0000000181D23650-0x0000000181D238C0
		private KeyControl Initialize_ctrlKeyboardf7(InternedString kKeyLayout, InputControl parent); // 0x0000000181D238C0-0x0000000181D23B30
		private KeyControl Initialize_ctrlKeyboardf8(InternedString kKeyLayout, InputControl parent); // 0x0000000181D23B30-0x0000000181D23DA0
		private KeyControl Initialize_ctrlKeyboardf9(InternedString kKeyLayout, InputControl parent); // 0x0000000181D23DA0-0x0000000181D24010
		private KeyControl Initialize_ctrlKeyboardf10(InternedString kKeyLayout, InputControl parent); // 0x0000000181D20590-0x0000000181D20800
		private KeyControl Initialize_ctrlKeyboardf11(InternedString kKeyLayout, InputControl parent); // 0x0000000181D20800-0x0000000181D20A70
		private KeyControl Initialize_ctrlKeyboardf12(InternedString kKeyLayout, InputControl parent); // 0x0000000181D20A70-0x0000000181D20CE0
		private KeyControl Initialize_ctrlKeyboardOEM1(InternedString kKeyLayout, InputControl parent); // 0x0000000181D1C840-0x0000000181D1CAA0
		private KeyControl Initialize_ctrlKeyboardOEM2(InternedString kKeyLayout, InputControl parent); // 0x0000000181D1CAA0-0x0000000181D1CD00
		private KeyControl Initialize_ctrlKeyboardOEM3(InternedString kKeyLayout, InputControl parent); // 0x0000000181D1CD00-0x0000000181D1CF60
		private KeyControl Initialize_ctrlKeyboardOEM4(InternedString kKeyLayout, InputControl parent); // 0x0000000181D1CF60-0x0000000181D1D1C0
		private KeyControl Initialize_ctrlKeyboardOEM5(InternedString kKeyLayout, InputControl parent); // 0x0000000181D1D1C0-0x0000000181D1D420
		private KeyControl Initialize_ctrlKeyboardf13(InternedString kKeyLayout, InputControl parent); // 0x0000000181D20CE0-0x0000000181D20F50
		private KeyControl Initialize_ctrlKeyboardf14(InternedString kKeyLayout, InputControl parent); // 0x0000000181D20F50-0x0000000181D211C0
		private KeyControl Initialize_ctrlKeyboardf15(InternedString kKeyLayout, InputControl parent); // 0x0000000181D211C0-0x0000000181D21430
		private KeyControl Initialize_ctrlKeyboardf16(InternedString kKeyLayout, InputControl parent); // 0x0000000181D21430-0x0000000181D216A0
		private KeyControl Initialize_ctrlKeyboardf17(InternedString kKeyLayout, InputControl parent); // 0x0000000181D216A0-0x0000000181D21910
		private KeyControl Initialize_ctrlKeyboardf18(InternedString kKeyLayout, InputControl parent); // 0x0000000181D21910-0x0000000181D21B80
		private KeyControl Initialize_ctrlKeyboardf19(InternedString kKeyLayout, InputControl parent); // 0x0000000181D21B80-0x0000000181D21DF0
		private KeyControl Initialize_ctrlKeyboardf20(InternedString kKeyLayout, InputControl parent); // 0x0000000181D22060-0x0000000181D222D0
		private KeyControl Initialize_ctrlKeyboardf21(InternedString kKeyLayout, InputControl parent); // 0x0000000181D222D0-0x0000000181D22540
		private KeyControl Initialize_ctrlKeyboardf22(InternedString kKeyLayout, InputControl parent); // 0x0000000181D22540-0x0000000181D227B0
		private KeyControl Initialize_ctrlKeyboardf23(InternedString kKeyLayout, InputControl parent); // 0x0000000181D227B0-0x0000000181D22A20
		private KeyControl Initialize_ctrlKeyboardf24(InternedString kKeyLayout, InputControl parent); // 0x0000000181D22A20-0x0000000181D22C90
		private KeyControl Initialize_ctrlKeyboardmediaPlayPause(InternedString kKeyLayout, InputControl parent); // 0x0000000181D269E0-0x0000000181D26C50
		private KeyControl Initialize_ctrlKeyboardmediaRewind(InternedString kKeyLayout, InputControl parent); // 0x0000000181D26C50-0x0000000181D26EC0
		private KeyControl Initialize_ctrlKeyboardmediaForward(InternedString kKeyLayout, InputControl parent); // 0x0000000181D26770-0x0000000181D269E0
		private ButtonControl Initialize_ctrlKeyboardIMESelected(InternedString kButtonLayout, InputControl parent); // 0x0000000181D1C5D0-0x0000000181D1C840
		private KeyControl Initialize_ctrlKeyboardIMESelectedObsoleteKey(InternedString kKeyLayout, InputControl parent); // 0x0000000181D1C360-0x0000000181D1C5D0
	}
}
