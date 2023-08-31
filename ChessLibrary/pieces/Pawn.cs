namespace ChessLibrary{
    public class Pawn:Piece{
        
        //constructor 
        public Pawn(PieceColor color){
            SetName("Pawn");
            SetSymbol("P");
            SetColor(color);
        }

        // override
        public override bool IsMovedValid(){
            return true;
        }
    }
}