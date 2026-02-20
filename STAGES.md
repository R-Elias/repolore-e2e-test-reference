# Stages of the RepoLore reference repository

> **Test fixture.** This repository is the fixed input of the RepoLore scenario tests
> (`tests/RepoLore.Cli.Tests/Scenarios/` in the RepoLore repository). "Harbor" is fictional: the code
> does not build or run and is not meant to. Only the files and their Git history matter.

## Rules

- **Never modify.** Tests clone this repository into a disposable directory and only run
  `git checkout --force <tag>` followed by `git clean -fd`, then `repolore` commands. They never
  edit, move or delete files. Git history is the script of edits.
- **Append-only.** Existing commits and tags are never edited, moved, deleted or force-pushed. A new
  situation is a new stage at the end of `main`, and the RepoLore repository moves its pin forward.
- **Tags are the interface.** Scenarios name stages only by tag. Branch names and commit hashes
  are not part of the contract.
- **Bytes are exact.** `.gitattributes` disables line-ending conversion, so every platform checks
  out the same bytes (the CRLF note in `s13` really is CRLF).
- **Local-only areas are committed on purpose.** Sessions (`s07`–`s12`) and history (`s33`–`s35`)
  are force-added although `.gitignore` excludes them, because a checkout must reproduce them.
  Untracked, ignored sessions are covered by RepoLore's own acceptance journey instead.

## Shape of the history

`s01`–`s10` are one adopter's journey. `s10` is the clean **baseline**. Each hazard stage
(`s11`–`s23`, `s28`, `s36`–`s41`) is the baseline plus one category of hazard, so hazards never
accumulate: moving from one hazard stage to the next first undoes the previous one. The alpha
stages (`s24`–`s27`) start from `s03`, the repository before adoption. `s29` lives on a short
branch that `s31` merges. `s33`–`s35` start from `s32`.

Scenarios that combine stages with committed history (`s33`–`s36`) should start from a fresh
clone, because checking them out over an existing local `.history/` replaces it.

## Stages

| Tag | Content | What the tool should see |
|---|---|---|
| `s01-plain-monorepo` | Harbor monorepo: services, web, libs, infra, docs, tools. No RepoLore | Nothing to read; `init` possible |
| `s02-hazard-folders` | Vendored SDK, a tracked `tools/bin/`, a directory with spaces, one with accents, a 16-level deep chain, 120 sibling modules | Same; mapping hazards for `path` |
| `s03-ready-for-init` | `.gitignore` gains `_repolore/sessions/` and `_repolore/.history/` | The adopter's starting point |
| `s04-knowledge-adopted` | `repolore init` output plus authored notes: root, path notes (including the hazard folders and the deep leaf), custom `architecture/` and `adr/` with valid links | Healthy |
| `s05-note-edited` | The orders note is edited | One changed file |
| `s06-notes-added-removed` | Inventory note and an architecture note added, storefront note removed | Added and removed files |
| `s07-one-session` | Session `2026-01-11-payment-retries-a1c4` with `root.md` | Session readable only when selected |
| `s08-two-sessions` | Session `2026-01-12-checkout-latency-b7e2` added; the first gains `investigation.md` | Sessions isolated from each other |
| `s09-finding-promoted` | The verified retry finding is promoted into the payments note; the first session is marked complete | Durable note changed, no session link |
| `s10-session-cleaned-up` | The completed session is deleted. **Baseline** | Healthy, one session left |
| `s11-structure-hazards` | `services/inventory/` moved to `services/stock/`, `infra/k8s/` deleted (their notes stay), `_repolore/method.md` deleted | `orphan-path-note` ×2, `missing-note` |
| `s12-link-and-session-hazards` | Broken link, a link escaping the repository, a durable link into a session, a session link into another session, a session without `root.md`, a session folder with an invalid id | `broken-link`, `session-link-in-durable-note`; `invalid-session` when selected; an invalid id is a usage error; the cross-session link is not checked (sessions never read each other) |
| `s13-note-content-hazards` | Invalid UTF-8, a UTF-8 BOM, CRLF line endings, a path note whose name does not match its directory, a 1.5 MB note | `invalid-utf8`, `invalid-note-name` |
| `s14-huge-tree` | 1000 generated source directories, 500 of them with notes | Healthy, large |
| `s15-unicode-paths` | Accented, Japanese, emoji and mixed-script directory names with notes | Healthy |
| `s16-policy-variants` | `history.exclude` for generated notes; the ignore rules under the preview's file name `_repoloreignore` | Since the file became `.repoloreignore` (2026-10-24): `policy-error` asking to rename it, and its rules are not read. `s40` has the same rules under the new name |
| `s17-tiny-history-budget` | `history.maxBytes` of 10000: one checkpoint fits, two do not | A checkpoint taken after one from another stage evicts the older |
| `s18-history-disabled` | `history.enabled` false | Writes needing history refuse (`history-disabled`) |
| `s19-invalid-ignore-rule` | `_repoloreignore` (preview name) with an unsupported character class | Since the rename: the rename `policy-error`; the rule is not read. `s41` has the invalid rule under the new name |
| `s20-invalid-history-policy` | Negative `history.maxBytes` | `policy-error` |
| `s21-unsupported-format` | `formatVersion` 2 | `unsupported-format` |
| `s22-malformed-marker` | Truncated `repolore.json` | `malformed-format` |
| `s23-duplicate-keys` | `repolore.json` with a duplicate key | `malformed-format` |
| `s24-alpha-sparse-committed` | Alpha layout as alpha users committed it: alpha method, root, `sparse-tree/`, custom areas; `tree/` ignored | `migration-needed`; clean migration |
| `s25-alpha-local-tree-only` | Alpha full mirror `tree/` only (force-added, as found on a maintainer's disk) | `migration-needed`; clean migration |
| `s26-alpha-conflicting-copies` | Both `tree/` and `sparse-tree/`: one note identical, one different | `conflicting-alpha-notes`; `migrate` refuses |
| `s27-alpha-sessions-conflict` | Alpha layout plus a file directly under `_repolore/sessions/` and one valid session folder | `migrate` refuses (`migration-blocked`) |
| `s28-v1-baseline-again` | Back to the baseline knowledge | Healthy |
| `s29-branch-note-edit` | On branch `feature/orders-sla`: the orders note gains an SLA line | (branch side of the merge) |
| `s30-main-note-edit` | On `main`: the same line written differently | (main side of the merge) |
| `s31-merge-resolved` | Merge of the branch with the conflict in the orders note resolved by hand | Healthy; note equals the resolution |
| `s32-release-1` | Release 1 baseline: changelog, root note updated | Healthy |
| `s33-corrupt-history-object` | Committed `.history/` with two checkpoints, one object's bytes altered | `history-corrupt` on that object; `checkpoint` and `restore` refuse |
| `s34-corrupt-history-manifest` | Same history, checkpoint 2's manifest truncated | `history-corrupt` on checkpoints |
| `s35-pending-operation` | Same history plus `pending.json` of an interrupted `restore 1` (first file already written) | `history-pending`; writes refuse; `restore 2` recovers |
| `s36-history-path-is-a-file` | `_repolore/.history` is a regular file | `history-unavailable`; writes fail with `io-error` |
| `s37-case-collision` | `services/Billing/` and `services/billing/`, each with a note. Built through the index | Linux only: both exist. Windows and macOS clones collide |
| `s38-symlinks` | A knowledge note that is a symlink, a dangling symlink escaping the repository, a symlinked source directory | Linux and macOS; Windows checks links out as text unless enabled |
| `s39-long-paths` | Source and note paths longer than 260 characters | Windows needs `core.longpaths=true` for the clone |
| `s40-policy-variants-renamed` | `s16` with the ignore file under its final name `.repoloreignore` | Healthy; `--explain` follows the exclusion and the re-inclusion |
| `s41-invalid-ignore-rule-renamed` | `s19` with the invalid rule in `.repoloreignore` | `policy-error` with the line number; reads and writes still work |
| `s42-method-guides-context` | `s10` with the method that `init` writes since 1.0.0-rc.2: root-relative targets, `--node` for custom areas, the context budget | Healthy; `init` on `s03` writes this `method.md` |
| `s43-non-knowledge-files` | `s10` plus a `.txt` and an `.svg` beside notes, and a folder holding only `.gitkeep` | Healthy; `tree` lists none of them, nor the folder without a note |
| `s44-unknown-config-keys` | `s10` with misspelled history keys and an unknown top-level key | Healthy: unknown keys are ignored (frozen for 1.0); history stays enabled with the defaults and covers `adr/` |
| `s45-ignore-rule-trailing-space` | `s10` with a `.repoloreignore` rule ending with a space | `policy-error` with the line number; reads and writes still work |
| `s46-history-exclude-trailing-space` | `s10` with a `history.exclude` rule ending with a space | `policy-error`; writes refuse |

The last column states the intent. The expected outputs themselves are pinned by the scenarios in
the RepoLore repository, not here.

Not reproducible by checking out commits, and therefore covered by ordinary tests instead: a held
writer lock (`history-locked`), an operation interrupted while it runs (`operation-interrupted`),
crashes (`internal-error`), and an interrupted `init` (`init-incomplete`).
