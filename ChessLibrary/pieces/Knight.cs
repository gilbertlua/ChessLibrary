namespace ChessLibrary{
    public class Knight:Piece{
         public Knight(PieceColor color){
            SetName("Knight");
            SetSymbol("Kn");
            SetColor(color);
        }

        // override
        public override bool IsMovedValid(){
            return true;
        }
    }
}