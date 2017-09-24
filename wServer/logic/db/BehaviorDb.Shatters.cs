using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Shatters = () => Behav()
            .Init("shtrs Stone Paladin",
                new State(
                    new State("Idle",
                        new Prioritize(
                            new Wander(0.4)
                            ),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Reproduce(densityMax: 4),
                        new PlayerWithinTransition(8, "Attacking")
                        ),
                    new State("Attacking",
                        new State("Bullet",
                            new Shoot(1, 4, coolDown: 10000, fixedAngle: 90, coolDownOffset: 0, shootAngle: 90),
                            new Shoot(1, 4, coolDown: 10000, fixedAngle: 100, coolDownOffset: 200, shootAngle: 90),
                            new Shoot(1, 4, coolDown: 10000, fixedAngle: 110, coolDownOffset: 400, shootAngle: 90),
                            new Shoot(1, 4, coolDown: 10000, fixedAngle: 120, coolDownOffset: 600, shootAngle: 90),
                            new Shoot(1, 4, coolDown: 10000, fixedAngle: 130, coolDownOffset: 800, shootAngle: 90),
                            new Shoot(1, 4, coolDown: 10000, fixedAngle: 140, coolDownOffset: 1000, shootAngle: 90),
                            new Shoot(1, 4, coolDown: 10000, fixedAngle: 150, coolDownOffset: 1200, shootAngle: 90),
                            new Shoot(1, 4, coolDown: 10000, fixedAngle: 160, coolDownOffset: 1400, shootAngle: 90),
                            new Shoot(1, 4, coolDown: 10000, fixedAngle: 170, coolDownOffset: 1600, shootAngle: 90),
                            new Shoot(1, 4, coolDown: 10000, fixedAngle: 180, coolDownOffset: 1800, shootAngle: 90),
                            new Shoot(1, 4, coolDown: 10000, fixedAngle: 180, coolDownOffset: 2000, shootAngle: 45),
                            new Shoot(1, 4, coolDown: 10000, fixedAngle: 180, coolDownOffset: 0, shootAngle: 90),
                            new Shoot(1, 4, coolDown: 10000, fixedAngle: 170, coolDownOffset: 200, shootAngle: 90),
                            new Shoot(1, 4, coolDown: 10000, fixedAngle: 160, coolDownOffset: 400, shootAngle: 90),
                            new Shoot(1, 4, coolDown: 10000, fixedAngle: 150, coolDownOffset: 600, shootAngle: 90),
                            new Shoot(1, 4, coolDown: 10000, fixedAngle: 140, coolDownOffset: 800, shootAngle: 90),
                            new Shoot(1, 4, coolDown: 10000, fixedAngle: 130, coolDownOffset: 1000, shootAngle: 90),
                            new Shoot(1, 4, coolDown: 10000, fixedAngle: 120, coolDownOffset: 1200, shootAngle: 90),
                            new Shoot(1, 4, coolDown: 10000, fixedAngle: 110, coolDownOffset: 1400, shootAngle: 90),
                            new Shoot(1, 4, coolDown: 10000, fixedAngle: 100, coolDownOffset: 1600, shootAngle: 90),
                            new Shoot(1, 4, coolDown: 10000, fixedAngle: 90, coolDownOffset: 1800, shootAngle: 90),
                            new Shoot(1, 4, coolDown: 10000, fixedAngle: 90, coolDownOffset: 2000, shootAngle: 22.5),
                            new TimedTransition(2000, "Wait")
                            ),
                        new State("Wait",
                            new Follow(0.4, range: 2),
                            new Flash(0xff00ff00, 0.1, 20),
                            new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                            new TimedTransition(2000, "Bullet")
                            ),
                        new NoPlayerWithinTransition(9, "Idle")
                        )
                    )
            )
            .Init("shtrs Wooden Gate",
                new State(
                    new State("Idle",
                        new EntityNotExistsTransition("shtrs Abandoned Switch 1", 10, "Despawn")
                        ),
                    new State("Despawn",
                        new Decay(0)
                        ))
            )
            .Init("shtrs Stone Knight",
            new State(
                new State("Follow",
                        new Follow(1.5, range: .7),
                        new Charge(2, 10, coolDown: 1999),
                        new Shoot(5, 6, projectileIndex: 0, coolDown: 2000)
                    )
                    )
            )

        .Init("shtrs Spike",
            new State(
                 new TimedTransition(5000, "Suicide"),
                 new PlayerWithinTransition(.5, "Suicide"),
                new State("Poke",
                        new Shoot(5, 1, projectileIndex: 0, coolDown: 0)
                    ),

                new State("Suicide",
                        new Suicide()
                    )

                    )
            )


        .Init("shtrs Stone Mage",
            new State(
                new State("Follow",
                        new Follow(0.6, 10, 3),
                        new Shoot(5, 2, 1, projectileIndex: 0, coolDown: 50),
                        new TimedTransition(10000, "Radial blast"),
                        new PlayerWithinTransition(5, "Idle")
                    ),
                    new State("Idle",
                        new NoPlayerWithinTransition(5, "Follow"),
                        new Shoot(5, 2, 1, projectileIndex: 1, coolDown: 200)
                        ),
                new State("Radial blast",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(2000, "Follow"),
                        new Shoot(12, count: 10, projectileIndex: 0, coolDown: 1000),
                        new TossObject("shtrs Spike", 10, coolDown: 1900, coolDownOffset: 900, randomToss: true),
                        new TossObject("shtrs Spike", 10, coolDown: 1900, coolDownOffset: 900, randomToss: true),
                        new TossObject("shtrs Spike", 10, coolDown: 1900, coolDownOffset: 900, randomToss: true)
                        )
                    )
            )

        .Init("shtrs Fire Mage",
            new State(
                new State("Dormant",
                    new HpLessTransition(0.99, "Main"),
                    new Follow(1, acquireRange: 9, range: 3),
                    new Shoot(6, 3, 10, projectileIndex: 1, coolDown: 100, predictive: 0)
                ),

                new State("Main",
                    //Acquire range needs to be used on all other mobs in dungeon, 8 seems like a good range, maybe 9?
                    new TimedTransition(9500, "preradical"),
                    new Follow(1, acquireRange: 9, range: 3),
                    new Shoot(6, 3, 10, projectileIndex: 1, coolDown: 100, predictive: 0)
                ),

                new State("preradical",
                    //Flash also needs to be added along with a slight pause before other "rage stages" on other mobs within shatters.
                    new Flash(0xfFF0000, .5, 3),
                    new TimedTransition(500, "radical")
                ),

                new State("radical",
                    new Wander(1.2),
                    new Shoot(6, 3, 10, projectileIndex: 1, coolDown: 100, predictive: 0),
                    new TimedTransition(5000, "Main")
                )
                  ),

            new ItemLoot("Magic Potion", 0.1),
            new ItemLoot("Health Potion", 0.1)


            )

        .Init("shtrs Fire Adept",
            new State(
                new State("Main",
                    new TimedTransition(9500, "prethrow"),
                   new Follow(1, acquireRange: 9, range: 1),
                    new Shoot(3, 3, projectileIndex: 0, coolDown: 100, predictive: 0),
                    new Shoot(6, count: 3, projectileIndex: 1, coolDown: 4000)
                ),

                new State("prethrow",
                    new Flash(0xfFF0000, .5, 3),
                    new TimedTransition(500, "Throw")
                ),

                new State("Throw",
                    new TossObject("shtrs Fire Portal", 8, coolDown: 8000, coolDownOffset: 900, randomToss: false),
                    new TimedTransition(1000, "Main")
                )
                  ),
            new ItemLoot("Magic Potion", 0.1),
            new ItemLoot("Health Potion", 0.1)
            )

            .Init("shtrs Ice Mage",
            new State(
                new State("dormant",
                    new HpLessTransition(0.99, "Main"),
                    new Follow(.5, acquireRange: 9, range: 1),
                    new Shoot(9, 5, 10, projectileIndex: 0, coolDown: 1500)
                    ),
                new State("Main",
                    new TimedTransition(7500, "preSpawn"),
                    new Follow(.5, acquireRange: 9, range: 1),
                    new Shoot(9, 5, 10, projectileIndex: 0, coolDown: 1500)
                    ),

                new State("preSpawn",
                    new Flash(0xfFF0000, .5, 3),
                    new TimedTransition(500, "Spawn")
                ),

                new State("Spawn",
                    new TossObject("shtrs Ice Shield", 9, coolDown: 8000, coolDownOffset: 900, randomToss: false),
                    new TimedTransition(1000, "Main")
                    )

                ),
            new ItemLoot("Magic Potion", 0.1),
            new ItemLoot("Health Potion", 0.1)
            )

        .Init("shtrs Firebomb",
            new State(
                new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                new State("dormant",
                    new TimedTransition(2000, "boomboom")
                    ),


                new State("boomboom",
                    new Shoot(25, count: 5, fixedAngle: 0, projectileIndex: 0, coolDown: 500),
                    new Suicide()

                    )
                ))

            .Init("shtrs KillWall 1",
            new State(
                 new ChangeGroundOnDeath(new[] { "shtrs Pure Evil" }, new[] { "shtrs Bridge" }, 10),
                 new State("Start",
                        new EntityNotExistsTransition("shtrs Abandoned Switch 1", 1000, "Wake1")
                    ),

                    new State("Wake1",
                        new EntityNotExistsTransition("shtrs Abandoned Switch 2", 1000, "Wake2")
                        ),

                    new State("Wake2",
                        new EntityNotExistsTransition("shtrs Abandoned Switch 3", 1000, "Wake3")
                        ),

                    new State("Wake3",
                        new EntityNotExistsTransition("shtrs Abandoned Switch 4", 1000, "dormant")
                        ),
                new State("dormant",
                    new EntityNotExistsTransition("shtrs Bridge Sentinel", 1000, "Despawn")
                    ),
                new State("Despawn",
                    new Suicide()
                    )
                ))

        .Init("shtrs KillWall 2",
            new State(
                 new ChangeGroundOnDeath(new[] { "shtrs Bridge" }, new[] { "shtrs Pure Evil" }, 10),
                 new State("Start",
                        new EntityNotExistsTransition("shtrs Abandoned Switch 1", 1000, "Wake1")
                    ),

                    new State("Wake1",
                        new EntityNotExistsTransition("shtrs Abandoned Switch 2", 1000, "Wake2")
                        ),

                    new State("Wake2",
                        new EntityNotExistsTransition("shtrs Abandoned Switch 3", 1000, "Wake3")
                        ),

                    new State("Wake3",
                        new EntityNotExistsTransition("shtrs Abandoned Switch 4", 1000, "dormant")
                        ),

                new State("dormant",
                    new EntityNotExistsTransition("shtrs Abandoned Switch 5", 1000, "preDespawn")
                    ),
                new State("preDespawn",
                    new TimedTransition(30000, "Despawn")
                    ),

                new State("Despawn",
                    new Suicide()
                    )
                ))

        .Init("shtrs Glassier Archmage",
            new State(
                new State(
                new HpLessTransition(0.99, "Main"),
                new StayBack(.8, 7),
                new Follow(.8, acquireRange: 9, range: 7),
                new State("dormant",
                    new Shoot(9, count: 10, projectileIndex: 1, coolDown: 1000),
                    new Shoot(9, 1, 10, projectileIndex: 2, coolDownOffset: 200),
                    new Shoot(9, 1, 10, projectileIndex: 2, coolDownOffset: 400),
                    new Shoot(9, 1, 10, projectileIndex: 2, coolDownOffset: 800),
                    new Shoot(9, 1, 10, projectileIndex: 2, coolDownOffset: 1000),
                    new TimedTransition(1000, "dormant1")
                    ),
                    new State("dormant1",
                    new Shoot(9, count: 10, projectileIndex: 1, coolDown: 1000),
                    new Shoot(9, 1, 10, projectileIndex: 2, coolDownOffset: 200),
                    new Shoot(9, 1, 10, projectileIndex: 2, coolDownOffset: 400),
                    new Shoot(9, 1, 10, projectileIndex: 2, coolDownOffset: 800),
                    new Shoot(9, 1, 10, projectileIndex: 2, coolDownOffset: 1000),
                    new TimedTransition(1000, "dormant")
                    )
                    ),
            new State(
                new StayBack(.8, 7),
                new Follow(.8, acquireRange: 9, range: 7),
                new TimedTransition(9500, "prerage"),
                new State("Main",
                    new Shoot(9, count: 10, projectileIndex: 1, coolDown: 1000),
                    new Shoot(9, 1, 10, projectileIndex: 2, coolDownOffset: 200),
                    new Shoot(9, 1, 10, projectileIndex: 2, coolDownOffset: 400),
                    new Shoot(9, 1, 10, projectileIndex: 2, coolDownOffset: 800),
                    new Shoot(9, 1, 10, projectileIndex: 2, coolDownOffset: 1000),
                    new TimedTransition(1000, "Main1")
                    ),
                new State("Main1",
                    new Shoot(9, count: 10, projectileIndex: 1, coolDown: 1000),
                    new Shoot(9, 1, 10, projectileIndex: 2, coolDownOffset: 200),
                    new Shoot(9, 1, 10, projectileIndex: 2, coolDownOffset: 400),
                    new Shoot(9, 1, 10, projectileIndex: 2, coolDownOffset: 800),
                    new Shoot(9, 1, 10, projectileIndex: 2, coolDownOffset: 1000),
                    new TimedTransition(1000, "Main")
                    ),
                new State("prerage",
                    new Flash(0xfFF0000, .5, 3),
                    new TimedTransition(500, "rage")
                    ),
                new State(
                    new TimedTransition(4000, "Main"),
                new State("rage",
                    new ConditionalEffect(ConditionEffectIndex.Armored),
                    new Shoot(9, count: 10, projectileIndex: 1, coolDown: 1000),
                    new Shoot(9, 1, 10, projectileIndex: 2, coolDownOffset: 200),
                    new Shoot(9, 1, 10, projectileIndex: 2, coolDownOffset: 400),
                    new Shoot(9, 1, 10, projectileIndex: 2, coolDownOffset: 600),
                    new Shoot(9, 1, 10, projectileIndex: 2, coolDownOffset: 800),
                    new Shoot(9, 1, 10, projectileIndex: 2, coolDownOffset: 1000),
                    new Shoot(9, count: 12, projectileIndex: 0, coolDown: 500),
                    new TimedTransition(1000, "rage1")
                    ),

                new State("rage1",
                    new ConditionalEffect(ConditionEffectIndex.Armored),
                    new Shoot(9, count: 10, projectileIndex: 1, coolDown: 1000),
                    new Shoot(9, 1, 10, projectileIndex: 2, coolDownOffset: 200),
                    new Shoot(9, 1, 10, projectileIndex: 2, coolDownOffset: 400),
                    new Shoot(9, 1, 10, projectileIndex: 2, coolDownOffset: 600),
                    new Shoot(9, 1, 10, projectileIndex: 2, coolDownOffset: 800),
                    new Shoot(9, 1, 10, projectileIndex: 2, coolDownOffset: 1000),
                    new Shoot(9, count: 12, projectileIndex: 0, coolDown: 500),
                    new TimedTransition(1000, "rage")
                    )

                ))))


            .Init("shtrs Archmage of Flame",
            new State(
                new State("dormant",
                    new HpLessTransition(0.99, "Main"),
                    new Follow(.8, acquireRange: 9, range: 5)
                    ),
            new State(
                new TimedTransition(9500, "prebombs"),
                new State("Main",
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                    new Follow(.8, acquireRange: 9, range: 3),
                    new PlayerWithinTransition(4, "Start")
                    ),
                new State("Start",
                    new TimedTransition(100, "Start2"),
                    new Shoot(9, 1, 10, projectileIndex: 0, fixedAngle: 0, coolDownOffset: 0),
                    new Shoot(9, 1, 10, projectileIndex: 0, fixedAngle: 90, coolDownOffset: 0),
                    new Shoot(9, 1, 10, projectileIndex: 0, fixedAngle: 180, coolDownOffset: 0),
                    new Shoot(9, 1, 10, projectileIndex: 0, fixedAngle: 270, coolDownOffset: 0)
                    ),

                new State("Start2",
                    new TimedTransition(100, "Start3"),
                    new Shoot(9, 1, 10, projectileIndex: 0, fixedAngle: 45, coolDownOffset: 0),
                    new Shoot(9, 1, 10, projectileIndex: 0, fixedAngle: 135, coolDownOffset: 0),
                    new Shoot(9, 1, 10, projectileIndex: 0, fixedAngle: 225, coolDownOffset: 0),
                    new Shoot(9, 1, 10, projectileIndex: 0, fixedAngle: 315, coolDownOffset: 0)
                    ),

                new State("Start3",
                    new TimedTransition(100, "Start4"),
                    new Shoot(9, 1, 10, projectileIndex: 0, fixedAngle: 0, coolDownOffset: 0),
                    new Shoot(9, 1, 10, projectileIndex: 0, fixedAngle: 90, coolDownOffset: 0),
                    new Shoot(9, 1, 10, projectileIndex: 0, fixedAngle: 180, coolDownOffset: 0),
                    new Shoot(9, 1, 10, projectileIndex: 0, fixedAngle: 270, coolDownOffset: 0)
                    ),

                new State("Start4",
                    new TimedTransition(100, "Main"),
                    new Shoot(9, 1, 10, projectileIndex: 0, fixedAngle: 45, coolDownOffset: 0),
                    new Shoot(9, 1, 10, projectileIndex: 0, fixedAngle: 135, coolDownOffset: 0),
                    new Shoot(9, 1, 10, projectileIndex: 0, fixedAngle: 225, coolDownOffset: 0),
                    new Shoot(9, 1, 10, projectileIndex: 0, fixedAngle: 315, coolDownOffset: 0)
                    )),

            new State("prebombs",
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                    new Follow(.8, acquireRange: 9, range: 3),
                    new Flash(0xfFF0000, .5, 3),
                    new TimedTransition(500, "bombs")
                    ),

            new State("bombs",
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                    new TossObject("shtrs Firebomb", 4, coolDown: 0, coolDownOffset: 0, randomToss: true),
                    new TossObject("shtrs Firebomb", 4, coolDown: 0, coolDownOffset: 0, randomToss: true),
                    new TossObject("shtrs Firebomb", 4, coolDown: 0, coolDownOffset: 0, randomToss: true),
                    new TossObject("shtrs Firebomb", 4, coolDown: 0, coolDownOffset: 0, randomToss: true),
                    new TossObject("shtrs Firebomb", 4, coolDown: 0, coolDownOffset: 0, randomToss: true),
                    new TossObject("shtrs Firebomb", 4, coolDown: 0, coolDownOffset: 0, randomToss: true),
                    new TossObject("shtrs Firebomb", 4, coolDown: 0, coolDownOffset: 0, randomToss: true),
                    new TossObject("shtrs Firebomb", 4, coolDown: 0, coolDownOffset: 0, randomToss: true),
                    new TossObject("shtrs Firebomb", 4, coolDown: 0, coolDownOffset: 0, randomToss: true),
                    new TossObject("shtrs Firebomb", 4, coolDown: 0, coolDownOffset: 0, randomToss: true),
                    new TimedTransition(950, "Main")
                    )

                ))

            .Init("shtrs Ice Adept",
            new State(

                new State("dormant",
                    new HpLessTransition(0.99, "Main"),
                    new Follow(.8, acquireRange: 9, range: 1),
                    new Shoot(9, 3, projectileIndex: 0, coolDown: 100, predictive: 1)
                ),

                new State("Main",
                    new TimedTransition(9500, "prethrow"),
                    new Follow(.8, acquireRange: 9, range: 1),
                    new Shoot(9, 3, projectileIndex: 0, coolDown: 100, predictive: 1),
                    new Shoot(9, count: 10, projectileIndex: 1, coolDown: 4000)
                ),

                new State("prethrow",
                    new Flash(0xfFF0000, .5, 3),
                    new TimedTransition(500, "Throw")
                ),

                new State("Throw",
                    new TossObject("shtrs Ice Portal", 10, coolDown: 8000, coolDownOffset: 900, randomToss: false),
                    new TimedTransition(1000, "Main")
                )
                  ),
            new ItemLoot("Magic Potion", 0.1),
            new ItemLoot("Health Potion", 0.1),
            new ItemLoot("The Forgotten Ring", 0.001)
            )

            .Init("shtrs MagiGenerators",
            new State(
                new State("Main",
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                    new Shoot(15, 10, coolDown: 1000),
                    new Shoot(15, 1, projectileIndex: 1, coolDown: 2500)
                ),
                new State("Hide",
                    new SetAltTexture(1),
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable)
                    ),
                new State("Despawn",
                    new Decay()
                    )
                  ))

        .Init("shtrs Abandoned Switch 1",
            new State(
                    new State("Idle",
                        new Taunt("I'm alive")
                        )))

        .Init("shtrs Abandoned Switch 2",
            new State(
                    new State("Idle",
                        new Taunt("I'm alive")
            )))
         .Init("shtrs Abandoned Switch 3",
            new State(
                    new State("Idle",
                        new Taunt("I'm alive")

            )))
        .Init("shtrs Abandoned Switch 4",
            new State(
                    new State("Idle",
                        new Taunt("I'm alive")

            )))

                .Init("shtrs Abandoned Switch 5",
            new State(
                    new State("Idle",
                        new Taunt("I'm alive")

            )))

        .Init("shtrs Bridge Obelisk A",
                new State(
                    new State("Idle",
                        new TimedTransition(2500, "Start")
                        ),
                        new State("Start",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new EntityNotExistsTransition("shtrs Abandoned Switch 1", 1000, "Wake1")
                    ),

                    new State("Wake1",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new EntityNotExistsTransition("shtrs Abandoned Switch 2", 1000, "Wake2")
                        ),

                    new State("Wake2",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new EntityNotExistsTransition("shtrs Abandoned Switch 3", 1000, "Wake3")
                        ),

                    new State("Wake3",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new EntityNotExistsTransition("shtrs Abandoned Switch 4", 1000, "Wake4")
                        ),

                    new State("Wake4",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new EntityNotExistsTransition("shtrs Abandoned Switch 5", 20000, "Wake5")
                        ),

                    new State("Wake5",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(30000, "Wake")
                        ),

                    new State("Prewake",
                        new Flash(0xfFF0000, .5, 3),
                        new TimedTransition(500, "Wake")

                        ),

                    new State("Wake",
                        new Flash(0xfFF0000, .5, 3),
                        new Taunt("DON'T WAKE THE BRIDGE GUARDIAN!"),
                        new TimedTransition(10000, "Idle1"),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Shoot(15, 1, projectileIndex: 0, fixedAngle: 0),
                        new Shoot(15, 1, projectileIndex: 0, fixedAngle: 0, coolDownOffset: 200),
                        new Shoot(15, 1, projectileIndex: 0, fixedAngle: 0, coolDownOffset: 400),
                        new Shoot(15, 1, projectileIndex: 0, fixedAngle: 0, coolDownOffset: 600),
                        new Shoot(15, 1, projectileIndex: 0, fixedAngle: 0, coolDownOffset: 800),
                        new Shoot(15, 1, projectileIndex: 0, fixedAngle: 0, coolDownOffset: 1000),
                        new Shoot(15, 1, projectileIndex: 0, fixedAngle: 90),
                        new Shoot(15, 1, projectileIndex: 0, fixedAngle: 90, coolDownOffset: 200),
                        new Shoot(15, 1, projectileIndex: 0, fixedAngle: 90, coolDownOffset: 400),
                        new Shoot(15, 1, projectileIndex: 0, fixedAngle: 90, coolDownOffset: 600),
                        new Shoot(15, 1, projectileIndex: 0, fixedAngle: 90, coolDownOffset: 800),
                        new Shoot(15, 1, projectileIndex: 0, fixedAngle: 90, coolDownOffset: 1000)

                        ),
                    new State("Idle1",
                        new Flash(0xfFF0000, .5, 3),
                        new TimedTransition(9500, "Prewake")

                        )
                    ))

                .Init("shtrs Bridge Obelisk B",
                new State(
                    new State("Idle",
                        new TimedTransition(2500, "Start")
                        ),
                        new State("Start",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new EntityNotExistsTransition("shtrs Abandoned Switch 1", 1000, "Wake1")
                    ),

                    new State("Wake1",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new EntityNotExistsTransition("shtrs Abandoned Switch 2", 1000, "Wake2")
                        ),

                    new State("Wake2",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new EntityNotExistsTransition("shtrs Abandoned Switch 3", 1000, "Wake3")
                        ),

                    new State("Wake3",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new EntityNotExistsTransition("shtrs Abandoned Switch 4", 1000, "Wake4")
                        ),

                    new State("Wake4",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new EntityNotExistsTransition("shtrs Abandoned Switch 5", 20000, "Wake5")
                        ),

                    new State("Wake5",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(30000, "Wake")
                        ),

                    new State("Prewake",
                        new Flash(0xfFF0000, .5, 3),
                        new TimedTransition(500, "Wake")

                        ),

                    new State("Wake",
                        new Flash(0xfFF0000, .5, 3),
                        new Taunt("DON'T WAKE THE BRIDGE GUARDIAN!"),
                        new TimedTransition(10000, "Idle1"),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Shoot(15, 1, projectileIndex: 0, fixedAngle: 0),
                        new Shoot(15, 1, projectileIndex: 0, fixedAngle: 0, coolDownOffset: 200),
                        new Shoot(15, 1, projectileIndex: 0, fixedAngle: 0, coolDownOffset: 400),
                        new Shoot(15, 1, projectileIndex: 0, fixedAngle: 0, coolDownOffset: 600),
                        new Shoot(15, 1, projectileIndex: 0, fixedAngle: 0, coolDownOffset: 800),
                        new Shoot(15, 1, projectileIndex: 0, fixedAngle: 0, coolDownOffset: 1000),
                        new Shoot(15, 1, projectileIndex: 0, fixedAngle: 270),
                        new Shoot(15, 1, projectileIndex: 0, fixedAngle: 270, coolDownOffset: 200),
                        new Shoot(15, 1, projectileIndex: 0, fixedAngle: 270, coolDownOffset: 400),
                        new Shoot(15, 1, projectileIndex: 0, fixedAngle: 270, coolDownOffset: 600),
                        new Shoot(15, 1, projectileIndex: 0, fixedAngle: 270, coolDownOffset: 800),
                        new Shoot(15, 1, projectileIndex: 0, fixedAngle: 270, coolDownOffset: 1000)
                        ),
                    new State("Idle1",
                        new Flash(0xfFF0000, .5, 3),
                        new Spawn("shtrs Stone Mage", maxChildren: 1, coolDown: 9400),
                        new Spawn("shtrs Stone Knight", maxChildren: 1, coolDown: 9400),
                        new TimedTransition(9500, "Prewake")

                        )
                    ))

        .Init("shtrs Bridge Obelisk C",
                new State(
                    new ConditionalEffect(ConditionEffectIndex.Armored),
                    new State("Idle",
                        new TimedTransition(2500, "Start")
                        ),
                        new State("Start",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new EntityNotExistsTransition("shtrs Abandoned Switch 1", 1000, "Wake1")
                    ),

                    new State("Wake1",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new EntityNotExistsTransition("shtrs Abandoned Switch 2", 1000, "Wake2")
                        ),

                    new State("Wake2",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new EntityNotExistsTransition("shtrs Abandoned Switch 3", 1000, "Wake3")
                        ),

                    new State("Wake3",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new EntityNotExistsTransition("shtrs Abandoned Switch 4", 1000, "Wake4")
                        ),

                    new State("Wake4",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new EntityNotExistsTransition("shtrs Abandoned Switch 5", 20000, "Wake5")
                        ),

                    new State("Wake5",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(30000, "Wake")
                        ),

                    new State("Prewake",
                        new Flash(0xfFF0000, .5, 3),
                        new TimedTransition(500, "Wake")

                        ),

                    new State("Wake",
                        new Flash(0xfFF0000, .5, 3),
                        new Taunt("DON'T WAKE THE BRIDGE GUARDIAN!"),
                        new TimedTransition(10000, "Idle1"),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Shoot(15, 1, projectileIndex: 0, fixedAngle: 0),
                        new Shoot(15, 1, projectileIndex: 0, fixedAngle: 0, coolDownOffset: 200),
                        new Shoot(15, 1, projectileIndex: 0, fixedAngle: 0, coolDownOffset: 400),
                        new Shoot(15, 1, projectileIndex: 0, fixedAngle: 0, coolDownOffset: 600),
                        new Shoot(15, 1, projectileIndex: 0, fixedAngle: 0, coolDownOffset: 800),
                        new Shoot(15, 1, projectileIndex: 0, fixedAngle: 0, coolDownOffset: 1000),
                        new Shoot(15, 1, projectileIndex: 0, fixedAngle: 90),
                        new Shoot(15, 1, projectileIndex: 0, fixedAngle: 90, coolDownOffset: 200),
                        new Shoot(15, 1, projectileIndex: 0, fixedAngle: 90, coolDownOffset: 400),
                        new Shoot(15, 1, projectileIndex: 0, fixedAngle: 90, coolDownOffset: 600),
                        new Shoot(15, 1, projectileIndex: 0, fixedAngle: 90, coolDownOffset: 800),
                        new Shoot(15, 1, projectileIndex: 0, fixedAngle: 90, coolDownOffset: 1000)

                        ),
                    new State("Idle1",
                        new Flash(0xfFF0000, .5, 3),
                        new TimedTransition(9500, "Prewake")

                        )
                    ))

                .Init("shtrs Bridge Obelisk D",
                new State(
                    new State("Idle",
                        new TimedTransition(2500, "Start")
                        ),
                        new State("Start",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new EntityNotExistsTransition("shtrs Abandoned Switch 1", 1000, "Wake1")
                    ),

                    new State("Wake1",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new EntityNotExistsTransition("shtrs Abandoned Switch 2", 1000, "Wake2")
                        ),

                    new State("Wake2",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new EntityNotExistsTransition("shtrs Abandoned Switch 3", 1000, "Wake3")
                        ),

                    new State("Wake3",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new EntityNotExistsTransition("shtrs Abandoned Switch 4", 1000, "Wake4")
                        ),

                    new State("Wake4",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new EntityNotExistsTransition("shtrs Abandoned Switch 5", 20000, "Wake5")
                        ),

                    new State("Wake5",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(30000, "Wake")
                        ),

                    new State("Prewake",
                        new Flash(0xfFF0000, .5, 3),
                        new TimedTransition(500, "Wake")

                        ),

                    new State("Wake",
                        new Flash(0xfFF0000, .5, 3),
                        new Taunt("DON'T WAKE THE BRIDGE GUARDIAN!"),
                        new TimedTransition(10000, "Idle1"),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Shoot(15, 1, projectileIndex: 0, fixedAngle: 180),
                        new Shoot(15, 1, projectileIndex: 0, fixedAngle: 180, coolDownOffset: 200),
                        new Shoot(15, 1, projectileIndex: 0, fixedAngle: 180, coolDownOffset: 400),
                        new Shoot(15, 1, projectileIndex: 0, fixedAngle: 180, coolDownOffset: 600),
                        new Shoot(15, 1, projectileIndex: 0, fixedAngle: 180, coolDownOffset: 800),
                        new Shoot(15, 1, projectileIndex: 0, fixedAngle: 180, coolDownOffset: 1000),
                        new Shoot(15, 1, projectileIndex: 0, fixedAngle: 90),
                        new Shoot(15, 1, projectileIndex: 0, fixedAngle: 90, coolDownOffset: 200),
                        new Shoot(15, 1, projectileIndex: 0, fixedAngle: 90, coolDownOffset: 400),
                        new Shoot(15, 1, projectileIndex: 0, fixedAngle: 90, coolDownOffset: 600),
                        new Shoot(15, 1, projectileIndex: 0, fixedAngle: 90, coolDownOffset: 800),
                        new Shoot(15, 1, projectileIndex: 0, fixedAngle: 90, coolDownOffset: 1000)

                        ),
                    new State("Idle1",
                        new Flash(0xfFF0000, .5, 3),
                        new TimedTransition(9500, "Prewake")

                        )
                    ))

                .Init("shtrs Bridge Obelisk E",
                new State(
                    new State("Idle",
                        new TimedTransition(2500, "Start")
                        ),
                        new State("Start",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new EntityNotExistsTransition("shtrs Abandoned Switch 1", 1000, "Wake1")
                    ),

                    new State("Wake1",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new EntityNotExistsTransition("shtrs Abandoned Switch 2", 1000, "Wake2")
                        ),

                    new State("Wake2",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new EntityNotExistsTransition("shtrs Abandoned Switch 3", 1000, "Wake3")
                        ),

                    new State("Wake3",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new EntityNotExistsTransition("shtrs Abandoned Switch 4", 1000, "Wake4")
                        ),

                    new State("Wake4",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new EntityNotExistsTransition("shtrs Abandoned Switch 5", 20000, "Wake5")
                        ),

                    new State("Wake5",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(30000, "Wake")
                        ),

                    new State("Prewake",
                        new Flash(0xfFF0000, .5, 3),
                        new TimedTransition(500, "Wake")

                        ),

                    new State("Wake",
                        new Flash(0xfFF0000, .5, 3),
                        new Taunt("DON'T WAKE THE BRIDGE GUARDIAN!"),
                        new TimedTransition(10000, "Idle1"),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Shoot(15, 1, projectileIndex: 0, fixedAngle: 180),
                        new Shoot(15, 1, projectileIndex: 0, fixedAngle: 180, coolDownOffset: 200),
                        new Shoot(15, 1, projectileIndex: 0, fixedAngle: 180, coolDownOffset: 400),
                        new Shoot(15, 1, projectileIndex: 0, fixedAngle: 180, coolDownOffset: 600),
                        new Shoot(15, 1, projectileIndex: 0, fixedAngle: 180, coolDownOffset: 800),
                        new Shoot(15, 1, projectileIndex: 0, fixedAngle: 180, coolDownOffset: 1000),
                        new Shoot(15, 1, projectileIndex: 0, fixedAngle: 270),
                        new Shoot(15, 1, projectileIndex: 0, fixedAngle: 270, coolDownOffset: 200),
                        new Shoot(15, 1, projectileIndex: 0, fixedAngle: 270, coolDownOffset: 400),
                        new Shoot(15, 1, projectileIndex: 0, fixedAngle: 270, coolDownOffset: 600),
                        new Shoot(15, 1, projectileIndex: 0, fixedAngle: 270, coolDownOffset: 800),
                        new Shoot(15, 1, projectileIndex: 0, fixedAngle: 270, coolDownOffset: 1000)

                        ),
                    new State("Idle1",
                        new Flash(0xfFF0000, .5, 3),
                        new Spawn("shtrs Stone Mage", maxChildren: 1, coolDown: 9400),
                        new Spawn("shtrs Stone Knight", maxChildren: 1, coolDown: 9400),
                        new TimedTransition(9500, "Prewake")

                        )
                    ))

                        .Init("shtrs Bridge Obelisk F",
                new State(
                    new ConditionalEffect(ConditionEffectIndex.Armored),
                    new State("Idle",
                        new TimedTransition(2500, "Start")
                        ),
                        new State("Start",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new EntityNotExistsTransition("shtrs Abandoned Switch 1", 1000, "Wake1")
                    ),

                    new State("Wake1",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new EntityNotExistsTransition("shtrs Abandoned Switch 2", 1000, "Wake2")
                        ),

                    new State("Wake2",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new EntityNotExistsTransition("shtrs Abandoned Switch 3", 1000, "Wake3")
                        ),

                    new State("Wake3",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new EntityNotExistsTransition("shtrs Abandoned Switch 4", 1000, "Wake4")
                        ),

                    new State("Wake4",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new EntityNotExistsTransition("shtrs Abandoned Switch 5", 20000, "Wake5")
                        ),

                    new State("Wake5",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(30000, "Wake")
                        ),

                    new State("Prewake",
                        new Flash(0xfFF0000, .5, 3),
                        new TimedTransition(500, "Wake")

                        ),

                    new State("Wake",
                        new Flash(0xfFF0000, .5, 3),
                        new TimedTransition(10000, "Idle1"),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt("DON'T WAKE THE BRIDGE GUARDIAN!"),
                        new Shoot(15, 1, projectileIndex: 0, fixedAngle: 180),
                        new Shoot(15, 1, projectileIndex: 0, fixedAngle: 180, coolDownOffset: 200),
                        new Shoot(15, 1, projectileIndex: 0, fixedAngle: 180, coolDownOffset: 400),
                        new Shoot(15, 1, projectileIndex: 0, fixedAngle: 180, coolDownOffset: 600),
                        new Shoot(15, 1, projectileIndex: 0, fixedAngle: 180, coolDownOffset: 800),
                        new Shoot(15, 1, projectileIndex: 0, fixedAngle: 180, coolDownOffset: 1000),
                        new Shoot(15, 1, projectileIndex: 0, fixedAngle: 90),
                        new Shoot(15, 1, projectileIndex: 0, fixedAngle: 90, coolDownOffset: 200),
                        new Shoot(15, 1, projectileIndex: 0, fixedAngle: 90, coolDownOffset: 400),
                        new Shoot(15, 1, projectileIndex: 0, fixedAngle: 90, coolDownOffset: 600),
                        new Shoot(15, 1, projectileIndex: 0, fixedAngle: 90, coolDownOffset: 800),
                        new Shoot(15, 1, projectileIndex: 0, fixedAngle: 90, coolDownOffset: 1000)
                        ),
                    new State("Idle1",
                        new Flash(0xfFF0000, .5, 3),
                        new Spawn("shtrs Stone Paladin", maxChildren: 1, coolDown: 9500),
                        new TimedTransition(9500, "Prewake")
                        )

                    ))

        .Init("shtrs Bridge Titanum",
                new State(
                    new NoPlayerWithinTransition(8, "Idle"),
                    new State("Idle",
                        new PlayerWithinTransition(8, "Start")
                        ),

                    new State("Idle1",
                        new TimedTransition(3000, "Start")
                        ),

                    new State("Start",
                        new TimedTransition(3100, "Idle1"),
                        new Spawn("shtrs Stone Mage", maxChildren: 1, coolDown: 3000),
                        new Spawn("shtrs Stone Knight", maxChildren: 1, coolDown: 3000)
                    )

                    ))

        .Init("shtrs Ice Shield",
            new State(
                new TimedTransition(15000, "Suicide"),
                    new State("Idle",
                        new TimedTransition(2500, "Spin")
                    ),
                    new State("Spin",
                        new TimedTransition(2000, "Pause"),
                        new State("Quadforce1",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 0, coolDown: 300),
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 40, fixedAngle: 0, coolDown: 300),
                            new TimedTransition(150, "Quadforce2")
                        ),
                        new State("Quadforce2",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 15, coolDown: 300),
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 40, fixedAngle: 15, coolDown: 300),
                            new TimedTransition(150, "Quadforce3")
                        ),
                        new State("Quadforce3",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 30, coolDown: 300),
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 40, fixedAngle: 30, coolDown: 300),
                            new TimedTransition(150, "Quadforce4")
                        ),
                        new State("Quadforce4",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 45, coolDown: 300),
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 40, fixedAngle: 45, coolDown: 300),
                            new TimedTransition(150, "Quadforce5")
                        ),
                        new State("Quadforce5",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 60, coolDown: 300),
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 40, fixedAngle: 45, coolDown: 300),
                            new TimedTransition(150, "Quadforce6")
                        ),
                        new State("Quadforce6",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 75, coolDown: 300),
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 40, fixedAngle: 45, coolDown: 300),
                            new TimedTransition(150, "Quadforce7")
                        ),
                        new State("Quadforce7",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 90, coolDown: 300),
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 40, fixedAngle: 45, coolDown: 300),
                            new TimedTransition(150, "Quadforce8")
                        ),
                        new State("Quadforce8",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 105, coolDown: 300),
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 40, fixedAngle: 45, coolDown: 300),
                            new TimedTransition(150, "Quadforce1")
                        )
                    ),
                    new State("Pause",
                       new TimedTransition(5000, "Spin")
                    ),
                    new State("Suicide",
                        new Shoot(25, count: 12, fixedAngle: 0, projectileIndex: 1, coolDown: 500),
                        new Suicide()
                                        )
                )
            )

            .Init("shtrs Ice Portal",
                new State(
                    new TimedTransition(15000, "Suicide"),
                    new State("Idle",
                        new TimedTransition(2500, "Spin")
                    ),
                    new State("Spin",
                        new TimedTransition(2000, "Pause"),
                        new State("Quadforce1",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 0, coolDown: 300),
                            new TimedTransition(150, "Quadforce2")
                        ),
                        new State("Quadforce2",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 15, coolDown: 300),
                            new TimedTransition(150, "Quadforce3")
                        ),
                        new State("Quadforce3",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 30, coolDown: 300),
                            new TimedTransition(150, "Quadforce4")
                        ),
                        new State("Quadforce4",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 45, coolDown: 300),
                            new TimedTransition(150, "Quadforce5")
                        ),
                        new State("Quadforce5",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 60, coolDown: 300),
                            new TimedTransition(150, "Quadforce6")
                        ),
                        new State("Quadforce6",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 75, coolDown: 300),
                            new TimedTransition(150, "Quadforce7")
                        ),
                        new State("Quadforce7",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 90, coolDown: 300),
                            new TimedTransition(150, "Quadforce8")
                        ),
                        new State("Quadforce8",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 105, coolDown: 300),
                            new TimedTransition(150, "Quadforce1")
                        )
                    ),
                    new State("Pause",
                       new TimedTransition(5000, "Spin")
                    ),
                    new State("Suicide",
                        new Suicide()
                                        )
                )
            )
            .Init("shtrs Fire Portal",
                new State(
                    new TimedTransition(15000, "Suicide"),
                    new State("Idle",
                        new TimedTransition(2500, "Spin")
                    ),
                    new State("Spin",
                        new TimedTransition(2000, "Pause"),
                        new State("Quadforce1",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 0, coolDown: 300),
                            new TimedTransition(150, "Quadforce2")
                        ),
                        new State("Quadforce2",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 15, coolDown: 300),
                            new TimedTransition(150, "Quadforce3")
                        ),
                        new State("Quadforce3",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 30, coolDown: 300),
                            new TimedTransition(150, "Quadforce4")
                        ),
                        new State("Quadforce4",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 45, coolDown: 300),
                            new TimedTransition(150, "Quadforce5")
                        ),
                        new State("Quadforce5",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 60, coolDown: 300),
                            new TimedTransition(150, "Quadforce6")
                        ),
                        new State("Quadforce6",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 75, coolDown: 300),
                            new TimedTransition(150, "Quadforce7")
                        ),
                        new State("Quadforce7",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 90, coolDown: 300),
                            new TimedTransition(150, "Quadforce8")
                        ),
                        new State("Quadforce8",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 105, coolDown: 300),
                            new TimedTransition(150, "Quadforce1")
                        )
                    ),
                    new State("Pause",
                       new TimedTransition(5000, "Spin")
                    ),
                    new State("Suicide",
                        new Suicide()
                                        )
                )
            )
            .Init("shtrs Bridge Sentinel",
                new State(
                    new SetLootState("obelisk"),
                    new CopyLootState("shtrs encounterchestspawner", 20),
                    new HpLessTransition(0.1, "Death"),
                    new CopyDamageOnDeath("shtrs Encounter Chest"),
                    new State("Idle",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new EntityNotExistsTransition("shtrs Bridge Obelisk A", 20000, "Idle1")
                    ),
                    new State("Idle1",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new EntityNotExistsTransition("shtrs Bridge Obelisk B", 20000, "Idle2")
                    ),
                    new State("Idle2",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new EntityNotExistsTransition("shtrs Bridge Obelisk D", 20000, "Idle3")
                    ),
                    new State("Idle3",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new EntityNotExistsTransition("shtrs Bridge Obelisk E", 1000, "Start")
                    ),
                    //not correct
                    //new State("Close Bridge",
                    //new CallWorldMethod("Shatters", "CloseBridge1", null),
                    //new TimedTransition(3500, "Start")
                    //),
                    //new State("Start the Start",
                    //    new Order(10, "shtrs Bridge Obelisk A", "Talk"),
                    //    new Order(10, "shtrs Bridge Obelisk B", "Talk"),
                    //    new Order(10, "shtrs Bridge Obelisk C", "Talk"),
                    //    new Order(10, "shtrs Bridge Obelisk D", "Talk")
                    //),
                    new State("Start",
                        new Shoot(15, 10, 15, 5, 270, coolDown: 1000),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new EntityNotExistsTransition("shtrs Bridge Obelisk E", 10, "Wake")
                        ),
                        new State("Wake",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt("Who has woken me...? Leave this place."),
                        new Shoot(15, 10, 15, 5, 270, coolDown: 1000),
                        new Timed(2100, new Shoot(15, 15, 12, projectileIndex: 0, fixedAngle: 90, coolDown: 700, coolDownOffset: 3000)),
                         new TimedTransition(8000, "taunt2")
                        ),
                        new State("taunt2",
                            new Taunt("Good pests must be gone."),
                            new Shoot(15, 10, 15, 5, 270, coolDown: 1000),
                            new HpLessTransition(0.93, "Blobomb")
                            ),

                        new State("Swirl Shot",
                            new Shoot(15, 10, 15, 5, 270, coolDown: 1000),
                            new Taunt("Go."),
                            new TimedTransition(10400, "Blobomb"),
                                new State("Swirl1_1",
                            new TimedTransition(1000, "Swirl1_9"),
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 0),
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 12, coolDownOffset: 200),
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 24, coolDownOffset: 400),
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 36, coolDownOffset: 600),
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 48, coolDownOffset: 800),
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 60, coolDownOffset: 1000)
                            ),
                                new State("Swirl1_9",
                            new TimedTransition(1000, "Swirl1_3"),
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 72, coolDownOffset: 0),
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 84, coolDownOffset: 200),
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 96, coolDownOffset: 400),
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 108, coolDownOffset: 600),
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 120, coolDownOffset: 800),
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 132, coolDownOffset: 1000)
                                    ),
                                new State("Swirl1_3",
                            new TimedTransition(1000, "Swirl1_4"),
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 144, coolDownOffset: 0),
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 156, coolDownOffset: 200),
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 168, coolDownOffset: 400),
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 180, coolDownOffset: 600),
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 180, coolDownOffset: 800),
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 168, coolDownOffset: 1000)
                                    ),
                                new State("Swirl1_4",
                            new TimedTransition(1000, "Swirl1_5"),
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 156, coolDownOffset: 0),
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 144, coolDownOffset: 200),
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 132, coolDownOffset: 400),
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 120, coolDownOffset: 600),
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 108, coolDownOffset: 800),
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 96, coolDownOffset: 1000)
                            ),
                                new State("Swirl1_5",
                            new TimedTransition(1000, "Swirl1_6"),
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 84, coolDownOffset: 0),
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 72, coolDownOffset: 200),
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 60, coolDownOffset: 400),
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 48, coolDownOffset: 600),
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 36, coolDownOffset: 800),
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 24, coolDownOffset: 1000)
                            ),
                                new State("Swirl1_6",
                            new TimedTransition(200, "Swirl1_1"),
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 12, coolDownOffset: 0),
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 0, coolDownOffset: 200)
                            )
                            

                            ),
                            new State("Blobomb",
                            new Taunt("You live still? DO NOT TEMPT FATE!"),
                            new Taunt("CONSUME!"),
                            new Order(20, "shtrs blobomb maker", "Spawn"),
                            new HpLessTransition(.30, "SwirlAndShoot")
                            //new EntityNotExistsTransition("shtrs Blobomb", 30, "SwirlAndShoot")
                                ),
                                new State("SwirlAndShoot",
                                    new Taunt("FOOLS! YOU DO NOT UNDERSTAND!"),
                                    new ChangeSize(20, 150),
                                    new Shoot(15, 10, 15, 5, 270, coolDown: 1000),
                            new Shoot(15, 15, 11, projectileIndex: 0, fixedAngle: 90, coolDown: 700, coolDownOffset: 700),
                                new State("Swirl2_1",
                            new TimedTransition(1000, "Swirl2_9"),
                            new Order(20, "shtrs blobomb maker", "AVATAR HELP!"),
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 0),
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 12, coolDownOffset: 200),
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 24, coolDownOffset: 400),
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 36, coolDownOffset: 600),
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 48, coolDownOffset: 800),
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 60, coolDownOffset: 1000)
                            ),
                                new State("Swirl2_9",
                            new TimedTransition(1000, "Swirl2_3"),
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 72, coolDownOffset: 0),
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 84, coolDownOffset: 200),
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 96, coolDownOffset: 400),
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 108, coolDownOffset: 600),
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 120, coolDownOffset: 800),
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 132, coolDownOffset: 1000)
                                    ),
                                new State("Swirl2_3",
                            new TimedTransition(1000, "Swirl2_4"),
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 144, coolDownOffset: 0),
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 156, coolDownOffset: 200),
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 168, coolDownOffset: 400),
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 180, coolDownOffset: 600),
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 180, coolDownOffset: 800),
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 168, coolDownOffset: 1000)
                                    ),
                                new State("Swirl2_4",
                            new TimedTransition(1000, "Swirl2_5"),
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 156, coolDownOffset: 0),
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 144, coolDownOffset: 200),
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 132, coolDownOffset: 400),
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 120, coolDownOffset: 600),
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 108, coolDownOffset: 800),
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 96, coolDownOffset: 1000)
                            ),
                                new State("Swirl2_5",
                            new TimedTransition(1000, "Swirl2_6"),
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 84, coolDownOffset: 0),
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 72, coolDownOffset: 200),
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 60, coolDownOffset: 400),
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 48, coolDownOffset: 600),
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 36, coolDownOffset: 800),
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 24, coolDownOffset: 1000)
                            ),
                                new State("Swirl2_6",
                            new TimedTransition(200, "Swirl2_1"),
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 12, coolDownOffset: 0),
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 0, coolDownOffset: 200)
                            )
                                    ),
                                    new State("Death",
                                        new CallWorldMethod("Shatters", "OpenBridge1Behind"),
                                        new ChangeSize(20, 130),
                                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                                        new Taunt("I tried to protect you...I have failed. You release a great evil upon this realm..."),
                                        new Shoot(15, 12, projectileIndex: 0, coolDown: 100000, coolDownOffset: 3000),
                                        new TimedTransition(4000, "Suicide")
                                        ),
                                    new State("Suicide",
                                        new CopyDamageOnDeath("shtrs Encounter Chest"),
                                        new Order(10, "shtrs encounterchestspawner", "Spawn"),
                                        new Suicide()
                                        )
                        )
            )

            .Init("shtrs Twilight Archmage",
                new State(
                    new SetLootState("archmage"),
                    new CopyLootState("shtrs encounterchestspawner", 20),
                    new HpLessTransition(.1, "Death"),
                    new State("Idle",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new EntityNotExistsTransition2("shtrs Glassier Archmage", "shtrs Archmage of Flame", 15, "Wake")
                    ),
                    new State("Wake",
                        new State("Comment1",
                            new SetAltTexture(1),
                            new Taunt("Ha...ha........hahahahahaha! You will make a fine sacrifice!"),
                            new TimedTransition(3000, "Comment2")
                        ),
                        new SetAltTexture(1),
                        new State("Comment2",
                            new Taunt("You will find that it was...unwise...to wake me."),
                            new TimedTransition(1000, "Comment3")
                        ),
                        new State("Comment3",
                            new SetAltTexture(1),
                            new Taunt("Let us see what can conjure up!"),
                            new TimedTransition(1000, "Comment4")
                        ),
                        new State("Comment4",
                            new SetAltTexture(1),
                            new Taunt("I will freeze the life from you!"),
                            new TimedTransition(1000, "Blue1")
                        )
                    ),
                    new State("Blue1",
                        new SetAltTexture(2),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TossObject("shtrs Ice Portal", 4, 90, 100000000),
                        new Spawn("shtrs Ice Shield", 1, 1, 1000000000),
                        new TimedTransition(2000, "checkSphere")
                    ),
                    new State("checkSphere",
                        new EntityNotExistsTransition("shtrs Ice Shield", 15, "Spawn Birds")
                    ),
                    new State("Spawn Birds",
                        new Taunt("You leave me no choice...Inferno! Blizzard!"),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new InvisiToss("shtrs Inferno", 3, 0, 1000000000, 7000),
                        new InvisiToss("shtrs Blizzard", 3, 180, 1000000000, 7000),
                        new Order(15, "shtrs MagiGenerators", "Hide"),
                        new TimedTransition(8000, "wait")
                    ),
                    new State("wait",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new EntityNotExistsTransition2("shtrs Inferno", "shtrs Blizzard", 15, "Change")
                    ),
                    new State("Change",
                        new SetAltTexture(2),
                        new ChangeSize(100, 200),
                        new Taunt("Your souls feed my King."),
                        new TimedTransition(3000, "Active 1")
                    ),
                    new State("Active 1",
                        new Taunt("Darkness give me strength!"),
                        new MoveTo(6, 0),
                        new Order(1, "shtrs MagiGenerators", "Despawn"),
                        new TimedTransition(4000, "Active2")
                    ),
                    new State("Active2",
                        new MoveTo(0, 4, 1.5),
                        new Order(1, "shtrs MagiGenerators", "Despawn"),
                        new Taunt("THE POWER...IT CONSUMES ME!"),
                        new Shoot(15, 20, projectileIndex:2, coolDown:100000000, coolDownOffset:5000),
                        new Shoot(15, 20, projectileIndex: 3, coolDown: 100000000, coolDownOffset: 5000),
                        new Shoot(15, 20, projectileIndex: 4, coolDown: 100000000, coolDownOffset: 5100),
                        new Shoot(15, 20, projectileIndex: 2, coolDown: 100000000, coolDownOffset: 5200),
                        new Shoot(15, 20, projectileIndex: 5, coolDown: 100000000, coolDownOffset: 5350),
                        new Shoot(15, 20, projectileIndex: 6, coolDown: 100000000, coolDownOffset: 5400),
                        new TimedTransition(6000, "Active3")
                    ),
                    new State("Active3",
                        new MoveTo(8, 0, 1.5),
                        new Order(1, "shtrs MagiGenerators", "Despawn"),
                        new Taunt("THE POWER...IT CONSUMES ME!"),
                        new Shoot(15, 20, projectileIndex: 2, coolDown: 100000000, coolDownOffset: 5000),
                        new Shoot(15, 20, projectileIndex: 3, coolDown: 100000000, coolDownOffset: 5000),
                        new Shoot(15, 20, projectileIndex: 4, coolDown: 100000000, coolDownOffset: 5100),
                        new Shoot(15, 20, projectileIndex: 2, coolDown: 100000000, coolDownOffset: 5200),
                        new Shoot(15, 20, projectileIndex: 5, coolDown: 100000000, coolDownOffset: 5350),
                        new Shoot(15, 20, projectileIndex: 6, coolDown: 100000000, coolDownOffset: 5400)
                    ),
                    new State("Death",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt("I...will........retuuurr...n...n....."),
                        new Shoot(15, 12, projectileIndex:5, coolDown:1000000, coolDownOffset:30000),
                        new CopyDamageOnDeath("shtrs Encounter Chest"),
                        new Order(10, "shtrs encounterchestspawner", "Spawn"),
                        new Suicide()
                    )
                )
            )
            .Init("shtrs The Forgotten King",
                new State(
                    new SetLootState("forgottenKing"),
                    new CopyLootState("shtrs encounterchestspawner", 20),

                    new State("Idle",
                        new HpLessTransition(0.1, "Death")
                    ),

                    new State("Death",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new CopyDamageOnDeath("shtrs Encounter Chest"),
                        new Order(10, "shtrs encounterchestspawner", "Spawn"),
                        new Suicide()
                    )
                )
            )
            .Init("shtrs blobomb maker",
                new State(
                    new State("Idle",
                        new ConditionalEffect(ConditionEffectIndex.Invincible)
                    ),
                    new State("Spawn",
                        new Spawn("shtrs Blobomb", coolDown: 1000),
                        new TimedTransition(6000, "Idle")
                     ),
                    new State("blobombs avatar",
                        new Spawn("shtrs Blobomb", maxChildren: 1, coolDown: 2000)
                        ),
                    new State("AVATAR HELP!",
                        new Spawn("shtrs Blobomb", maxChildren: 1, coolDown: 2000),
                        new TimedTransition(2000, "Idle")
                    )
                )
            )
            .Init("shtrs encounterchestspawner",
                new State(
                    new State("Idle",
                        new ConditionalEffect(ConditionEffectIndex.Invincible, true)
                    ),
                    new State("Spawn",
                        new Spawn("shtrs Encounter Chest", 1, 1),
                        new CopyLootState("shtrs Encounter Chest", 10),
                        new TimedTransition(5000, "Idle")
                    )
                )
            )

            .Init("shtrs Encounter Chest",
                new State(
                    new State("Idle",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(5000, "Bracer")
                    ),
                    new State("Bracer")
                ),
                new Threshold(0.1,
                    new TierLoot(11, ItemType.Weapon, 0.15),
                    new TierLoot(12, ItemType.Weapon, 0.1),
                    new TierLoot(6, ItemType.Ability, 0.1),
                    new TierLoot(12, ItemType.Armor, 0.15),
                    new TierLoot(13, ItemType.Armor, 0.1),
                    new TierLoot(6, ItemType.Ring, 0.1)
                ),
                new LootState("obelisk",
                    new Threshold(0.32,
                        new ItemLoot("Potion of Mana", 1),
                        new ItemLoot("Potion of Life", 0.5)
                    ),
                    new Threshold(0.1,
                        new ItemLoot("Bracer of the Guardian", 0.009)
                    )
                ),
                new LootState("archmage",
                    new Threshold(0.32,
                        new ItemLoot("Potion of Mana", 1)
                    ),
                    new Threshold(0.1,
                        new ItemLoot("The Twilight Gemstone", 0.005)
                    )
                ),
                new LootState("forgottenKing",
                    new Threshold(0.32,
                        new ItemLoot("Potion of Life", 1)
                    ),
                    new Threshold(0.1,
                        new ItemLoot("The Forgotten Crown", 0.005)
                    )
                )
            )
            
            .Init("shtrs Inferno",
                new State(
                    new Follow(1, range: 1, coolDown: 1000),
                    new Orbit(1, 4, 15, "shtrs Blizzard")
                )
            )

            .Init("shtrs Blizzard",
                new State(
                    new Follow(1, range: 1, coolDown: 1000),
                    new Orbit(1, 4, 15, "shtrs Inferno")
                )
            );
    }
}
