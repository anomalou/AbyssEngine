namespace AbyssBehavior{
    public class ImageView:Widget{

        public string image_name;
        public RGBA color;

        public ImageView(string texture_name):base(){
            image_name = texture_name;
            color = new RGBA();
        }

        protected override void Render(){
            canvas.Set(0,0,0, image_name, color);
        }
    }
}