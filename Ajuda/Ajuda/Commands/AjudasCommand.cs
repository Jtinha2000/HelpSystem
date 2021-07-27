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
using Ajuda.Models;

namespace Ajuda.Commands
    {
        class AjudasComando : IRocketCommand
        {
            public AllowedCaller AllowedCaller => AllowedCaller.Player;

            public string Name => "Ajudas";

            public string Help => Plugin.Instance.Translate("AjudaHelps");

            public string Syntax => "/Helps";

            public List<string> Aliases => new List<string> { "Helps", "Ajudas" };

            public List<string> Permissions => new List<string> { "HelpSystem.Admin"};

            public void Execute(IRocketPlayer caller, string[] command)
            {
            UnturnedChat.Say(caller, "Pedidos de ajuda:");
                foreach (HelpSystem a in Plugin.Instance.Helps)
            {
                UnturnedChat.Say(caller, a.Jogador + " | " + a.Motivo + " | " + a.ID);
            }
        }
        }
    }
