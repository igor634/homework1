using System;
namespace Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.StartGame();
        }
    }

    public class Game
    {
        private static string gameName = "Medieval Tactic";
        private static string gameVersion = "a0.0.1";

        private const int fieldWidth = 8;
        private const int fieldHeight = 8;

        private List<Character> playerCharacters;
        private List<Character> enemyCharacters;

        public Game()
        {
            playerCharacters = new List<Character>()
            {
                new Character(CharacterTypes.Warrior, new Coordinates(1,4)),
                new Character(CharacterTypes.Archer, new Coordinates(0,3)),
                new Character(CharacterTypes.Ballista, new Coordinates(0,5)),
            };
            enemyCharacters = new List<Character>()
            {
                new Character(CharacterTypes.Warrior, new Coordinates(6,4)),
                new Character(CharacterTypes.Archer, new Coordinates(7,2)),
                new Character(CharacterTypes.Ballista, new Coordinates(7,6)),
            };
        }

        public void StartGame()
        {
            while (true)
            {
                RenderGame();
                PlayerMove();
                EnemyMove();
            }
        }

        private void RenderGame()
        {
            Console.Clear();
            Render.RenderField(fieldWidth, fieldHeight);
            Render.RenderPlayerCharacters(playerCharacters);
            Render.RenderEnemyCharacters(enemyCharacters);
            Console.SetCursorPosition(0, 25);
        }

        private void PlayerMove()
        {
            foreach (Character character in playerCharacters)
            {
                if (character.IsAlive)
                {
                    Console.WriteLine($"{character.Type} на позиции ({character.Position.X},{character.Position.Y})");
                    Console.WriteLine("1 - переместиться");
                    Console.WriteLine("2 - атаковать");
                    Console.WriteLine("Выберите действие!");

                    var action = Console.ReadKey();
                    while (action.Key != ConsoleKey.D1 && action.Key != ConsoleKey.D2)
                    {
                        action = Console.ReadKey();
                    }

                    switch (action.Key)
                    {
                        case ConsoleKey.D1:
                            Console.WriteLine("Выберите направление (WASD)!");
                            var direction = Console.ReadKey();
                            Coordinates newCoordinates = GetNewCoordinates(character, direction.Key);

                            // Проверка на столкновение с персонажами
                            if (!IsCollideWithOtherCharacters(newCoordinates, playerCharacters) &&
                                !IsCollideWithOtherCharacters(newCoordinates, enemyCharacters))
                            {
                                character.Move = newCoordinates;
                            }
                            else
                            {
                                Console.WriteLine("Столкновение! Невозможно переместиться.");
                            }
                            break;

                        case ConsoleKey.D2:
                            Console.WriteLine("Атака!");
                            Attack(character, enemyCharacters);
                            break;
                    }
                }
            }
        }

        private void EnemyMove()
        {
            Random random = new Random();
            foreach (Character character in enemyCharacters)
            {
                if (character.IsAlive)
                {
                    // Случайное движение или атака
                    if (random.Next(2) == 0) // 50% вероятность двигаться
                    {
                        ConsoleKey direction = (ConsoleKey)new[] { ConsoleKey.W, ConsoleKey.A, ConsoleKey.S, ConsoleKey.D }[random.Next(4)];
                        Coordinates newCoordinates = GetNewCoordinates(character, direction);

                        if (!IsCollideWithOtherCharacters(newCoordinates, enemyCharacters) &&
                            !IsCollideWithOtherCharacters(newCoordinates, playerCharacters))
                        {
                            character.Move = newCoordinates;
                        }
                    }
                    else // 50% вероятность атаки
                    {
                        Attack(character, playerCharacters);
                    }
                }
            }
        }

        private Coordinates GetNewCoordinates(Character character, ConsoleKey direction)
        {
            switch (direction)
            {
                case ConsoleKey.W:
                    return new Coordinates(character.Position.X, character.Position.Y - 1);
                case ConsoleKey.S:
                    return new Coordinates(character.Position.X, character.Position.Y + 1);
                case ConsoleKey.A:
                    return new Coordinates(character.Position.X - 1, character.Position.Y);
                case ConsoleKey.D:
                    return new Coordinates(character.Position.X + 1, character.Position.Y);
                default:
                    return character.Position;
            }
        }

        private bool IsCollideWithOtherCharacters(Coordinates newCoordinates, List<Character> otherCharacters)
        {
            foreach (var character in otherCharacters)
            {
                if (character.Position.isCollide(newCoordinates) && character.IsAlive)
                {
                    return true;
                }
            }
            return false;
        }

        private void Attack(Character attacker, List<Character> targets)
        {
            foreach (var target in targets)
            {
                if (attacker.Position.isWithinRange(target.Position, attacker.AttackRange) && target.IsAlive)
                {
                    target.Damage = attacker.Attack;
                    Console.WriteLine($"{attacker.Type} атаковал {target.Type} и нанес {attacker.Attack} урона!");
                    if (!target.IsAlive)
                    {
                        Console.WriteLine($"{target.Type} был убит.");
                    }
                    return;
                }
            }
            Console.WriteLine("Нет врагов в зоне досягаемости.");
        }
    }

    public static class Render
    {
        public static void RenderField(int width, int height)
        {
            for (int i = 0; i <= height * 3; i++)
            {
                for (int j = 0; j <= width * 4; j++)
                {
                    if (i % 3 == 0 || i == 0)
                    {
                        Console.Write('-');
                    }
                    else
                    {
                        if (j == 0 || j % 4 == 0)
                        {
                            Console.Write('|');
                        }
                        else
                        {
                            Console.Write(' ');
                        }
                    }
                }
                Console.WriteLine();
            }
        }

        public static void RenderPlayerCharacters(List<Character> characters)
        {
            foreach (var character in characters)
            {
                if (character.IsAlive)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(2 + (4 * character.Position.X), 1 + (3 * character.Position.Y));
                    Console.Write(character.Type.ToString()[0]);
                    Console.SetCursorPosition(2 + (4 * character.Position.X), 2 + (3 * character.Position.Y));
                    Console.Write(character.Health);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }

        public static void RenderEnemyCharacters(List<Character> characters)
        {
            foreach (var character in characters)
            {
                if (character.IsAlive)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(2 + (4 * character.Position.X), 1 + (3 * character.Position.Y));
                    Console.Write(character.Type.ToString()[0]);
                    Console.SetCursorPosition(2 + (4 * character.Position.X), 2 + (3 * character.Position.Y));
                    Console.Write(character.Health);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
    }

    public class Character
    {
        Coordinates coordinates;
        CharacterTypes type;
        bool isAlive;
        int health;
        int armor;
        int attackPower;
        int attackRange;

        public int Health { get { return health; } }
        public int Attack { get { return attackPower; } }
        public int AttackRange { get { return attackRange; } }
        public CharacterTypes Type { get { return type; } }
        public bool IsAlive { get { return isAlive; } }
        public Coordinates Position { get { return coordinates; } }
        public Coordinates Move
        {
            set
            {
                if (Math.Abs(coordinates.X - value.X) <= 1 && Math.Abs(coordinates.Y - value.Y) <= 1)
                {
                    coordinates = value;
                }
            }
        }

        public int Damage
        {
            set
            {
                int effectiveDamage = value - armor;
                if (effectiveDamage > 0)
                {
                    health -= effectiveDamage;
                    if (health <= 0)
                    {
                        health = 0;
                        isAlive = false;
                    }
                }
            }
        }

        public Character(CharacterTypes type, Coordinates coordinates)
        {
            this.type = type;
            this.coordinates = coordinates;
            isAlive = true;

            switch (type)
            {
                case CharacterTypes.Warrior:
                    health = 250;
                    armor = 80;
                    attackPower = 100;
                    attackRange = 1;
                    break;
                case CharacterTypes.Archer:
                    health = 160;
                    armor = 30;
                    attackPower = 150;
                    attackRange = 2;
                    break;
                case CharacterTypes.Ballista:
                    health = 80;
                    armor = 10;
                    attackPower = 260;
                    attackRange = 3;
                    break;
            }
        }
    }

    public enum CharacterTypes
    {
        Warrior,
        Archer,
        Ballista,
    }

    public class Coordinates
    {
        int x;
        int y;

        public int X { get { return x; } }
        public int Y { get { return y; } }

        public Coordinates(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public bool isCollide(Coordinates other)
        {
            return this.x == other.x && this.y == other.y;
        }

        public bool isWithinRange(Coordinates other, int range)
        {
            return Math.Abs(this.x - other.x) + Math.Abs(this.y - other.y) <= range;
        }
    }
}