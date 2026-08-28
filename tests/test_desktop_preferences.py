from __future__ import annotations

import json
from pathlib import Path
import tempfile
import unittest
from unittest.mock import patch

from pokiguard_v2.basic_policy import ManaPriority, PlayStyle
from pokiguard_v2.desktop_control_plane import DesktopConfig
from pokiguard_v2.desktop_preferences import (
    DesktopPreferenceStore,
    PREFERENCE_SCHEMA,
    PreferenceError,
)


class DesktopPreferenceStoreTests(unittest.TestCase):
    def setUp(self) -> None:
        self._temporary = tempfile.TemporaryDirectory()
        self.path = Path(self._temporary.name) / "operator_preferences.json"
        self.store = DesktopPreferenceStore(self.path)

    def tearDown(self) -> None:
        self._temporary.cleanup()

    def test_missing_file_uses_safe_defaults_without_warning(self) -> None:
        result = self.store.load()
        self.assertFalse(result.loaded)
        self.assertEqual((), result.warnings)
        self.assertEqual(DesktopConfig(), result.config)
        self.assertFalse(self.path.exists())

    def test_valid_save_reload_persists_only_supported_draft_fields(self) -> None:
        config = DesktopConfig(
            play_style=PlayStyle.CAREFUL,
            mana_priority=ManaPriority.ATTACK,
            boss_id="1289",
            boss_name="Starburst",
            target_completed_matches=25,
            max_technical_recoveries=3,
            max_match_attempts=32,
        )
        self.store.save(config)
        result = self.store.load()
        self.assertTrue(result.loaded)
        self.assertEqual(result.config.play_style, config.play_style)
        self.assertEqual(result.config.mana_priority, config.mana_priority)
        self.assertEqual(result.config.intelligence, config.intelligence)
        self.assertEqual(
            result.config.target_completed_matches,
            config.target_completed_matches,
        )
        self.assertEqual(result.config.max_match_attempts, config.max_match_attempts)
        self.assertEqual(result.config.max_technical_recoveries, 1)
        raw = json.loads(self.path.read_text(encoding="utf-8"))
        self.assertEqual(PREFERENCE_SCHEMA, raw["schema"])
        self.assertIsNone(raw["config"]["boss_id"])
        self.assertIsNone(raw["config"]["boss_name"])
        self.assertNotIn("max_technical_recoveries", raw["config"])
        encoded = json.dumps(raw)
        for forbidden in (
            "farm_run_id",
            "match_id",
            "combat_session",
            "wins",
            "losses",
            "auto_start",
            "auto_resume",
        ):
            self.assertNotIn(forbidden, encoded.lower())

    def test_corrupt_json_falls_back_with_bounded_warning(self) -> None:
        self.path.write_text("{not-json", encoding="utf-8")
        result = self.store.load()
        self.assertFalse(result.loaded)
        self.assertEqual(DesktopConfig(), result.config)
        self.assertEqual(1, len(result.warnings))
        self.assertEqual("PREFERENCE_LOAD_INVALID", result.warnings[0].reason)

    def test_unsupported_reasoning_value_falls_back_without_conversion(self) -> None:
        raw = self._valid_payload()
        raw["config"]["intelligence"] = "reasoning"
        self.path.write_text(json.dumps(raw), encoding="utf-8")
        result = self.store.load()
        self.assertFalse(result.loaded)
        self.assertEqual("basic", result.config.intelligence.value)
        self.assertEqual(1, len(result.warnings))

    def test_unknown_future_fields_are_ignored(self) -> None:
        raw = self._valid_payload()
        raw["future_root_field"] = {"anything": True}
        raw["config"]["future_config_field"] = "ignored"
        self.path.write_text(json.dumps(raw), encoding="utf-8")
        result = self.store.load()
        self.assertTrue(result.loaded)
        self.assertEqual(3, result.config.target_completed_matches)
        self.assertEqual((), result.warnings)

    def test_invalid_finite_limit_falls_back(self) -> None:
        raw = self._valid_payload()
        raw["config"]["target_completed_matches"] = 0
        self.path.write_text(json.dumps(raw), encoding="utf-8")
        result = self.store.load()
        self.assertFalse(result.loaded)
        self.assertEqual(DesktopConfig(), result.config)
        self.assertEqual(1, len(result.warnings))

    def test_unknown_schema_falls_back(self) -> None:
        raw = self._valid_payload()
        raw["schema"] = "pokiguard.desktop_preferences.v999"
        self.path.write_text(json.dumps(raw), encoding="utf-8")
        result = self.store.load()
        self.assertFalse(result.loaded)
        self.assertEqual(
            "PREFERENCE_SCHEMA_UNSUPPORTED", result.warnings[0].reason
        )

    def test_atomic_replace_failure_preserves_previous_file(self) -> None:
        self.store.save(DesktopConfig())
        previous = self.path.read_bytes()
        changed = DesktopConfig(target_completed_matches=5, max_match_attempts=7)
        with patch(
            "pokiguard_v2.desktop_preferences.os.replace",
            side_effect=OSError("test replace failure"),
        ):
            with self.assertRaises(PreferenceError):
                self.store.save(changed)
        self.assertEqual(previous, self.path.read_bytes())
        self.assertEqual([], list(self.path.parent.glob("*.tmp")))

    @staticmethod
    def _valid_payload() -> dict[str, object]:
        return {
            "schema": PREFERENCE_SCHEMA,
            "config": {
                "play_style": "simple",
                "mana_priority": "evolution",
                "intelligence": "basic",
                "boss_id": "1289",
                "boss_name": "Starburst",
                "target_completed_matches": 3,
                "max_technical_recoveries": 1,
                "max_match_attempts": 5,
            },
        }


if __name__ == "__main__":
    unittest.main()
