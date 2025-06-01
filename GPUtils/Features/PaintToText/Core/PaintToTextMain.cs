using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using MEC;

namespace GPUtils.Features.PaintToText.Core
{
    public class PaintToTextMain
    {
        public static LabApi.Features.Wrappers.TextToy CreateText(Vector3 pos, Quaternion rot, string text, float time = 20)
        {
            LabApi.Features.Wrappers.TextToy textToy = LabApi.Features.Wrappers.TextToy.Create();
            textToy.Position = pos;
            textToy.Rotation = rot;
            textToy.DisplaySize = new Vector2(100000, 100000);
            textToy.TextFormat = text;

            Timing.CallDelayed(time, textToy.Destroy);

            return textToy;
        }
    }
}
