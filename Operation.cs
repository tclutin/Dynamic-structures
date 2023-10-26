namespace Dynamic_structures
{
    public class Operation
    {
        public int Number { get; }
        public object Data { get; }

        public Operation(int number, object data = null)
        {
            Number= number;
            Data= data;
        }
    }
}
