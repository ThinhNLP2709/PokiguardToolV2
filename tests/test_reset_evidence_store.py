from __future__ import annotations

import tempfile
import unittest
from pathlib import Path
import sys


SRC = Path(__file__).resolve().parents[1] / "src"
if str(SRC) not in sys.path:
    sys.path.insert(0, str(SRC))

from pokiguard_v2.game_owned_idle import (
    AcceptedActivityKind,
    ResetCapability,
    ResetConfidence,
)
from pokiguard_v2.reset_evidence_store import (
    load_reset_capabilities,
    write_reset_capabilities,
)


class ResetEvidenceStoreTests(unittest.TestCase):
    def capability(self, confidence=ResetConfidence.RESET_CONFIRMED_BY_SERVER_SEQUENCE):
        return ResetCapability(
            kind=AcceptedActivityKind.SWAP,
            confirmations=2,
            required_confirmations=2,
            confidence=confidence,
            proof_identities=(
                ("session-1", AcceptedActivityKind.SWAP, 3, 5),
                ("session-2", AcceptedActivityKind.SWAP, 7, 9),
            ),
        )

    def test_roundtrip_production_capability(self) -> None:
        with tempfile.TemporaryDirectory() as directory:
            path = Path(directory) / "reset.json"
            write_reset_capabilities(
                path,
                (self.capability(),),
                generated_at="now",
                source_log="evidence.jsonl",
            )
            loaded = load_reset_capabilities(path)
        self.assertEqual(len(loaded), 1)
        self.assertTrue(loaded[0].production_ready)
        self.assertEqual(loaded[0].kind, AcceptedActivityKind.SWAP)

    def test_strong_inference_is_not_loadable_for_production(self) -> None:
        with tempfile.TemporaryDirectory() as directory:
            path = Path(directory) / "reset.json"
            write_reset_capabilities(
                path,
                (self.capability(ResetConfidence.RESET_STRONGLY_INFERRED),),
                generated_at="now",
                source_log="evidence.jsonl",
            )
            with self.assertRaisesRegex(ValueError, "no production-ready"):
                load_reset_capabilities(path)


if __name__ == "__main__":
    unittest.main()
