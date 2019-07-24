namespace WrappingRover
{
    internal class Space
    {
        public string Character { get; set; }

        public Space North { get; set; }
        public Space South { get; set; }
        public Space East { get; set; }
        public Space West { get; set; }
        
        public Space(string character)
        
        {
            Character = character;
        }
    }
}