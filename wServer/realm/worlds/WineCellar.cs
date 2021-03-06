﻿namespace wServer.realm.worlds
{
    public class WineCellar : World
    {
        public WineCellar()
        {
            Name = "Wine Cellar";
            ClientWorldName = "Wine Cellar";
            Dungeon = true;
            Background = 0;
            AllowTeleport = false;
            Difficulty = 5;
        }

        protected override void Init()
        {
            LoadMap("wServer.realm.worlds.maps.winecellar.jm", MapType.Json);
        }
    }
}