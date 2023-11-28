using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;

namespace StorybrewScripts
{
    public class Scenes : StoryboardObjectGenerator
    {
        readonly double defaultZoom = 480.0 / 1080;
        readonly int offset = 1000;

        public override void Generate()
        {
            ScaleDownRotate("sb/scenes/nene.jpg", 2250, 84068);
            ScaleUpRotate("sb/scenes/murasame.jpg", 93055, 189305);
            ScaleDownRotate("sb/scenes/ayase.jpg", 211716, 289716);
            ScaleUpRotate("sb/scenes/kanna.jpg", 297251, 379450);
            ScaleDownRotate("sb/scenes/amane.jpg", 390862, 468195);
        }

        public void ScaleDownRotate(string bgLink, int startTime, int endTime)
        {
            var bg = GetLayer("Scenes").CreateSprite(bgLink, OsbOrigin.Centre);

            bg.Scale(startTime, endTime + offset, defaultZoom * 1.1, defaultZoom * 1.2);
            bg.Fade(startTime, startTime + offset, 0, 1);
            bg.Fade(endTime, endTime + offset, 1, 0);
            bg.Rotate(OsbEasing.OutSine, startTime, endTime, 0.05, -0.05);
        }

        public void ScaleUpRotate(string bgLink, int startTime, int endTime)
        {
            var bg = GetLayer("Scenes").CreateSprite(bgLink, OsbOrigin.Centre);

            bg.Scale(startTime, endTime + offset, defaultZoom * 1.2, defaultZoom * 1.1);
            bg.Fade(startTime, startTime + offset, 0, 1);
            bg.Fade(endTime, endTime + offset, 1, 0);
            bg.Rotate(OsbEasing.OutSine, startTime, endTime, -0.05, 0.05);
        }

        // todo: implement more stuff for more scenes (maybe)
    }
}
