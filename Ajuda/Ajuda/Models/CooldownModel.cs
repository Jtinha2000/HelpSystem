using Steamworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajuda.Models
{
    public class CooldownModel
    {
        public int Cooldown { get; set; }
        public Steamworks.CSteamID ID { get; set; }

        public CooldownModel(int cooldown, CSteamID iD)
        {
            Cooldown = cooldown;
            ID = iD;
        }

        public CooldownModel()
        {
        }
    }
}
