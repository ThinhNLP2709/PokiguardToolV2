"""Create a stable sorted ZIP for one PyInstaller one-folder directory."""

from __future__ import annotations

import argparse
from pathlib import Path
import zipfile


FIXED_TIMESTAMP = (2026, 1, 1, 0, 0, 0)


def build_archive(source: Path, output: Path) -> None:
    source = source.resolve()
    output = output.resolve()
    if not source.is_dir():
        raise FileNotFoundError(source)
    output.parent.mkdir(parents=True, exist_ok=True)
    temporary = output.with_suffix(output.suffix + ".tmp")
    temporary.unlink(missing_ok=True)
    try:
        with zipfile.ZipFile(
            temporary,
            "w",
            compression=zipfile.ZIP_DEFLATED,
            compresslevel=9,
        ) as archive:
            for path in sorted(source.rglob("*"), key=lambda value: value.as_posix()):
                if not path.is_file():
                    continue
                relative = path.relative_to(source.parent).as_posix()
                info = zipfile.ZipInfo(relative, FIXED_TIMESTAMP)
                info.compress_type = zipfile.ZIP_DEFLATED
                info.create_system = 3
                info.external_attr = (0o100644 & 0xFFFF) << 16
                with path.open("rb") as payload:
                    archive.writestr(info, payload.read(), compresslevel=9)
        temporary.replace(output)
    except Exception:
        temporary.unlink(missing_ok=True)
        raise


def main() -> int:
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("source", type=Path)
    parser.add_argument("output", type=Path)
    args = parser.parse_args()
    build_archive(args.source, args.output)
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
