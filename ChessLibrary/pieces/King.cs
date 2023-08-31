namespace ChessLibrary{
    public class King:Piece{
         public King(PieceColor color){
            SetName("King");
            SetSymbol("K");
            SetColor(color);
        }

        // override
        public override bool IsMovedValid(){
            return true;
        }
    }
}