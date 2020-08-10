using System.Collections.Generic;
using AbyssPlugins;
using System;

namespace AbyssBehavior{
    static class GameCore{
        public static List<IStat> stats;
        public static List<IGameRule> gameRules;

        //plugins comtrollers
        public static GameRuleControl gameRuleControl;
        public static StatControl statControl;


        public static void Initialization(){
            stats = new List<IStat>();
            gameRules = new List<IGameRule>();
            gameRuleControl = new GameRuleControl();
            statControl = new StatControl();
        }

        public static void Update(){
            foreach(IGameRule gameRule in gameRules){
                if(gameRule.CheckRule())
                    gameRule.Behaviour();
                else
                    gameRule.IfBreakRule();
            }
        }
    }
}