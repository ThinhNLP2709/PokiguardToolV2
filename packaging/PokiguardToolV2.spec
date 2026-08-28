# -*- mode: python ; coding: utf-8 -*-
"""PyInstaller one-folder definition for the Phase 2F.1 Windows package."""

from pathlib import Path


ROOT = Path(SPECPATH).resolve().parent
SRC = ROOT / "src"

datas = [
    (
        str(SRC / "pokiguard_v2" / "resources" / "reset_capabilities.json"),
        "pokiguard_v2/resources",
    ),
    (
        str(ROOT / "reference" / "exit_ui_live_calibration.json"),
        "pokiguard_v2/resources/reference",
    ),
    (
        str(ROOT / "reference" / "exit_ui_live_calibration_1280x710.json"),
        "pokiguard_v2/resources/reference",
    ),
]

a = Analysis(
    [str(SRC / "pokiguard_v2" / "windows_entry.py")],
    pathex=[str(ROOT), str(SRC)],
    binaries=[],
    datas=datas,
    hiddenimports=[
        # Imported inside the UI-owned worker path.  Listing it here makes the
        # frozen contract explicit even if PyInstaller's static scan changes.
        "tools.desktop_ui",
        "tools.farm_run",
        "tools.farm_cycle",
        "tools.basic_auto_bot",
        "tools.boss_entry",
        "tools.technical_recovery",
    ],
    hookspath=[],
    hooksconfig={},
    runtime_hooks=[],
    excludes=[
        "cv2",
        "mss",
        "numpy",
        "pytest",
        "pokiguard_auto",
    ],
    noarchive=False,
    optimize=1,
)
pyz = PYZ(a.pure)

exe = EXE(
    pyz,
    a.scripts,
    [],
    exclude_binaries=True,
    name="PokiguardToolV2",
    debug=False,
    bootloader_ignore_signals=False,
    strip=False,
    upx=False,
    console=False,
    disable_windowed_traceback=False,
)

coll = COLLECT(
    exe,
    a.binaries,
    a.datas,
    strip=False,
    upx=False,
    upx_exclude=[],
    name="PokiguardToolV2",
)
