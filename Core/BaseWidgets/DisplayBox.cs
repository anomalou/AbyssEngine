namespace AbyssBehavior{
    public class DisplayBox:Widget{
        public Camera camera;

        protected override void Render(){
            if(camera != null){
                for(int x = 0; x < transform.scale.x; x++){
                    for(int y = 0; y < transform.scale.y; y++){
                        for(int d = 0; d < canvas.depth; d++){
                            if(x < camera.canvas.scale.x && y < camera.canvas.scale.y)
                                canvas.Set(x,y,d, camera.canvas.Get(x,y,d));
                        }
                    }
                }
            }/* else
                Core.ThrowError(8); */
        }

        // public override void SetData(object data){
        //     camera = (Camera)data;
        //     transform.SetScale(camera.scale);
        // }
    }
}