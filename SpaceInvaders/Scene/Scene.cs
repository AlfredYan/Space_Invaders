using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class Scene
    {
        //---------------------------------------------------------
        // Constructor
        //---------------------------------------------------------
        public Scene()
        {
            this.state = null;
            this.scoreOne = 0;
            this.scoreTwo = 0;
            this.highestScore = 0;
        }
        public void loadContent()
        {
            this.state.loadContent(this);
        }
        public void update(float currTime)
        {
            this.state.update(this, currTime);
        }
        public void draw()
        {
            this.state.draw(this);
        }
        public void unLoadContent()
        {
            this.state.unLoadContent(this);
        }

        public void setState(SceneMan.State state)
        {
            this.state = SceneMan.GetState(state);
        }
        public int getScoreOne()
        {
            return this.scoreOne;
        }
        public void addScoreOne(int score)
        {
            this.scoreOne += score;
        }
        public int getScoreTwo()
        {
            return this.scoreTwo;
        }
        public int getHighestScore()
        {
            return this.highestScore;
        }
        public void setHighstScore(int score)
        {
            this.highestScore = score;
        }
        public void setScoreOne(int score)
        {
            this.scoreOne = score;
        }
        private SceneState state;
        private int scoreOne;
        private int scoreTwo;
        private int highestScore;
    }
}
