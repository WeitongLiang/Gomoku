# Gomoku Game (Five-in-a-Row)

This project is a C# implementation of the traditional board game Gomoku, supporting both human-vs-human and human-vs-AI gameplay. It features full game mechanics, including rule enforcement (e.g., forbidden moves), timing, undo/redo, save/load, and a simple rule-based AI opponent.

## 🎮 Game Rules

- The game is played on a 15×15 grid.
- Two players alternate placing black and white stones.
- The goal is to be the first to align five stones in a row, column, or diagonal.
- For fairness, **black is subject to "forbidden move" rules**:
  - Overlines (more than 5 stones in a row),
  - Double-threes (two open sequences of three),
  - Double-fours (two sequences of four).
- If black violates these rules, they lose the game.
- Each player must play within a time limit per turn (visualized with a progress bar).

---

## 💻 Key Features

###  Board Rendering
- Rendered with `Graphics` and `LinearGradientBrush`.
- Custom drawing methods for grid, black/white stones, and highlight effects.

###  Move Logic
- Click-based control: mouse input maps to grid positions.
- Internal board state managed with a 2D array `chessBoard[i, j]`.
- Turn alternates based on a boolean flag.

###  Win & Forbidden Move Detection
- Win condition: 5 consecutive stones in any direction.
- Forbidden move detection checks all eight directions for patterns after every move.
- The board is padded to avoid array bounds errors.

###  Time Management
- `Timer` + `ProgressBar` control per-turn time.
- Countdown shown in a `Label`.
- Timer resets at each turn and pauses when needed.

###  Undo & Replay
- Stores move history as a list of coordinate pairs.
- "Undo" removes the last move; "Replay" loads and steps through past games.
- Step-by-step navigation via "Last" and "Next" buttons.

###  Save / Load
- Uses binary serialization (`BinaryFormatter`) to save/load game states.
- Integrated with `SaveFileDialog` and `OpenFileDialog`.

###  Menu System
- Built-in `MenuStrip` offers:
  - Player vs Player
  - Player vs AI (first/second)
  - Restart
  - Save / Load
  - Replay mode

---

## 🤖 Human vs Computer

- This project supports **human vs Computer gameplay**, where the player can choose to go first or second.
- The Computer uses a **heuristic scoring strategy** to evaluate moves:

  1. Traverse all empty positions on the board;
  2. Evaluate the potential patterns for both itself and the opponent at each position;
  3. If playing as black, the AI avoids making forbidden moves (e.g., double three, double four, overline);
  4. The final score is computed as:

     ```
     Score = Self score + 0.75 × Opponent score
     ```

- The scoring table for various patterns is as follows:

  | Pattern             | Score    |
  |---------------------|----------|
  | Single stone        | 1        |
  | Dead two            | 5        |
  | Live two            | 10       |
  | Dead three          | 50       |
  | Live three          | 100      |
  | Half-live four      | 500      |
  | Live four           | 1000     |
  | Forbidden pattern   | -10000   |

- The Computer does **not** use deep search algorithms (like minimax or alpha-beta pruning), but instead relies on static pattern recognition.
- It reacts quickly and is suitable for beginners to practice, but has limitations in complex situations.

## 🖼️ UI Design

- Built with WinForms using two `Form` objects:
  - `Form1`: main menu
  - `Form2`: game interface
- Controls include:
  - Custom-drawn `Panel` for board
  - Buttons for control (undo, restart, etc.)
  - Timers and labels for turn time

---
