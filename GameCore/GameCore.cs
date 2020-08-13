using System.Collections.Generic;
using AbyssPlugins;
using System;

namespace AbyssBehavior{
    static class GameCore{

        static List<IStat> _statsList;
        public static List<IStat> statsList{get{return _statsList;}}
        static List<IGameRule> _gameRulesList;
        public static List<IGameRule> gameRulesList{get{return _gameRulesList;}}
        static List<IGameObject> _gameObjectsList;
        public static List<IGameObject> gameObjectsList{get{return _gameObjectsList;}}
        static List<IMap> _mapsList;
        public static List<IMap> mapsList{get{return _mapsList;}}

        //plugins comtrollers
        public static IController controller;

        public static GameSession currentSession;


        public static void Initialization(){
            _statsList = new List<IStat>();
            _gameRulesList = new List<IGameRule>();
            _gameObjectsList = new List<IGameObject>();
            _mapsList = new List<IMap>();
            controller = new Controller();
        }

        public static void Update(){
            // foreach(IGameRule gameRule in gameRules){
            //     if(gameRule.CheckRule())
            //         gameRule.Behaviour();
            //     else
            //         gameRule.IfBreakRule();
            // }
        }

        public static IStat CreateStat(string identificator){
            foreach(IStat stat in statsList){
                if(stat.identificator == identificator){
                    IStat s = (IStat)Activator.CreateInstance(stat.GetType());
                    s.controller = controller;
                    return s;
                }
            }
            return null;
        }

        public static IGameRule CreateGameRule(string identificator){
            foreach(IGameRule gameRule in gameRulesList){
                if(gameRule.identificator == identificator){
                    IGameRule rule = (IGameRule)Activator.CreateInstance(gameRule.GetType());
                    rule.controller = controller;
                    return rule;
                }
            }
            return null;
        }

        public static IGameObject CreateGameObject(string identificator){
            foreach(IGameObject gameObject in gameObjectsList){
                if(gameObject.identificator == identificator){
                    IGameObject gameObj = (IGameObject)Activator.CreateInstance(gameObject.GetType());
                    gameObj.controller = controller;
                    return gameObj;
                }
            }
            return null;
        }

        public static IMap CreateMap(string identificator){
            foreach(IMap map in mapsList){
                if(map.identificator == identificator){
                    IMap m = (IMap)Activator.CreateInstance(map.GetType());
                    m.controller = controller;
                    return m;
                }
            }
            return null;
        }

        public static void NewSession(){

        }

        public static void ContinueSession(){
            
        }
    }
}