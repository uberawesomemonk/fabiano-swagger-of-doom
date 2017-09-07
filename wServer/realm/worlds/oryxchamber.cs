namespace wServer.realm.worlds
{
    public class OryxsChamber : World
    {
        public OryxsChamber()
        {
            Name = "Oryx's Chamber Portal";
            ClientWorldName = "Oryx's Chamber";
            Dungeon = true;
            Background = 0;
            AllowTeleport = false;
            Difficulty = 5;
        }

        protected override void Init()
        {
            LoadMap("wServer.realm.worlds.maps.OryxsChamber.wmap", MapType.Wmap);
        }
    }
}
