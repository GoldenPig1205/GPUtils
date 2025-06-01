using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using UnityEngine;
using MEC;
using System.IO;
using Exiled.API.Features;
using UnityEngine.Video;

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

        public static string ConvertImageToRichText(string imagePath)
        {
            if (!File.Exists(imagePath))
                throw new FileNotFoundException("이미지 파일을 찾을 수 없습니다.", imagePath);

            using (var bmp = new Bitmap(imagePath))
            {
                int maxWidth = 50;
                int maxHeight = 50;
                int newWidth = bmp.Width > maxWidth ? maxWidth : bmp.Width;
                int newHeight = bmp.Height > maxHeight ? maxHeight : bmp.Height;

                using (var resizedBmp = new Bitmap(bmp, new Size(newWidth, newHeight)))
                {
                    var sb = new StringBuilder();

                    for (int y = 0; y < resizedBmp.Height; y++)
                    {
                        for (int x = 0; x < resizedBmp.Width; x++)
                        {
                            System.Drawing.Color pixel = resizedBmp.GetPixel(x, y);
                            if (pixel.A < 25)
                            {
                                sb.Append(" ");
                                continue;
                            }
                            UnityEngine.Color unityColor = new UnityEngine.Color(pixel.R / 255f, pixel.G / 255f, pixel.B / 255f, pixel.A / 255f);
                            string hex = ColorUtility.ToHtmlStringRGB(unityColor);
                            sb.Append($"<color=#{hex}>█</color>");
                        }
                        sb.Append("\n");
                    }

                    //string txtPath = Path.ChangeExtension(imagePath, ".txt");
                    //File.WriteAllText(txtPath, sb.ToString(), Encoding.UTF8);

                    return sb.ToString();
                }
            }
        }

        public static IEnumerator<float> PlayVideo(string videoName, Vector3 pos, Quaternion rot)
        {
            string videosDir = Paths.Configs + "/Plugins/g_p_utils/Videos";
            string videoPath = videosDir + $"/{videoName}";

            var files = Directory.GetFiles(videoPath).Where(x => x.Contains("png") || x.Contains("jpg"));

            foreach (var file in files)
            {
                try
                {
                    string s = ConvertImageToRichText(file);

                    CreateText(pos, rot, s, 0.55f);
                }
                catch (Exception e)
                {
                    Log.Error($"Error processing video file {file}: {e.Message}");
                }

                yield return Timing.WaitForSeconds(0.5f);
            }
        }
    }
}
