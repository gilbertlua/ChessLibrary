namespace ChessLibrary
{
    public class Spot{
        private int _x;
        private int _y;

        public Spot(int x, int y){
            _x = x;
            _y = y;
        }
        public int Get_X(){
            return _x;
        }
        public int Get_Y(){
            return _y;
        }    
    }
}