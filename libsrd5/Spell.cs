namespace srd5 {
    public class Spell {
        public string Name { get; private set; }
        public SpellSchool School { get; private set; }
        public SpellLevel Level { get; private set; }
        public CastingTime CastingTime { get; private set; }
        public int Range { get; private set; }
        public SpellComponent[] Components { get; private set; }
        public SpellDuration Duration { get; private set; }
        public int AreaOfEffect { get; private set; }
        public int MaximumTargets { get; private set; }
        private SpellCastEffect cast;

        public Spell(string name, SpellSchool school, SpellLevel level, CastingTime castingTime,
                     int range, SpellComponent[] components, SpellDuration duration,
                     int areaOfEffect, int maximumTargets, SpellCastEffect effect) {
            Name = name;
            School = school;
            Level = level;
            CastingTime = castingTime;
            Range = range;
            Components = components;
            Duration = duration;
            AreaOfEffect = areaOfEffect;
            MaximumTargets = maximumTargets;
            cast = effect;
        }

        public void Cast(Combattant caster, SpellLevel slot, params Combattant[] targets) {
            cast(caster, slot, targets);
        }
    }
}