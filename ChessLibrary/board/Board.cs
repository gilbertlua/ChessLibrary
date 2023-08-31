using System.Text;

namespace ChessLibrary{

    public class Board{
        private static Board _board = new Board();
        private Piece[,] _piecesHold;
        private int _sizeHeight;
        private int _sizeWidth;
        private List<IPiece> _captPiece = new List<IPiece>() ;
        private string[,] _configuration;
        private StringBuilder _chess_board = new StringBuilder();
        
        // constructur
        public Board(){
            _sizeWidth = 8;
            _sizeHeight = 8;

            _piecesHold = new Piece[8,8];
            _configuration = new string[,]{
                {"Pawn", "Pawn", "Pawn", "Pawn", "Pawn", "Pawn", "Pawn", "Pawn"},
                {"Rook", "Knight", "Bishop", "Queen", "King", "Bishop", "Knight", "Rook"}
            };
            // InitBoard();
        }

        /// <summary>
        /// is used for intialize board of chess with configuration file
        /// </summary>
        private void InitBoard(){
            CreateInitPiece? ip = new CreateInitPiece();
            for(int i = 0; i < 2; i++){
                for(int j = 0; j < 8; j++){
                    if(_configuration[i,j]!=null){
                        SetPiece(ip.CreatePiece(_configuration[i,j], PieceColor.white), new Spot(i+_sizeHeight - 2, j));   
                    }                         
                }
            }
            for(int i = 0; i < 2; i++){
                for(int j = 0; j < 8; j++){
                    SetPiece(ip.CreatePiece(_configuration[i,j], PieceColor.black), new Spot(2-1-i, j));        
                }
            }
        }    
        /// <summary>
        /// is used for move piece
        /// </summary>
        /// <param name="move"></param>
        /// <exception cref="Exception"></exception>
        public void MovePiece(Move move){
            if(!IsOutOfRange(move)){
                throw new Exception("out of range");
            }
            Piece tempPiece = GetPiece(move.GetStartSpot());
            if(tempPiece == null){
                throw new Exception("no element here");
            } 
            tempPiece.PieceGotMoved();
            if(!IsSpotEmpty(move.GetEndSpot())){
                CapturePiece(move.GetEndSpot());
            }
            SetPiece(tempPiece,move.GetEndSpot());
            ResetTile(move.GetStartSpot());
        }
        /// <summary>
        /// is use to reset tile
        /// </summary>
        /// <param name="spot"></param>
        public void ResetTile(Spot spot){
            if(_piecesHold[spot.Get_X(),spot.Get_Y()] is not null){
                _piecesHold[spot.Get_X(),spot.Get_Y()] = null!;
            }
        }

        /// <summary>
        /// is use to captured piece
        /// </summary>
        /// <param name="spot"></param>

        public void CapturePiece(Spot spot){
            _captPiece.Add(GetPiece(spot));
        }

        /// <summary>
        /// check if spot is empty
        /// </summary>
        /// <param name="spot"></param>
        /// <returns></returns>
        public bool IsSpotEmpty(Spot spot){
            return _piecesHold[spot.Get_X(),spot.Get_Y()] == null;
        }
        /// <summary>
        /// is used for add piece for the position
        /// </summary>
        /// <param name="piece">the piece instance</param>
        /// <param name="spot">spot you want to go</param>
        public void SetPiece(Piece piece,Spot spot){
            if(IsOutOfRange(spot.Get_X(),spot.Get_Y())){
                throw new ArgumentOutOfRangeException();
            }
            else{
                if(piece!=null){
                    _piecesHold[spot.Get_X(),spot.Get_Y()] = piece;
                }
            }
            
        }

        /// <summary>
        /// this method used to check if it is out of range
        /// </summary>
        /// <param name="move"></param>
        public bool IsOutOfRange(Move move){
            bool check = IsOutOfRange(move.GetStartSpot().Get_X(), move.GetStartSpot().Get_Y())
                        || IsOutOfRange(move.GetEndSpot().Get_X(), move.GetEndSpot().Get_Y());
            return true;
        }

        /// <summary>
        /// this method used to determine from move if is it out of ranges or not
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool IsOutOfRange(int x, int y){
            bool check = x < 0 || x >= _sizeHeight || y < 0 || y >= _sizeWidth;
            return check;
        }
        

        /// <summary>
        /// this metod used to view the board
        /// </summary>
        public void GenerateBoard(){
            for(int j=0 ;j<_sizeWidth ; j++){
                // Console.Write("\t"+(char)(j+'a')+ " ");
                _chess_board.Append("\t"+(char)(j+'a')+ " ");
            }
            _chess_board.Append("\n\n");
            // Console.WriteLine();
            for(int i=0; i<_sizeHeight; i++){
                // Console.Write(8-i);
                _chess_board.Append(8-i);
                for(int j=0; j<_sizeWidth;j++){
                    // Console.Write("\t" + GetPieceSymbol(new Spot(i,j))+ " ");
                    _chess_board.Append("\t" + GetPieceSymbol(new Spot(i,j))+ " ");
                }
                _chess_board.Append("\n");
                // Console.Write("\n");
            }
        }       
        public StringBuilder GetBoard(){
                return _chess_board;
        }

        /// <summary>
        /// is used for get piece symbol inside coordinate
        /// </summary>
        /// <param name="spot"></param>
        /// <returns></returns>
        private string GetPieceSymbol(Spot spot){
            Piece piece = GetPiece(spot);
            if(piece!=null){
                String firstchar;
                if(piece.GetColor() == PieceColor.white){
                    firstchar = "w";
                }
                else{
                    firstchar = "b";
                }
                return firstchar + GetPiece(spot).GetSymbol();
            }
            return "~";
        }

        /// <summary>
        /// this method is used for get the piece in the coordinate
        /// </summary>
        /// <param name="spot"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public Piece GetPiece(Spot spot){
            if(IsOutOfRange(spot.Get_X(),spot.Get_Y())){
                throw new ArgumentOutOfRangeException();
            }
            return _piecesHold[spot.Get_X(),spot.Get_Y()];    
        }   



    }
}