namespace fn181218001.Core.Contracts
{
    public interface IController
    {
        string GenerateSubSequenceAndAddToSequence(int maxLengthSequence, int start, int end);
        string GenerateNumberAndAddToSequence(int start, int end);
        string Sort();
        string Print();
        void SaveOutputInFile();
        string Save();
        string Load();
        string Clear();
    }
}
