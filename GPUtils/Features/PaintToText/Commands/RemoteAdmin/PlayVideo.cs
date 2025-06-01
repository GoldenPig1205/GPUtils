using CommandSystem;
using Exiled.API.Features;
using GPUtils.Features.PaintToText.Core;
using MEC;
using Mirror;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Video;

namespace GPUtils.Features.PaintToText.Commands.RemoteAdmin
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class PlayPaint : ICommand
    {
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player player = Player.Get(sender);
            string text = string.Join(" ", arguments);

            Timing.RunCoroutine(PaintToTextMain.PlayVideo(text.Split('_')[0], player.Position, player.Rotation * Quaternion.Euler(0, 180, 0)));

            response = "Successfully executed PlayVideo command.";
            return true;
        }

        public string Command { get; } = "playvideo";

        public string[] Aliases { get; } = { "pv" };

        public string Description { get; } = "Play Video.";

        public bool SanitizeResponse { get; } = true;
    }
}
