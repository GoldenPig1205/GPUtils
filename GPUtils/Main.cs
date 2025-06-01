using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.API.Features;
using GPUtils.Features.PaintToText.Core;
using MEC;

namespace GPUtils
{
    public class Main : Plugin<Config>
    {
        public override string Name => "GPUtils";
        public override string Author => "GoldenPig1205";
        public override Version Version => new Version(1, 0, 0);
        public override Version RequiredExiledVersion => new Version(1, 2, 0, 5);

        public static Main Instance { get; private set; }

        public override void OnEnabled()
        {
            Instance = this;
            base.OnEnabled();

            string imagesDir = Paths.Configs + "/Plugins/g_p_utils/Images";
            if (!Directory.Exists(imagesDir))
                Directory.CreateDirectory(imagesDir);

            string videosDir = Paths.Configs + "/Plugins/g_p_utils/Videos";
            if (!Directory.Exists(videosDir))
                Directory.CreateDirectory(videosDir);
        }
        public override void OnDisabled()
        {


            base.OnDisabled();
            Instance = null;
        }
    }
}
