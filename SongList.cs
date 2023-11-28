using OpenTK;
using OpenTK.Graphics;
using StorybrewCommon.Mapset;
using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using StorybrewCommon.Storyboarding.Util;
using StorybrewCommon.Subtitles;
using StorybrewCommon.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace StorybrewScripts
{
    public class SongList : StoryboardObjectGenerator
    {
        public string fontPath = "assetlibrary/HatsukoiFriends.otf";

        private readonly string fontDirectory = "sb/fonts";
        private readonly float fontScale = 0.3f;

        private FontGenerator Font;

        private double BeatDuration;

        public override void Generate()
        {
            BeatDuration = Beatmap.GetTimingPointAt(0).BeatDuration;
            Font = SetupFont();

            GenerateLine("米倉千尋 - 恋せよ乙女!", 2250, 84340);
            GenerateLine("KOTOKO - 恋ひ恋ふ縁", 93055, 189305);
            GenerateLine("橋本みゆき、佐咲紗花 - astral ability", 211716, 289716);
            GenerateLine("米倉千尋 - Smiling-Swinging!!", 297251, 379450);
            GenerateLine("QUARTET*RE-BOOT! - FUN FUN RE-BOOT", 390862, 468195);
        }

        private void GenerateLine(string line, double startTime, double endTime)
        {
            float lineWidth = 0f;
            float lineHeight = 0f;

            foreach (var letter in line)
            {
                FontTexture texture = Font.GetTexture(letter.ToString());
                lineWidth += texture.BaseWidth * fontScale;
                lineHeight = Math.Max(lineHeight, texture.BaseHeight * fontScale);
            }

            float letterX = 20;
            double delay = 0d;
            bool hasBox = false;

            foreach (var letter in line)
            {
                FontTexture texture = Font.GetTexture(letter.ToString());
                if (!texture.IsEmpty)
                {
                    Vector2 position = new Vector2(letterX, 400) + texture.OffsetFor(OsbOrigin.Centre) * fontScale;
                    if (!hasBox)
                    {
                        var box = GetLayer("").CreateSprite("sb/p.png", OsbOrigin.CentreLeft, new Vector2(10, position.Y));
                        box.ScaleVec(OsbEasing.OutExpo, startTime, startTime + BeatDuration * 1.5, 0, lineHeight + 5, lineWidth + 20, lineHeight + 5);
                        box.ScaleVec(OsbEasing.InExpo, endTime - BeatDuration * 1.5, endTime, lineWidth + 20, lineHeight + 5, 0, lineHeight + 5);
                        box.Fade(startTime, 0.8);
                        box.Color(startTime, Color4.Black);

                        hasBox = true;
                    }

                    OsbSprite sprite = GetLayer("").CreateSprite(texture.Path, OsbOrigin.Centre, position);
                    sprite.Scale(startTime + delay, fontScale);
                    sprite.MoveX(OsbEasing.InExpo, endTime - BeatDuration * 1.5, endTime, position.X, 320);
                    sprite.Fade(startTime + delay, startTime + delay + BeatDuration, 0, 1);
                    sprite.Fade(endTime - BeatDuration, endTime, 1, 0);

                    delay += BeatDuration / 8;
                }

                letterX += texture.BaseWidth * fontScale;
            }
        }

        private FontGenerator SetupFont()
        {
            return LoadFont(fontDirectory, new FontDescription()
            {
                FontPath = fontPath,
                FontSize = 60,
                Color = Color4.White
            });
        }
    }
}
