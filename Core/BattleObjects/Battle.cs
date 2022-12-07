using IOT1030_Phase2_GUI.Core.Heroes;
using IOT1030_Phase2_GUI.Core.Monsters;
using IOT1030_Phase2_GUI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOT1030_Phase2_GUI.Core.MonsterAttacks;

namespace IOT1030_Phase2_GUI.Core.BattleObjects
{
    public enum Turn
    {
        Hero,
        Monster
    }

    public class Battle
    {
        /// <summary>
        /// The hero
        /// </summary>
        private Hero _hero;
        public Hero Hero { get { return _hero; } }

        /// <summary>
        /// The monster
        /// </summary>
        private Monster _monster;
        public Monster Monster { get { return _monster; } }

        /// <summary>
        /// The current turn
        /// </summary>
        private Turn _currentTurn;
        public Turn CurrentTurn { get { return _currentTurn; } }

        /// <summary>
        /// The random object
        /// </summary>
        private Random _random;

        /// <summary>
        /// The attack log
        /// </summary>
        private List<Attack> _attackLog;
        public List<Attack> AttackLog { get { return _attackLog; } }

        public Battle(Hero hero, Monster monster)
        {
            _hero = hero;
            _monster = monster;

            _random = new Random();

            _attackLog = new List<Attack>();
        }

        /// <summary>
        /// Chooses the first turn.
        /// </summary>
        /// <returns></returns>
        public Turn ChooseFirstTurn()
        {
            int heroStat = Hero.GetStat(Stats.Agility) + Hero.GetStat(Stats.Stealth);
            int chanceModifyerPercent = RNG.StatToPercentage(heroStat, 5, 60, 15);

            float minimumModifyerPercent = 50f;
            int chanceToGoFirst = (int)(minimumModifyerPercent * ((float)chanceModifyerPercent / 100f));
            int randomNumber = _random.Next(0, 100);

            if (chanceToGoFirst > randomNumber)
            {
                _currentTurn = Turn.Hero;
                return Turn.Hero;
            }
            _currentTurn = Turn.Monster;
            return Turn.Monster;
                
        }

        /// <summary>
        /// Adds a copy of the attack to log.
        /// </summary>
        /// <param name="attack">The attack.</param>
        public void AddAttackToLog(Attack attack)
        {
            if(attack.GetType() == typeof(MonsterAttack))
            {
                _attackLog.Add(new MonsterAttack(attack.Name, attack.Description, attack.DamageDealt));
            }
            else
            {
                _attackLog.Add(new Attack(attack.Name, attack.Description, attack.WeaponDamage, attack.MaxWeaponMultiplierPercentage, attack.WeaponMultiplierPercentage, attack.DamageDealt));
            }
        }

        /// <summary>
        /// Takes the turn.
        /// </summary>
        /// <param name="turn">The turn.</param>
        /// <param name="attack">The attack.</param>
        public void TakeTurn(Turn turn, Attack attack = null)
        {
            _attackLog = new List<Attack>();
            if(turn != CurrentTurn)
            {
                Console.WriteLine("Not your turn!");
                return;
            }

            MonsterAttack monsterAttack;
            bool monsterAlive = true;

            if (turn == Turn.Hero)
            {
                monsterAlive = _monster.TakeDamage(attack.UseAttack(Hero.Stats, Hero.EquippedWeapon));
                _attackLog.Add(attack);
            }

            if (monsterAlive)
            {
                monsterAttack = Monster.TakeAction();
                _hero.TakeDamage(monsterAttack.UseAttack());
                _attackLog.Add(monsterAttack);
            }
            else
            {
                Console.WriteLine("Monster is dead!");
            }
            _currentTurn = Turn.Hero;
        }
    }
}
