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

namespace Ajuda.Commands
{
    class AjudaComando : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => "Ajuda";

        public string Help => Plugin.Instance.Translate("AjudaHelp");

        public string Syntax => "/Help <Topic> <Explanation>";

        public List<string> Aliases => new List<string> { "Help", "Ajuda"};

        public List<string> Permissions => new List<string>();

        public void Execute(IRocketPlayer caller, string[] command)
        {
            if(command.Length < 2)
            {
                UnturnedChat.Say(caller,Plugin.Instance.Translate("AjudaLenghtError"));
                return;
            }
            else if(Plugin.Instance.Helps.Exists(x => x.Explicação == command[1]))
           {
                UnturnedChat.Say(caller, Plugin.Instance.Translate("AjudaRepeated"));
                return;
            }
            UnturnedPlayer unturnedPlayer = UnturnedPlayer.FromName(caller.DisplayName);
            if (Plugin.Instance.Cooldown.Exists(x => x.ID == unturnedPlayer.CSteamID))
            {
                UnturnedChat.Say(caller, Plugin.Instance.Translate("AjudaCooldown"));
                return;
            }
                System.Random util = new System.Random();
            int p = 1;
            int a = 0;
            while (p == 1)
            {
                a = util.Next(0, 10000);
                if (Plugin.Instance.Helps != null && Plugin.Instance.Helps.Exists(x => x.ID == a))
                {
                    p = 1;
                }
                else
                {
                    p = 0;
                }
            }
            Plugin.Instance.Helps.Add(new Models.HelpSystem(unturnedPlayer, command[0], command[1], a));
            Plugin.Instance.Cooldown.Add(new Models.CooldownModel(Plugin.Instance.Configuration.Instance.Cooldown, unturnedPlayer.CSteamID));
            Plugin.Instance.StartNumerator(unturnedPlayer);
            UnturnedChat.Say(caller, Plugin.Instance.Translate("AjudaPlayerSucess"));
            foreach(var qwa in Plugin.Instance.Alp)
            {
                UnturnedChat.Say(qwa.Value, Plugin.Instance.Translate("AjudaAdminSucess"));
            }
        }
    }
}
