using System;
using System.Collections;

namespace srd5 {
    public class Tile {

    }

    public class Coord : Location {
        public int X;

        public int Y;

        public Coord(int x, int y) {
            X = x;
            Y = y;
        }

        public override int Distance(Location another) {
            if (!(another is Coord)) throw new ArgumentException("another must be a Coord.");
            Coord anotherCoord = (Coord)another;
            double dX = this.X - anotherCoord.X;
            double dY = this.Y - anotherCoord.Y;
            double distance = Math.Sqrt(dX * dX + dY * dY);
            return (int)Math.Round(distance * 5); // one tile is 5ft x 5ft
        }
    }

    public abstract class Location {
        public abstract int Distance(Location another);
    }

    public class ClassicLocation : Location {
        public enum Row {
            FRONT,
            BACK
        }

        public Row Location { get; internal set; }

        public ClassicLocation(Row row) {
            Location = row;
        }

        public override int Distance(Location another) {
            if (!(another is ClassicLocation)) throw new ArgumentException("another must be a ClassicLocation.");
            ClassicLocation classicAnother = (ClassicLocation)another;
            if (this.Location == Row.FRONT) {
                if (classicAnother.Location == Row.FRONT)
                    return 5;
                else
                    return 25;
            } else {
                if (classicAnother.Location == Row.FRONT)
                    return 25;
                else
                    return 45;
            }
        }
    }

    internal class ReverseComparer : System.Collections.IComparer {
        int IComparer.Compare(object x, object y) {
            return new CaseInsensitiveComparer().Compare(y, x);
        }
    }

    public class Battleground2D : Battleground {
        public Tile[,] Tiles { get; internal set; }
        private Coord[] coords = new Coord[0];

        public Battleground2D(int x, int y) {
            Tiles = new Tile[x, y];
            for (int i = 0; i < x; i++) {
                for (int j = 0; j < y; j++) {
                    Tiles[i, j] = new Tile();
                }
            }
        }

        public override void Initialize() {
            base.Initialize();
            Array.Sort(initiativeRolls, coords, new ReverseComparer());
            Turn = 1;
        }

        public override Location LocateCombattant(Combattant combattant) {
            return coords[Array.IndexOf(combattants, combattant)];
        }

        public Coord LocateCombattant2D(Combattant combattant) {
            return coords[Array.IndexOf(combattants, combattant)];
        }

        public void AddCombattant(Combattant combattant, int x, int y) {
            AddCombattant(combattant);
            Utils.Push<Coord>(ref coords, new Coord(x, y));
        }

        protected override void SetCurrentLocation(Location location) {
            coords[currentCombattant] = (Coord)location;
        }
    }

    public enum TurnPhase {
        MOVE,
        ACTION,
        BONUS_ACTION
    }

    public abstract class Battleground {

        protected Combattant[] combattants = new Combattant[0];

        public int Turn { get; internal set; } = 0;
        protected int[] initiativeRolls = new int[0];
        public Combattant CurrentCombattant {
            get {
                return combattants[currentCombattant];
            }
        }
        protected int currentCombattant = 0;
        protected int remainingSpeed = 0;
        protected TurnPhase currentPhase = TurnPhase.MOVE;

        public virtual void Initialize() {
            if (Turn > 0) return;
            // Sort Combattants and Coords according to Initiative Rolls
            int[] backup = new int[initiativeRolls.Length];
            Array.Copy(initiativeRolls, backup, initiativeRolls.Length);
            Array.Sort(backup, combattants, new ReverseComparer());
            currentCombattant = 0;
            currentPhase = TurnPhase.MOVE;
            remainingSpeed = CurrentCombattant.Speed;
        }

        private void NextCombattant() {
            currentCombattant++;
            currentCombattant %= combattants.Length;
            if (currentCombattant == 0) Turn++;
            currentPhase = TurnPhase.MOVE;
            remainingSpeed = CurrentCombattant.Speed;
        }

        /// <summary>
        /// Add a combattant to the battlefield and roll initiative
        /// </summary>
        public void AddCombattant(Combattant combattant) {
            if (Array.IndexOf(combattants, combattant) >= 0) return;
            Utils.Push<Combattant>(ref combattants, combattant);
            Utils.Push<int>(ref initiativeRolls, Dice.D20.Value + combattant.Dexterity.Modifier);
        }

        /// <summary>
        /// Move on to the next phase (MOVE -> ACTION -> BONUS ACTION -> Next Combattant)
        /// </summary>
        public void NextPhase() {
            switch (currentPhase) {
                case TurnPhase.MOVE:
                    remainingSpeed = 0;
                    currentPhase = TurnPhase.ACTION;
                    break;
                case TurnPhase.ACTION:
                    if (CurrentCombattant.BonusAttack != null)
                        currentPhase = TurnPhase.BONUS_ACTION;
                    else
                        NextCombattant();
                    break;
                case TurnPhase.BONUS_ACTION:
                    NextCombattant();
                    break;
            }
        }

        /// <summary>
        /// Move the current combattant to the target destination if able
        /// </summary>
        public bool MoveAction(Location destination) {
            if (destination == null) throw new ArgumentException("destination cannot be null");
            int distance = destination.Distance(LocateCombattant(CurrentCombattant));
            if (distance > remainingSpeed) return false;
            remainingSpeed -= distance;
            SetCurrentLocation(destination);
            return true;
        }

        /// <summary>
        /// Current combattant melee attacks a target if able
        /// </summary>
        public bool MeleeAttackAction(Combattant target) {
            if (currentPhase == TurnPhase.MOVE) return false;
            if (target == null) throw new ArgumentException("target cannot be null");
            if (target == CurrentCombattant) throw new ArgumentException("cannot attack self");
            bool success = false;
            if (currentPhase == TurnPhase.ACTION)
                success = doFullMeleeAttack(target);
            else
                success = doBonusMeleeAttack(target);
            if (success) NextPhase();
            return success;
        }

        /// <summary>
        /// Current combattant casts a spell if able
        /// <summary>
        public bool SpellCastAction() {
            throw new NotImplementedException();
        }

        private bool doBonusMeleeAttack(Combattant target) {
            bool success = false;
            int distance = LocateCombattant(target).Distance(LocateCombattant(CurrentCombattant));
            Attack attack = CurrentCombattant.BonusAttack;
            if (distance > attack.Reach) return false;
            success = true;
            doAttack(attack, target);
            return success;
        }

        private bool doFullMeleeAttack(Combattant target) {
            bool success = false;
            int distance = LocateCombattant(target).Distance(LocateCombattant(CurrentCombattant));
            foreach (Attack attack in CurrentCombattant.MeleeAttacks) {
                if (distance > attack.Reach) continue; // skip attack when out of reach
                success = true;
                doAttack(attack, target);
            }
            return success;
        }

        private void doAttack(Attack attack, Combattant target) {
            int attackRoll = Dice.D20.Value;
            bool criticalHit = attackRoll == 20;
            bool criticalMiss = attackRoll == 1;
            if (criticalMiss) return;
            int modifiedAttack = attackRoll + attack.AttackBonus;
            if (!criticalHit && modifiedAttack < target.ArmorClass) return;
            target.TakeDamage(attack.Damage, criticalHit);
            if (attack.AdditionalDamage != null)
                target.TakeDamage(attack.AdditionalDamage, criticalHit);
        }

        /// <summary>
        /// Returns the Location of the given combattant
        /// </summary>
        public abstract Location LocateCombattant(Combattant combattant);

        /// <summary>
        /// Set the location of the current active combattant
        /// </summary>
        protected abstract void SetCurrentLocation(Location location);
    }
}