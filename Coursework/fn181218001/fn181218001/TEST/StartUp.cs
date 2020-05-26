using System;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Threading;

namespace TEST
{
    class StartUp
    {
        static void Main()
        {
            //test co-working between procceses
            string myString = "That's my string";
            try
            {
                using (MemoryMappedFile mmf = MemoryMappedFile.OpenExisting("testmap"))
                {

                    Mutex mutex = Mutex.OpenExisting("testmapmutex");
                    mutex.WaitOne();

                    using (MemoryMappedViewStream stream = mmf.CreateViewStream(1, 0))
                    {
                        BinaryWriter writer = new BinaryWriter(stream);
                        writer.Write(myString);
                    }
                    mutex.ReleaseMutex();
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Memory-mapped file does not exist. Run Process A first.");
            }
        }
    }
}
