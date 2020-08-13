using AbyssPlugins;
using System.Collections.Generic;
using System;

namespace AbyssBehavior{
    class GameSession{
        List<IStat> playerStats;
        List<IGameRule> gameRules;
        List<IMap> maps;

        IMap _currentMap;
        IMap currentMap{get{return _currentMap;}}


        public void AddStat(string statIdentificator){
            playerStats.Add(GameCore.CreateStat(statIdentificator));
        }

        public void AddGameRule(string grIdentificator){
            gameRules.Add(GameCore.CreateGameRule(grIdentificator));
        }

        public void AddMap(string mapIdentificator){
            maps.Add(GameCore.CreateMap(mapIdentificator));
        }
        public IStat[] GetStats(){return playerStats.ToArray();}
        public IGameRule[] GetRules(){return gameRules.ToArray();}
    }
}