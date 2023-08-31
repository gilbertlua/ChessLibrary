namespace ChessLibrary{
    public class Rook:Piece{
         public Rook(PieceColor color){
            SetName("Rook");
            SetSymbol("R");
            SetColor(color);
        }

        // override
        public override bool IsMovedValid(){
            return true;
        }
    }    
}