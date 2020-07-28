namespace AbyssBehavior{
    class Image:Widget{

        string image_name;

        public Image(string texture_name):base(){
            image_name = texture_name;
        }
        protected override void Behaviour(){
            canvas[0,0,0].SetupPoint(image_name);
        }

        public override void SetData(object image){
            image_name = image.ToString();
        }
    }
}