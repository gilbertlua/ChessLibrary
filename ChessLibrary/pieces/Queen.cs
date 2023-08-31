namespace ChessLibrary{
    public class Queen:Piece{
         public Queen(PieceColor color){
            SetName("Queen");
            SetSymbol("Q");
            SetColor(color);
        }

        // override
        public override bool IsMovedValid(){
            return true;
        }
    }
}