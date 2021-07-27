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
    class FinalizarAjudaComando : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => "FAjuda";

        public string Help => Plugin.Instance.Translate("AjudaFinalizationHelp");

        public string Syntax => "/FHelp";

        public List<string> Aliases => new List<string> { "FHelp", "FAjuda" };

        public List<string> Permissions => new List<string> { "HelpSystem.Admin" };

        public void Execute(IRocketPlayer caller, string[] command)
        {
            if (command.Length == 0)
            {
                UnturnedChat.Say(caller, Plugin.Instance.Translate("AjudaFinalizationLenght"));
                return;
            }
            try
            {
                int ab = Plugin.Instance.Helps.FindIndex(X => X.ID == int.Parse(command[0]));
                Plugin.Instance.Cooldown.RemoveAll(x => x.ID == Plugin.Instance.Helps[ab].Jogador.CSteamID);
                UnturnedChat.Say(Plugin.Instance.Helps[ab].Jogador, Plugin.Instance.Translate("AjudaFinalizationPlayerRemoved"));
                Plugin.Instance.Helps.RemoveAt(ab);
                UnturnedChat.Say(caller, Plugin.Instance.Translate("AjudaFinalizationAdminRemoved"));
            }
            catch (Exception)
            {
                UnturnedChat.Say(caller, Plugin.Instance.Translate("AjudaFinalizationNotFind"));
            }
        }
    }
}
