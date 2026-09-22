"""Single source of truth for the post-MVP desktop release label."""

SEMANTIC_VERSION = "1.1.0"
# Kept as a compatibility export for diagnostics/tests.  Build suffixes were
# used during the pre-MVP line; official maintenance releases use SemVer.
APP_BUILD = 0
APP_VERSION = f"v{SEMANTIC_VERSION}"
APP_TITLE = f"Công cụ Pokiguard V2 - {APP_VERSION}"
