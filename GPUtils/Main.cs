using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.API.Features;

namespace GPUtils
{
    public class Main : Plugin<Config>
    {
        public override string Name => "GPUtils";
        public override string Author => "GoldenPig1205";
        public override Version Version => new Version(1, 0, 0);
        public override Version RequiredExiledVersion => new Version(12, 0, 5);

        public static Main Instance { get; private set; }

        public override void OnEnabled()
        {
            Instance = this;
            base.OnEnabled();


        }
        public override void OnDisabled()
        {


            base.OnDisabled();
            Instance = null;
        }
    }
}
