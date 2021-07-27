using Rocket.Core.Plugins;
using Rocket.Unturned;
using Rocket.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocket.Core.Logging;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using SDG.Provider;
using SDG.Framework;
using Rocket.Core;
using SDG.Unturned;
using Rocket.API.Collections;
using Rocket.Unturned.Events;
using System.Collections;
using UnityEngine;

namespace Ajuda.Models
{
    public class HelpSystem
    {
        public UnturnedPlayer Jogador { get; set; }
        public string Motivo { get; set; }
        public int ID{ get; set; }
        public string Explicação { get; set; }

        public HelpSystem(UnturnedPlayer jogador, string motivo, string explicação, int Id)
        {
            Jogador = jogador;
            Motivo = motivo;
            Explicação = explicação;
            ID = Id;
        }

        public HelpSystem()
        {
        }
    }
}
