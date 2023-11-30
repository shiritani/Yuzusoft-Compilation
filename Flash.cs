using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;

namespace StorybrewScripts
{
    public class Flash : StoryboardObjectGenerator
    {
        public override void Generate()
        {
            var layer = GetLayer("Flash");
            var flash = layer.CreateSprite("sb/flash.jpg", OsbOrigin.Centre);

            flash.Fade(OsbEasing.None, 47868, 48068, 0, .2f);
            flash.Fade(OsbEasing.OutExpo, 48068, 49268, 1, 0);
        }
    }
}
