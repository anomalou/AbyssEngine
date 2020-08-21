namespace AbyssBehavior{
    public class Image:Widget{

        string image_name;

        public Image(string texture_name):base(){
            image_name = texture_name;
        }

        protected override void Render(){
            canvas.Set(0,0,0, image_name);
        }

        public override void SetData(object image){
            image_name = image.ToString();
        }
    }
}