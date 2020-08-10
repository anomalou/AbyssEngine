using AbyssPlugins;

namespace AbyssBehavior{
    class GameRuleControl:IGameRuleControl{
        public IStat GetStat(string statIdentificator){
            foreach(IStat stat in GameCore.stats){
                if(stat.identificator == statIdentificator)
                    return stat;
            }
            return null;
        }
    }
}