"""Dependency-free Windows client-area screenshot capture for audit artifacts."""

from __future__ import annotations

import binascii
import ctypes
from ctypes import wintypes
from pathlib import Path
import struct
import zlib
from dataclasses import dataclass


class POINT(ctypes.Structure):
    _fields_ = [("x", wintypes.LONG), ("y", wintypes.LONG)]


class RECT(ctypes.Structure):
    _fields_ = [
        ("left", wintypes.LONG),
        ("top", wintypes.LONG),
        ("right", wintypes.LONG),
        ("bottom", wintypes.LONG),
    ]


class BITMAPINFOHEADER(ctypes.Structure):
    _fields_ = [
        ("biSize", wintypes.DWORD),
        ("biWidth", wintypes.LONG),
        ("biHeight", wintypes.LONG),
        ("biPlanes", wintypes.WORD),
        ("biBitCount", wintypes.WORD),
        ("biCompression", wintypes.DWORD),
        ("biSizeImage", wintypes.DWORD),
        ("biXPelsPerMeter", wintypes.LONG),
        ("biYPelsPerMeter", wintypes.LONG),
        ("biClrUsed", wintypes.DWORD),
        ("biClrImportant", wintypes.DWORD),
    ]


class RGBQUAD(ctypes.Structure):
    _fields_ = [
        ("rgbBlue", wintypes.BYTE),
        ("rgbGreen", wintypes.BYTE),
        ("rgbRed", wintypes.BYTE),
        ("rgbReserved", wintypes.BYTE),
    ]


class BITMAPINFO(ctypes.Structure):
    _fields_ = [("bmiHeader", BITMAPINFOHEADER), ("bmiColors", RGBQUAD * 1)]


def _png_chunk(kind: bytes, payload: bytes) -> bytes:
    body = kind + payload
    return struct.pack(">I", len(payload)) + body + struct.pack(
        ">I", binascii.crc32(body) & 0xFFFFFFFF
    )


def write_png_rgb(path: Path, width: int, height: int, rgb: bytes) -> None:
    if width <= 0 or height <= 0 or len(rgb) != width * height * 3:
        raise ValueError("RGB buffer dimensions are invalid")
    stride = width * 3
    filtered = b"".join(
        b"\x00" + rgb[row * stride : (row + 1) * stride]
        for row in range(height)
    )
    png = (
        b"\x89PNG\r\n\x1a\n"
        + _png_chunk("IHDR".encode("ascii"), struct.pack(">IIBBBBB", width, height, 8, 2, 0, 0, 0))
        + _png_chunk(b"IDAT", zlib.compress(filtered, level=6))
        + _png_chunk(b"IEND", b"")
    )
    path.write_bytes(png)


def _client_window(pid: int) -> tuple[int, str, int, int, int, int]:
    user32 = ctypes.WinDLL("user32", use_last_error=True)
    user32.EnumWindows.argtypes = [ctypes.c_void_p, wintypes.LPARAM]
    user32.EnumWindows.restype = wintypes.BOOL
    user32.IsWindowVisible.argtypes = [wintypes.HWND]
    user32.IsWindowVisible.restype = wintypes.BOOL
    user32.GetWindowThreadProcessId.argtypes = [wintypes.HWND, ctypes.POINTER(wintypes.DWORD)]
    user32.GetWindowThreadProcessId.restype = wintypes.DWORD
    matches: list[tuple[int, str]] = []
    callback_type = ctypes.WINFUNCTYPE(wintypes.BOOL, wintypes.HWND, wintypes.LPARAM)

    @callback_type
    def callback(hwnd: int, _lparam: int) -> bool:
        window_pid = wintypes.DWORD()
        user32.GetWindowThreadProcessId(hwnd, ctypes.byref(window_pid))
        if window_pid.value != pid or not user32.IsWindowVisible(hwnd):
            return True
        length = user32.GetWindowTextLengthW(hwnd)
        title = ctypes.create_unicode_buffer(length + 1)
        user32.GetWindowTextW(hwnd, title, length + 1)
        if title.value:
            matches.append((int(hwnd), title.value))
        return True

    if not user32.EnumWindows(callback, 0):
        raise ctypes.WinError(ctypes.get_last_error())
    if not matches:
        raise RuntimeError(f"no visible window belongs to PID {pid}")
    hwnd, title = max(matches, key=lambda item: len(item[1]))
    rect = RECT()
    if not user32.GetClientRect(hwnd, ctypes.byref(rect)):
        raise ctypes.WinError(ctypes.get_last_error())
    origin = POINT(0, 0)
    if not user32.ClientToScreen(hwnd, ctypes.byref(origin)):
        raise ctypes.WinError(ctypes.get_last_error())
    width = int(rect.right - rect.left)
    height = int(rect.bottom - rect.top)
    if width <= 0 or height <= 0:
        raise RuntimeError("game client is minimized or has an empty client area")
    return hwnd, title, origin.x, origin.y, width, height


@dataclass(frozen=True)
class ClientRgbCapture:
    title: str
    left: int
    top: int
    width: int
    height: int
    rgb: bytes


@dataclass(frozen=True)
class PngRgbImage:
    width: int
    height: int
    rgb: bytes


def read_png_rgb(path: Path) -> PngRgbImage:
    """Decode a bounded 8-bit RGB/RGBA non-interlaced PNG with stdlib only.

    This keeps offline locator fixtures dependency-free.  It intentionally
    rejects palette, grayscale and interlaced files instead of guessing.
    """

    data = path.read_bytes()
    if not data.startswith(b"\x89PNG\r\n\x1a\n"):
        raise ValueError("not a PNG file")
    position = 8
    width = height = bit_depth = color_type = interlace = None
    compressed: list[bytes] = []
    while position + 12 <= len(data):
        length = struct.unpack_from(">I", data, position)[0]
        chunk_type = data[position + 4 : position + 8]
        payload_start = position + 8
        payload_end = payload_start + length
        if payload_end + 4 > len(data):
            raise ValueError("truncated PNG chunk")
        payload = data[payload_start:payload_end]
        position = payload_end + 4
        if chunk_type == b"IHDR":
            if len(payload) != 13:
                raise ValueError("invalid IHDR length")
            (
                width,
                height,
                bit_depth,
                color_type,
                compression,
                filter_method,
                interlace,
            ) = struct.unpack(">IIBBBBB", payload)
            if compression != 0 or filter_method != 0:
                raise ValueError("unsupported PNG compression/filter method")
        elif chunk_type == b"IDAT":
            compressed.append(payload)
        elif chunk_type == b"IEND":
            break
    if (
        width is None
        or height is None
        or width <= 0
        or height <= 0
        or width > 8192
        or height > 8192
    ):
        raise ValueError("invalid PNG dimensions")
    if bit_depth != 8 or color_type not in (2, 6) or interlace != 0:
        raise ValueError("only 8-bit non-interlaced RGB/RGBA PNG is supported")
    bytes_per_pixel = 3 if color_type == 2 else 4
    stride = width * bytes_per_pixel
    raw = zlib.decompress(b"".join(compressed))
    expected = height * (stride + 1)
    if len(raw) != expected:
        raise ValueError(f"PNG payload length {len(raw)} != expected {expected}")

    decoded = bytearray(height * stride)
    previous = bytearray(stride)
    source = 0
    for row_index in range(height):
        filter_type = raw[source]
        source += 1
        row = bytearray(raw[source : source + stride])
        source += stride
        if filter_type not in (0, 1, 2, 3, 4):
            raise ValueError(f"unsupported PNG filter {filter_type}")
        for index in range(stride):
            left = row[index - bytes_per_pixel] if index >= bytes_per_pixel else 0
            above = previous[index]
            upper_left = (
                previous[index - bytes_per_pixel]
                if index >= bytes_per_pixel
                else 0
            )
            if filter_type == 0:
                predictor = 0
            elif filter_type == 1:
                predictor = left
            elif filter_type == 2:
                predictor = above
            elif filter_type == 3:
                predictor = (left + above) // 2
            else:
                estimate = left + above - upper_left
                left_distance = abs(estimate - left)
                above_distance = abs(estimate - above)
                diagonal_distance = abs(estimate - upper_left)
                predictor = (
                    left
                    if left_distance <= above_distance
                    and left_distance <= diagonal_distance
                    else above if above_distance <= diagonal_distance else upper_left
                )
            row[index] = (row[index] + predictor) & 0xFF
        decoded[row_index * stride : (row_index + 1) * stride] = row
        previous = row

    if color_type == 2:
        rgb = bytes(decoded)
    else:
        rgb_buffer = bytearray(width * height * 3)
        for pixel_index in range(width * height):
            source_offset = pixel_index * 4
            target_offset = pixel_index * 3
            rgb_buffer[target_offset : target_offset + 3] = decoded[
                source_offset : source_offset + 3
            ]
        rgb = bytes(rgb_buffer)
    return PngRgbImage(width, height, rgb)


def capture_client_rgb(pid: int) -> ClientRgbCapture:
    """Capture visible client pixels in top-down RGB order."""

    _hwnd, title, left, top, width, height = _client_window(pid)
    user32 = ctypes.WinDLL("user32", use_last_error=True)
    gdi32 = ctypes.WinDLL("gdi32", use_last_error=True)
    handle = ctypes.c_void_p
    user32.GetDC.argtypes = [wintypes.HWND]
    user32.GetDC.restype = handle
    user32.ReleaseDC.argtypes = [wintypes.HWND, handle]
    gdi32.CreateCompatibleDC.argtypes = [handle]
    gdi32.CreateCompatibleDC.restype = handle
    gdi32.CreateCompatibleBitmap.argtypes = [handle, ctypes.c_int, ctypes.c_int]
    gdi32.CreateCompatibleBitmap.restype = handle
    gdi32.SelectObject.argtypes = [handle, handle]
    gdi32.SelectObject.restype = handle
    gdi32.BitBlt.argtypes = [
        handle,
        ctypes.c_int,
        ctypes.c_int,
        ctypes.c_int,
        ctypes.c_int,
        handle,
        ctypes.c_int,
        ctypes.c_int,
        wintypes.DWORD,
    ]
    gdi32.BitBlt.restype = wintypes.BOOL
    gdi32.GetDIBits.argtypes = [
        handle,
        handle,
        wintypes.UINT,
        wintypes.UINT,
        ctypes.c_void_p,
        ctypes.POINTER(BITMAPINFO),
        wintypes.UINT,
    ]
    gdi32.GetDIBits.restype = ctypes.c_int
    gdi32.DeleteObject.argtypes = [handle]
    gdi32.DeleteObject.restype = wintypes.BOOL
    gdi32.DeleteDC.argtypes = [handle]
    gdi32.DeleteDC.restype = wintypes.BOOL

    screen_dc = user32.GetDC(0)
    if not screen_dc:
        raise ctypes.WinError(ctypes.get_last_error())
    memory_dc = bitmap = old_bitmap = None
    try:
        memory_dc = gdi32.CreateCompatibleDC(screen_dc)
        bitmap = gdi32.CreateCompatibleBitmap(screen_dc, width, height)
        if not memory_dc or not bitmap:
            raise ctypes.WinError(ctypes.get_last_error())
        old_bitmap = gdi32.SelectObject(memory_dc, bitmap)
        if not old_bitmap:
            raise ctypes.WinError(ctypes.get_last_error())
        if not gdi32.BitBlt(
            memory_dc,
            0,
            0,
            width,
            height,
            screen_dc,
            left,
            top,
            0x00CC0020 | 0x40000000,
        ):
            raise ctypes.WinError(ctypes.get_last_error())
        info = BITMAPINFO()
        info.bmiHeader.biSize = ctypes.sizeof(BITMAPINFOHEADER)
        info.bmiHeader.biWidth = width
        info.bmiHeader.biHeight = -height
        info.bmiHeader.biPlanes = 1
        info.bmiHeader.biBitCount = 32
        info.bmiHeader.biCompression = 0
        pixels = (ctypes.c_ubyte * (width * height * 4))()
        rows = gdi32.GetDIBits(
            memory_dc,
            bitmap,
            0,
            height,
            pixels,
            ctypes.byref(info),
            0,
        )
        if rows != height:
            raise RuntimeError(f"GetDIBits returned {rows}/{height} rows")
        bgra = bytes(pixels)
        rgb = bytearray(width * height * 3)
        for source in range(0, len(bgra), 4):
            target = (source // 4) * 3
            rgb[target : target + 3] = bytes(
                (bgra[source + 2], bgra[source + 1], bgra[source])
            )
    finally:
        if old_bitmap and memory_dc:
            gdi32.SelectObject(memory_dc, old_bitmap)
        if bitmap:
            gdi32.DeleteObject(bitmap)
        if memory_dc:
            gdi32.DeleteDC(memory_dc)
        user32.ReleaseDC(0, screen_dc)
    return ClientRgbCapture(title, left, top, width, height, bytes(rgb))


def capture_client_png(pid: int, path: Path) -> dict[str, object]:
    """Capture only visible pixels; this does not inspect or mutate game state."""

    capture = capture_client_rgb(pid)
    write_png_rgb(path, capture.width, capture.height, capture.rgb)
    return {
        "windowTitle": capture.title,
        "clientRegion": {
            "left": capture.left,
            "top": capture.top,
            "width": capture.width,
            "height": capture.height,
        },
    }


__all__ = [
    "ClientRgbCapture",
    "PngRgbImage",
    "capture_client_png",
    "capture_client_rgb",
    "read_png_rgb",
    "write_png_rgb",
]
