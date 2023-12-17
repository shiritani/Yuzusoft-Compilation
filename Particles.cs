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

namespace StorybrewScripts
{
    public class Particles : StoryboardObjectGenerator
    {
        private double BeatDuration;

        public override void Generate()
        {
            BeatDuration = GetBeatDuration(0);

            GenerateParticles(500, 2522, BeatDuration * 20, 24);
            GenerateParticles(85159, 93472, BeatDuration * 25, 16);
            GenerateParticles(190347, 212178, BeatDuration * 35, 12);
            GenerateParticles(290726, 297700, BeatDuration * 25, 16);
            GenerateParticles(380276, 391112, BeatDuration * 22, 22);
        }

        private void GenerateParticles(double startTime, double endTime, double particleDuration, int particleCount, string filePath = "sb/circle.png", float scale = 0.02f, double opacity = 1)
        {
            var bitmap = GetMapsetBitmap(filePath);
            var bitmapScale = bitmap.Height * scale;
            using (var pool = new OsbSpritePool(GetLayer("Particles"), filePath, OsbOrigin.Centre, (sprite, starttime, endtime) =>
            {
                sprite.Fade(startTime - 500, startTime, 0, 0.6);
                sprite.Fade(endTime - 500, endTime, 0.6, 0);
            }))
            {
                var timestep = particleDuration / particleCount;
                for (double starttime = startTime - (particleDuration + BeatDuration * 12); starttime < endTime; starttime += timestep)
                {
                    var moveSpeed = Random(100, 150);
                    var endtime = starttime + Math.Ceiling(480f / moveSpeed) * particleDuration;
                    var sprite = pool.Get(starttime, endtime);

                    var startX = Random(-107, 746);
                    sprite.MoveX(starttime, endtime, startX, startX + Random(-50, 50f));
                    sprite.MoveY(starttime, endtime, 480, 240);
                    sprite.Scale(starttime, Random(scale, scale * 10));
                    sprite.Additive(starttime, endtime);
                }
            }
        }

        public double GetBeatDuration(double time)
            => Beatmap.GetTimingPointAt((int)time).BeatDuration;
    }
}