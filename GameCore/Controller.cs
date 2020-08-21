using AbyssPlugins;

namespace AbyssBehavior{
    class Controller:IController{
        public IStat GetStat(string statIdentificator){
            if(GameCore.currentSession != null)
                foreach(IStat stat in GameCore.currentSession.GetStats()){
                    if(stat.identificator == statIdentificator)
                        return stat;
                }
            return null;
        }

        public void MovePlayer(Vector direction){
            if(GameCore.currentSession != null){
                
            }
        }
    }
}