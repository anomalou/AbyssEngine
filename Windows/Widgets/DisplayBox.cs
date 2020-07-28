namespace AbyssBehavior{
    class DisplayBox:Widget{
        Camera camera;

        public DisplayBox(Camera camera):base(){this.camera = camera;}
        public DisplayBox():base(){}

        protected override void Behaviour(){
            if(camera != null){
                for(int x = 0; x < transform.scale.x; x++){
                    for(int y = 0; y < transform.scale.y; y++){
                        for(int l = 0; l < layers; l++){
                            if(x < camera.canvas.scale.x && y < camera.canvas.scale.y)
                                canvas[x,y,l].SetupPoint(camera.canvas.GetPoint(x,y,l));
                        }
                    }
                }
            }else
                Core.ThrowError(8);
        }

        public override void SetData(object data){
            camera = (Camera)data;
            transform.SetupScale(camera.scale);
        }
    }
}