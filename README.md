# Tetris Unity Project README

## Overview:
Welcome to the Tetris Unity Project! This project showcases the classic Tetris game implemented in Unity, featuring various design patterns and Unity Services integration. Below is an overview of the key components and features incorporated into this project.

## Key Features:
1. **Dependency Injection (DI):**
   - Utilizes DI to manage dependencies between different components, facilitating loose coupling and better maintainability.

2. **Command Pattern:**
   - Implements the Command Pattern to encapsulate player actions (e.g., move left, move right, rotate) as commands, allowing for easy execution, undo/redo functionality, and extensibility.

3. **MVC Architecture:**
   - Follows the Model-View-Controller (MVC) architectural pattern to separate concerns, improve code organization, and enhance scalability.
   - **Model:** Represents the game's data and logic (e.g., board Model, Piece Model).
   - **View:** Displays the game's graphical user interface (GUI) elements to the player.
   - **Controller:** Orchestrates interactions between the model and view, handling player input and updating the game state accordingly.

4. **Object Pooling:**
   - Implements object pooling to efficiently manage game objects (e.g., Leaderboard) by pre-instantiating and reusing them as needed, reducing memory allocation and improving performance.

5. **Observer Pattern:**
   - Utilizes the Observer Pattern to establish communication between different components within the game, enabling event-driven updates and notifications (e.g., game over, score update).

6. **Unity Authenticator:**
   - Integrates Unity Authenticator for user authentication, allowing players to sign up, log in, and securely access their game data across sessions.

7. **Unity Leaderboard:**
   - Incorporates Unity Leaderboard for tracking and displaying player scores on a global leaderboard, promoting competition and engagement among players.

## How to Play:
  **Game Controls:**
   - Use arrow keys to move Tetrominoes left or right.
   - Press the spacebar to drop Tetrominoes instantly.
   - Use Page Up and Page Down keys to rotate Tetrominoes clockwise and counterclockwise, respectively.
   - Pause the game, restart, or access leaderboards using the corresponding in-game buttons.

## Gameplay
You can play the game online [here](https://raghavpatpatia.itch.io/tetris).

## YouTube Gameplay
- [Watch the gameplay video on YouTube](https://www.youtube.com/watch?v=7wO5HsmbMDE)
- [![YouTube Gameplay](https://img.youtube.com/vi/7wO5HsmbMDE/maxresdefault.jpg)](https://www.youtube.com/watch?v=7wO5HsmbMDE)

## Credits:
- Created by [Raghav Patpatia]
- Inspired by the classic Tetris game

## License:
This project is licensed under the [MIT License](LICENSE) - see the [LICENSE](LICENSE) file for details.

## Support:
For any questions, issues, or feedback, please contact [raghav.patpatia@gmail.com].
