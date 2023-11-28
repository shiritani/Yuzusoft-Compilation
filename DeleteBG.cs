using StorybrewCommon.Mapset;
using StorybrewCommon.Scripting;

namespace StorybrewScripts
{
    public class DeleteBG : StoryboardObjectGenerator
    {
        public override void Generate()
        {
            GetLayer("").CreateSprite(Beatmap.BackgroundPath).Fade(0, 0);
        }
    }
}
