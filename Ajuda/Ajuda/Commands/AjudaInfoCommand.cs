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
    class AjudaInfoCommand : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => "AjudaInfo";

        public string Help => Plugin.Instance.Translate("AjudaInfoHelp");

        public string Syntax => "/HelpInfo <ID>";

        public List<string> Aliases => new List<string> { "HelpI", "AjudaI", "HelpInfo", "AjudaInfo" };

        public List<string> Permissions => new List<string> { "HelpSystem.Admin" };

        public void Execute(IRocketPlayer caller, string[] command)
        {
            if (command.Length == 0)
            {
                UnturnedChat.Say(caller, Plugin.Instance.Translate("AjudaInfoLenght"));
                return;
            }
            try
            {
                int ab = Plugin.Instance.Helps.FindIndex(X => X.ID == int.Parse(command[0]));
                UnturnedChat.Say(caller, Plugin.Instance.Translate("AjudaInfoFormat", Plugin.Instance.Helps[ab].Jogador.DisplayName, Plugin.Instance.Helps[ab].Motivo, Plugin.Instance.Helps[ab].Explicação));
            }
            catch (Exception)
            {
                UnturnedChat.Say(caller, Plugin.Instance.Translate("AjudaInfoNotFind"));
            }
        }
    }
}
