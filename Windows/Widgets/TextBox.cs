namespace AbyssBehavior{
    class TextBox:Widget{

        string _text;
        public string text{get{return _text;}}

        public TextBox(Vector position, Vector scale):base(position, scale){}

        protected override void Behaviour(){
            for(int x = 0; x < text.Length; x++){
                if(x < transform.scale.x)
                    canvas[x, 0].SetupPoint("word"+text[x]);
                else
                    break;
            }
        }

        public override void SetData(object data){
            _text = data.ToString();
            System.Console.WriteLine(_text);
        }
    }
}