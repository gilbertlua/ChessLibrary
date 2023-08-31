namespace ChessLibrary{
    public class Move{
        private Spot _startSpot; 
        private Spot _endSpot;

        /// <summary>
        /// use for move piece
        /// </summary>
        /// <param name="startSpot">define start spot</param>
        /// <param name="endSpot">define end sport</param>
        public Move(Spot startSpot, Spot endSpot){
            _startSpot = startSpot; 
            _endSpot = endSpot; 
        }  
        /// <summary>
        /// use to get the start spot
        /// </summary>
        /// <returns>Will return the Spot</returns>
        public Spot GetStartSpot() { 
            return _startSpot;
        }
        /// <summary>
        /// use to get the end of spot
        /// </summary>
        /// <returns></returns>
        public Spot GetEndSpot(){
            return _endSpot;
        }   
    }
}