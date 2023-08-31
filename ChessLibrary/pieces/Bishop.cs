namespace ChessLibrary{
    public class Bishop:Piece{
        public Bishop(PieceColor color){
            SetName("Bishop");
            SetSymbol("B");
            SetColor(color);
        }

        // override
        public override bool IsMovedValid(){
            return true;
        }
    }
}