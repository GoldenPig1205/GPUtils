using CommandSystem;
using Exiled.API.Features;
using GPUtils.Features.PaintToText.Core;
using Mirror;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace GPUtils.Features.PaintToText.Commands.RemoteAdmin
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class ShowText : ICommand
    {
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player player = Player.Get(sender);
            string text = string.Join(" ", arguments);

            PaintToTextMain.CreateText(player.Position, player.Rotation * Quaternion.Euler(0, 180, 0), $"{text.Split('_')[0]}", float.Parse(text.Split('_')[1]));

            response = "Successfully executed ShowText command.";
            return true;
        }

        public string Command { get; } = "showtext";

        public string[] Aliases { get; } = { "text", "텍스트" };

        public string Description { get; } = "Show text.";

        public bool SanitizeResponse { get; } = true;
    }
}
