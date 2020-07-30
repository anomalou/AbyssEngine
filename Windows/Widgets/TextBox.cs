namespace AbyssBehavior{
    class TextBox:Widget{

        string _text;
        public string text{get{return _text;}}

        public TextBox(string text):base(){ _text = text; SizeToText();}

        protected override void Render(){
            for(int x = 0, y = 0, l = 0; l < text.Length;){
                if(x < transform.scale.x && y < transform.scale.y){
                    canvas[x, y, 0].SetupPoint("word"+text[l]);
                    x++;
                    l++;
                }else
                    if(y < transform.scale.y){
                        y++;
                        x = 0;
                    }else
                        break;
            }
        }

        public void SizeToText(){
            SetSize(new Vector(text.Length, 1));
        }

        public override void SetData(object data){
            _text = data.ToString();
        }
    }
}