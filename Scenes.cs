using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;

namespace StorybrewScripts
{
    public class Scenes : StoryboardObjectGenerator
    {
        const double defaultZoom = 480.0 / 1080;
        const int offset = 1000;

        //
        // storyboard script (will implement if I have free time)
        //  

        public override void Generate()
        {
            ScaleDownRotate("sb/scenes/nene.jpg", 2250, 84068);
            ScaleUpRotate("sb/scenes/murasame.jpg", 93055, 189305);
            DiagonalDownRight("sb/scenes/ayase.jpg", 211716, 289716);
            ScaleUpRotate("sb/scenes/kanna.jpg", 297251, 379450);
            DiagonalUpLeft("sb/scenes/amane.jpg", 390862, 468195);
        }

        //
        // code taken from PoNo's CompilationManager
        //

        public void ScaleDownRotate(string bgLink, int startTime, int endTime)
        {
            var bg = GetLayer("Scenes").CreateSprite(bgLink, OsbOrigin.Centre);

            bg.Scale(startTime, endTime + offset, defaultZoom * 1.1, defaultZoom * 1.2);
            bg.Fade(OsbEasing.OutCubic, startTime, startTime + offset, 0, 1);
            bg.Fade(endTime, endTime + offset, 1, 0);
            bg.Rotate(OsbEasing.OutSine, startTime, endTime, 0.05, -0.05);
        }

        public void ScaleUpRotate(string bgLink, int startTime, int endTime)
        {
            var bg = GetLayer("Scenes").CreateSprite(bgLink, OsbOrigin.Centre);

            bg.Scale(startTime, endTime + offset, defaultZoom * 1.2, defaultZoom * 1.1);
            bg.Fade(OsbEasing.OutCubic, startTime, startTime + offset, 0, 1);
            bg.Fade(endTime, endTime + offset, 1, 0);
            bg.Rotate(OsbEasing.OutSine, startTime, endTime, -0.05, 0.05);
        }

        public void DiagonalDownRight(string bgLink, int startTime, int endTime)
        {
            var bg = GetLayer("Scenes").CreateSprite(bgLink, OsbOrigin.Centre);

            bg.Scale(startTime, endTime + offset, defaultZoom * 1.2, defaultZoom * 1.1);
            bg.Fade(OsbEasing.OutCubic, startTime, startTime + offset, 0, 1);
            bg.Fade(endTime, endTime + offset, 1, 0);
            bg.MoveY(OsbEasing.InOutSine, startTime, endTime + offset, 250, 230);
            bg.MoveX(OsbEasing.InOutSine, startTime, endTime + 1000, 310, 330);
        }

        public void DiagonalUpLeft(string bgLink, int startTime, int endTime)
        {
            var bg = GetLayer("Scenes").CreateSprite(bgLink, OsbOrigin.Centre);

            bg.Scale(startTime, endTime + offset, defaultZoom * 1.2, defaultZoom * 1.1);
            bg.Fade(OsbEasing.OutCubic, startTime, startTime + offset, 0, 1);
            bg.Fade(endTime, endTime + offset, 1, 0);
            bg.MoveY(OsbEasing.InOutSine, startTime, endTime + offset, 230, 250);
            bg.MoveX(OsbEasing.InOutSine, startTime, endTime + 1000, 330, 310);
        }

        //  
        // flashbang goes brrr (todo)
        //

        public void FLashFade(string bgLink, int startTime, int endTime)
        {
            var bg = GetLayer("Scenes").CreateSprite(bgLink, OsbOrigin.Centre);


        }
    }
}
