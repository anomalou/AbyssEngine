namespace AbyssBehavior{
    class DisplayBox:Widget{
        Camera camera;

        public DisplayBox(Vector position):base(position){
            transform.SetupScale(camera.scale);
        }

        protected override void Behaviour(){
            for(int x = 0; x < transform.scale.x; x++){
                for(int y = 0; x < transform.scale.y; y++){
                    for(int l = 0; l < layers; l++){
                        canvas[x,y,l].SetupPoint(camera.canvas.GetPoint(x,y,l));
                    }
                }
            }
        }

        public override void SetData(object data){
            camera = (Camera)data;
        }
    }
}