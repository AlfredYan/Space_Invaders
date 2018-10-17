using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class GameOverScene : SceneState
    {
        public override void handle(Scene pScene)
        {
            throw new NotImplementedException();
        }
        public override void loadContent(Scene pScene)
        {
            if (SpriteBatchMan.Find(SpriteBatch.Name.GameOverWindowTexts) == null)
            {
                SpriteBatchMan.Add(SpriteBatch.Name.GameOverWindowTexts);
                FontMan.Add(Font.Name.Texts, SpriteBatch.Name.GameOverWindowTexts, "GAME OVER", Glyph.Name.Consolas36pt, 350, 750);
                FontMan.Add(Font.Name.Texts, SpriteBatch.Name.GameOverWindowTexts, "PLAYER1 SCORE:", Glyph.Name.Consolas36pt, 250, 650);
                FontMan.Add(Font.Name.Texts, SpriteBatch.Name.GameOverWindowTexts, pScene.getScoreOne().ToString("D4"), Glyph.Name.Consolas36pt, 550, 650);
                FontMan.Add(Font.Name.Texts, SpriteBatch.Name.GameOverWindowTexts, "PLAYER2 SCORE:", Glyph.Name.Consolas36pt, 250, 600);
                FontMan.Add(Font.Name.Texts, SpriteBatch.Name.GameOverWindowTexts, pScene.getScoreTwo().ToString("D4"), Glyph.Name.Consolas36pt, 550, 600);
                FontMan.Add(Font.Name.Texts, SpriteBatch.Name.GameOverWindowTexts, "Highest SCORE:", Glyph.Name.Consolas36pt, 250, 550);
                FontMan.Add(Font.Name.Texts, SpriteBatch.Name.GameOverWindowTexts, pScene.getHighestScore().ToString("D4"), Glyph.Name.Consolas36pt, 550, 550);
            }
            else
            {
                SpriteBatchMan.Find(SpriteBatch.Name.GameOverWindowTexts).setIsDraw(true);
            }

            InputSubject pInputSubject;
            pInputSubject = InputMan.GetKeyEnterSubject();
            pInputSubject.attach(new BackToSelectObserver());
        }
        public override void update(Scene pScene, float currTime)
        {
            InputMan.Update();
        }
        public override void draw(Scene pScene)
        {
            SpriteBatchMan.Draw();
        }
        public override void unLoadContent(Scene pScene)
        {
            SpriteBatchMan.Reset();
            InputMan.Reset();
            pScene.setScoreOne(0);
        }
    }
}
