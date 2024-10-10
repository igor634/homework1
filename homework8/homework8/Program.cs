using System;


abstract class Character
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int AttackPower { get; set; }

    // Конструктор
    public Character(string name, int health, int attackPower)
    {
        Name = name;
        Health = health;
        AttackPower = attackPower;
    }

    // Метод для атаки
    public virtual void Attack(Character target)
    {
        Console.WriteLine($"{Name} атакует {target.Name} с силой {AttackPower}.");
        target.TakeDamage(AttackPower);
    }

    // Метод для получения урона
    public void TakeDamage(int damage)
    {
        Health -= damage;
        Console.WriteLine($"{Name} получил {damage} урона. Осталось здоровья: {Health}.");
        if (Health <= 0)
        {
            Console.WriteLine($"{Name} был побеждён!");
        }
    }

    // Абстрактный метод для уникальных способностей персонажа
    public abstract void SpecialAbility();
}


class Warrior : Character
{
    public int ShieldProtection { get; set; }

    public Warrior(string name, int health, int attackPower, int shieldProtection)
        : base(name, health, attackPower)
    {
        ShieldProtection = shieldProtection;
    }

    // Переопределение метода атаки
    public override void Attack(Character target)
    {
        Console.WriteLine($"{Name} использует меч и атакует {target.Name} с силой {AttackPower}.");
        base.Attack(target);
    }

    // Специальная способность — использовать щит для снижения урона
    public override void SpecialAbility()
    {
        Console.WriteLine($"{Name} использует щит, уменьшая получаемый урон на {ShieldProtection}.");
    }

    // Метод для блокировки атаки с щитом
    public void BlockAttack(int incomingDamage)
    {
        int damageBlocked = Math.Max(0, incomingDamage - ShieldProtection);
        TakeDamage(damageBlocked);
    }
}


class Mage : Character
{
    public int Mana { get; set; }

    public Mage(string name, int health, int attackPower, int mana)
        : base(name, health, attackPower)
    {
        Mana = mana;
    }

    public override void Attack(Character target)
    {
        if (Mana >= 10)
        {
            Console.WriteLine($"{Name} использует магическую атаку против {target.Name}, потратив 10 маны.");
            Mana -= 10;
            base.Attack(target);
        }
        else
        {
            Console.WriteLine($"{Name} не хватает маны для магической атаки!");
        }
    }

    // Специальная способность — восстанавливать ману
    public override void SpecialAbility()
    {
        Console.WriteLine($"{Name} восстанавливает ману на 20.");
        Mana += 20;
    }
}

class Archer : Character
{
    public int Arrows { get; set; }

    public Archer(string name, int health, int attackPower, int arrows)
        : base(name, health, attackPower)
    {
        Arrows = arrows;
    }

 
    public override void Attack(Character target)
    {
        if (Arrows > 0)
        {
            Console.WriteLine($"{Name} выпускает стрелу в {target.Name} с силой {AttackPower}.");
            Arrows--;
            base.Attack(target);
        }
        else
        {
            Console.WriteLine($"{Name} закончились стрелы!");
        }
    }

    // Специальная способность — восполнение стрел
    public override void SpecialAbility()
    {
        Console.WriteLine($"{Name} находит стрелы и пополняет свой колчан.");
        Arrows += 5;
    }
}

// Тестирование
class Program
{
    static void Main(string[] args)
    {
        
        Warrior warrior = new Warrior("Arthur", 100, 15, 5);
        Mage mage = new Mage("Merlin", 80, 20, 30);
        Archer archer = new Archer("Robin", 90, 10, 10);

        
        warrior.Attack(mage);
        mage.SpecialAbility(); // Восстановление маны
        mage.Attack(warrior);
        archer.SpecialAbility(); // Пополнение стрел
        archer.Attack(mage);

        // Проверка защиты воина
        warrior.BlockAttack(25); // Учитывается защита щитом
    }
}
