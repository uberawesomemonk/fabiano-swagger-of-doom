using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ OryxChicken = () => Behav()
            .Init("Test Egg",
                new State(
                    new State("Idle",
                        new HpLessTransition(630000, "1")
                    ),
                    new State("1",
                        new HpLessTransition(610000, "2"),
                        new SetAltTexture(1)
                    ),
                    new State("2",
                        new HpLessTransition(590000, "3"),
                        new SetAltTexture(2)
                    ),
                    new State("3",
                        new HpLessTransition(570000, "4"),
                        new SetAltTexture(3)
                    ),
                    new State("4",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new SetAltTexture(4),
                        new TimedTransition(250, "Break")
                    ),
                    new State("Break",
                        new Transform("TestChicken 2")
                    )
                )
            )
            .Init("TestChicken 2",
                new State(
                    new HpLessTransition(.1, "Death"),
                    new Prioritize(
                        new StayCloseToSpawn(0.6, 5),
                        new Wander(0.03)
                    ),
                    new State("Idle",
                        new ChangeSize(20, 100),
                        new TimedTransition(600, "Start")
                    ),
                    new State("Start",
                        new Taunt("CLUCK!"),
                        new State("Shoot",
                            new EntityNotExistsTransition("TestChicken Small", 10, "Spawn Minions"),
                            new Shoot(10, 2), //2 bullets, small purple
                            new Shoot(25, projectileIndex: 1, count: 8, shootAngle: 45, coolDown: 1500, coolDownOffset: 1500), //8 bullets, in circle, dirk cronus, increase distance by alot
                            new HpLessTransition(.3, "Rage")
                        ),
                        new State("Spawn Minions",
                            new Spawn("TestChicken Small", 5, 1),
                            new TimedTransition(0, "Shoot")
                        ),

                        new State("Rage",
                        new Taunt("AH! You've stopped my chicks from hatching!"),
                        new TossObject("Ring Element", 9, 24, 320000),
                        new TossObject("Ring Element", 9, 48, 320000),
                        new TossObject("Ring Element", 9, 72, 320000),
                        new TossObject("Ring Element", 9, 96, 320000),
                        new TossObject("Ring Element", 9, 120, 320000),
                        new TossObject("Ring Element", 9, 144, 320000),
                        new TossObject("Ring Element", 9, 168, 320000),
                        new TossObject("Ring Element", 9, 192, 320000),
                        new TossObject("Ring Element", 9, 216, 320000),
                        new TossObject("Ring Element", 9, 240, 320000),
                        new TossObject("Ring Element", 9, 264, 320000),
                        new TossObject("Ring Element", 9, 288, 320000),
                        new TossObject("Ring Element", 9, 312, 320000),
                        new TossObject("Ring Element", 9, 336, 320000),
                        new TossObject("Ring Element", 9, 360, 320000),
                        new Shoot(25, projectileIndex: 2, count: 3, shootAngle: 10, coolDown: 1000, coolDownOffset: 1000),// big stars, massive damage bump spd up
                        new Shoot(count: 2, coolDown: 1000, projectileIndex: 3, radius: 7, shootAngle: 10, coolDownOffset: 800), //little stars, confuse bump spd up
                        new Shoot(25, projectileIndex: 4, count: 3, shootAngle: 10, predictive: 0.2, coolDown: 1000, coolDownOffset: 1000),
                        new Shoot(25, projectileIndex: 5, count: 3, shootAngle: 10, predictive: 0.6, coolDown: 1000, coolDownOffset: 1000),
                        new Shoot(25, projectileIndex: 6, count: 2, shootAngle: 10, predictive: 0.8, coolDown: 1000, coolDownOffset: 1000)
                        ),

                         new State("Death",
                        new Taunt("Happy thanksgiving you forsaken pilgrims!")
                        )
                    )

                ),

                new Threshold(0.05,
                    new ItemLoot("Potion of Life", 0.5),
                    new ItemLoot("Potion of Mana", 0.5),
                    new ItemLoot("Chicken Leg of Doom", 0.05),
                    new TierLoot(12, ItemType.Weapon, 0.2),
                    new TierLoot(6, ItemType.Ability, 0.2),
                    new ItemLoot("Wyrmhide Armor", 0.05),
                    new ItemLoot("Leviathan Armor", 0.05),
                    new ItemLoot("Dominion Armor", 0.05),
                    new ItemLoot("Annihilation Armor", 0.05),
                    new ItemLoot("Robe of the Star Mother", 0.05),
                    new ItemLoot("Robe of the Ancient Intellect", 0.05),
                    new ItemLoot("Staff of the Vital Unity", 0.05),
                    new ItemLoot("Staff of the Fundamental Core", 0.05),
                    new ItemLoot("Dagger of Sinister Deeds", 0.05),
                    new ItemLoot("Dagger of Dire Hatred", 0.05),
                    new ItemLoot("Bow of Mystical Energy", 0.05),
                    new ItemLoot("Bow of Deep Enchantment", 0.05),
                    new ItemLoot("Wand of Evocation", 0.05),
                    new ItemLoot("Wand of Retribution", 0.05),
                    new ItemLoot("Sword of Splendor", 0.05),
                    new ItemLoot("Sword of Majesty", 0.05),
                    new TierLoot(5, ItemType.Ring, 0.2),
                    new TierLoot(6, ItemType.Ring, 0.15)
                )

            )
            .Init("TestChicken Small",
                new State(
                    new Prioritize(
                        new Protect(0.6, "TestChicken 2"),
                        new Wander(0.6)
                    ),
                    new State("Default",
                        new Shoot(10, 8, projectileIndex: 2, coolDown: 1000)
                    ),
                    new State("Despawn",
                        new Suicide()
                    )
                ),
                new Threshold(0.05,
                    new ItemLoot("Potion of Life", 0.01),
                    new ItemLoot("Potion of Mana", 0.01),
                    new ItemLoot("Chicken Leg of Doom", 0.001)
                    )
            );
    }
}
