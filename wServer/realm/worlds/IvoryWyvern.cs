using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wServer.networking;

namespace wServer.realm.worlds
{
    public class IvoryWyvern : World
    {
        public IvoryWyvern()
        {
            Name = "Ivory Wyvern Portal";
            ClientWorldName = "Ivory Wyvern";
            Background = 0;
            AllowTeleport = false;
            Difficulty = 5;
        }

        protected override void Init()
        {
            LoadMap("wServer.realm.worlds.maps.IvoryWyvern.wmap", MapType.Wmap);
        }

        public override World GetInstance(Client client)
        {
            return Manager.AddWorld(new IvoryWyvern());
        }
    }
}