using System;


namespace SpaceInvaders
{
    public class SelectScene : SceneState
    {
        public override void handle(Scene pScene)
        {
            throw new NotImplementedException();
        }
        public override void loadContent(Scene pScene)
        {
            SpriteBatchMan.Add(SpriteBatch.Name.SelectWindowTexts);

            FontMan.Add(Font.Name.Texts, SpriteBatch.Name.SelectWindowTexts, "SCORE<1>", Glyph.Name.Consolas36pt, 20, 1000);
            FontMan.Add(Font.Name.Texts, SpriteBatch.Name.SelectWindowTexts, "HI-SCORE", Glyph.Name.Consolas36pt, 370, 1000);
            FontMan.Add(Font.Name.Texts, SpriteBatch.Name.SelectWindowTexts, "SCORE<2>", Glyph.Name.Consolas36pt, 700, 1000);
            FontMan.Add(Font.Name.ScoreOne, SpriteBatch.Name.SelectWindowTexts, pScene.getScoreOne().ToString("D4"), Glyph.Name.Consolas36pt, 50, 960);
            FontMan.Add(Font.Name.HighestScore, SpriteBatch.Name.SelectWindowTexts, pScene.getHighestScore().ToString("D4"), Glyph.Name.Consolas36pt, 400, 960);
            FontMan.Add(Font.Name.ScoreTwo, SpriteBatch.Name.SelectWindowTexts, pScene.getScoreTwo().ToString("D4"), Glyph.Name.Consolas36pt, 730, 960);
            FontMan.Add(Font.Name.Texts, SpriteBatch.Name.SelectWindowTexts, "CREDIT", Glyph.Name.Consolas36pt, 700, 25);
            FontMan.Add(Font.Name.Texts, SpriteBatch.Name.SelectWindowTexts, "00", Glyph.Name.Consolas36pt, 830, 25);
            FontMan.Add(Font.Name.Texts, SpriteBatch.Name.SelectWindowTexts, "SPACE    INVADERS", Glyph.Name.Consolas36pt, 300, 750);
            FontMan.Add(Font.Name.Texts, SpriteBatch.Name.SelectWindowTexts, "PUSH <1> OR <2> PLAYERS BUTTON", Glyph.Name.Consolas36pt, 160, 700);
            FontMan.Add(Font.Name.Texts, SpriteBatch.Name.SelectWindowTexts, "*SCORE  ADVANCE  TABLE*", Glyph.Name.Consolas36pt, 240, 650);
            FontMan.Add(Font.Name.Texts, SpriteBatch.Name.SelectWindowTexts, "= 200 POINTS", Glyph.Name.Consolas36pt, 380, 600);
            FontMan.Add(Font.Name.Texts, SpriteBatch.Name.SelectWindowTexts, "= 30 POINTS", Glyph.Name.Consolas36pt, 380, 550);
            FontMan.Add(Font.Name.Texts, SpriteBatch.Name.SelectWindowTexts, "= 20 POINTS", Glyph.Name.Consolas36pt, 380, 500);
            FontMan.Add(Font.Name.Texts, SpriteBatch.Name.SelectWindowTexts, "= 10 POINTS", Glyph.Name.Consolas36pt, 380, 450);

            SpriteBatch pSB_StartWindowSprites  = SpriteBatchMan.Add(SpriteBatch.Name.StartWindowSprites);
            ShipLifeGroup pStartWindow = new ShipLifeGroup(GameObject.Name.ShipLifeGroup, GameSprite.Name.NullObject, 0.0f, 0.0f);
            pStartWindow.activateGameSprite(pSB_StartWindowSprites);

            UFO pUFO = new UFO(GameObject.Name.UFO, GameSprite.Name.UFO, 320, 600, true);
            pUFO.activateGameSprite(pSB_StartWindowSprites);
            pStartWindow.add(pUFO);

            Squid pSquid = new Squid(GameObject.Name.Squid, GameSprite.Name.Squid, 320, 550);
            pSquid.activateGameSprite(pSB_StartWindowSprites);
            pStartWindow.add(pSquid);

            Crab pCrab = new Crab(GameObject.Name.Crab, GameSprite.Name.Crab, 320, 500);
            pCrab.activateGameSprite(pSB_StartWindowSprites);
            pStartWindow.add(pCrab);

            Octopus pOctopus = new Octopus(GameObject.Name.Octopus, GameSprite.Name.Octopus, 320, 450);
            pOctopus.activateGameSprite(pSB_StartWindowSprites);
            pStartWindow.add(pOctopus);

            GameObjectMan.Attach(pStartWindow);

            InputSubject pInputSubject;
            pInputSubject = InputMan.GetKey1Subject();
            pInputSubject.attach(new OnePlayerObserver());

            pInputSubject = InputMan.GetKey2Subject();
            pInputSubject.attach(new TwoPlayerObserver());

        }
        public override void update(Scene pScene, float currTime)
        {
            InputMan.Update();
            GameObjectMan.Update();
        }
        public override void draw(Scene pScene)
        {
            SpriteBatchMan.Draw();
        }
        public override void unLoadContent(Scene pScene)
        {
            InputMan.Reset();
            //SpriteBatchMan.Find(SpriteBatch.Name.SelectWindowTexts).setIsDraw(false);
            SpriteBatchMan.Reset();
            GameObjectMan.Reset();
            //SpriteBatchMan.Find(SpriteBatch.Name.SelectWindowTexts).deepClear();
            //SpriteBatchMan.Remove(SpriteBatchMan.Find(SpriteBatch.Name.SelectWindowTexts));
        }
    }
}
